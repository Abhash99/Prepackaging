using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace PrePackaging
{
    /**/
    /*
     *  CLASS DESCRIPTION:
     *      The class handles all input and output operations related to prepackaging process.

     *  PURPOSE:
     *      To get all the inputs from respective sources and create the output file based on 
     *      the results of the scheduler.
     *      
     *  AUTHOR: 
     *      Abhash Panta
     */
    /**/
    class IOManager
    { 
        // Member variables

        // Represents the path of the executable file.
        private string m_appPath;

        // Represents the path of the resources folder.
        // It contains the serialized four-year plans. 
        private string m_resourceFolder;

        // Represents the full path of the course information file. 
        private string m_courseFilePath;

        // Represents the full path of the student information file. 
        private string m_studentFilePath;

        // Represents the academic year for the four-year-plan.
        private string m_year;

        // Represents the path of the four-year plan folder corresponding
        // to the academic year.
        private string m_FYP_Year_Path;

        // Represent the full path of the output directory. The output file will be saved
        // in this location. 
        private string m_outputDirectoryPath;

        // Represents the full path of the athlete information excel file. 
        private string m_athleteFilePath;

        // Represents the full path of the sports information excel file. 
        private string m_sportFilePath;

        // Represents the decision date (when student made decision to enroll).
        private DateTime m_decnDate;

        /**/
        /*
         *  NAME: 
         *      IOManager()
         *  
         *  SYNOPSIS:
         *      IOManager(string a_year, string a_courseFilePath, string a_studentFilePath, string a_outputDirPath)
         *          a_year --> the academic year for four-year plan.
         *          a_courseFilePath --> the path of the course information excel file. 
         *          a_studentFilePath --> the path of the student information excel file. 
         *          a_outputDirPath --> the path of the output directory.
         *          a_atheleteFilePath --> the full path of the athlete information excel file.
         *          a_sportFilePath --> the path of the sports information excel file.
         *          a_decnDate --> decision date (when the student made decision to enroll).
         *         
         *  DESCRIPTION:
         *      Parametrized constructor for IOManager Class.
         *     
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public IOManager(string a_year, string a_courseFilePath, string a_studentFilePath, string a_outputDirPath, string a_athleteFilePath, string a_sportFilePath, DateTime a_decnDate)
        {
            m_appPath = Path.GetDirectoryName(Application.ExecutablePath);
            m_resourceFolder = AppPath + "\\resources";
            m_year = a_year;
            m_courseFilePath = a_courseFilePath;
            m_studentFilePath = a_studentFilePath;
            m_FYP_Year_Path = m_resourceFolder + "\\FYP\\" + m_year;
            m_outputDirectoryPath = a_outputDirPath;
            m_athleteFilePath = a_athleteFilePath;
            m_sportFilePath = a_sportFilePath;
            m_decnDate = a_decnDate;
        }

        // Properties for member variables
        public string AppPath { get => m_appPath; set => m_appPath = value; }
        public string ResourceFolder { get => m_resourceFolder; set => m_resourceFolder = value; }
        public string CourseFilePath { get => m_courseFilePath; set => m_courseFilePath = value; }
        public string StudentFilePath { get => m_studentFilePath; set => m_studentFilePath = value; }
        public string Year { get => m_year; set => m_year = value; }
        public string FYP_Year_Path { get => m_FYP_Year_Path; set => m_FYP_Year_Path = value; }
        public string OutputDirectoryPath { get => m_outputDirectoryPath; set => m_outputDirectoryPath = value; }
        public string AthleteFilePath { get => m_athleteFilePath; set => m_athleteFilePath = value; }
        public string SportFilePath { get => m_sportFilePath; set => m_sportFilePath = value; }
        public DateTime DecnDate { get => m_decnDate; set => m_decnDate = value; }



        /**/
        /*
         *  NAME: 
         *      GetFYPMajors()
         *  
         *  SYNOPSIS:
         *      List<Major> GetFYPMajors()
         *          
         *  DESCRIPTION:
         *      Obtains the list of Major class objects, which represent the four-year
         *      plan for each major in Ramapo. 
         *     
         *  RETURNS:
         *      List<Major> --> a list of FYP for all majors in Ramapo College. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public List<Major> GetFYPMajors()
        {
            List<Major> majorList;

            // Create the folder for Four-year plan based on the year. 
            CreateFYPYearFolder();

            // If the directory is empty, we need to use webscraper to pull
            // information from the file. 
            // Else, we obtain the FYPs from the saved files. 
            if (IsDirectoryEmpty(FYP_Year_Path))
            {
                majorList = GetFYPFromWeb();
                SaveFYPAsFiles(majorList);
            }
            else
            {
                majorList = GetFYPFromFiles();
            }

            return majorList;
        }


        /**/
        /*
         *  NAME: 
         *     GetCourses()
         *  
         *  SYNOPSIS:
         *      List<Course> GetCourses()
         *          
         *  DESCRIPTION:
         *      Obtains the list of all courses (classes) being offered at 
         *      Ramapo for the particular semester. 
         *      This will be obtained from the Course Information File. 
         *     
         *  RETURNS:
         *      List<Course> --> A list of Course objects that represent each class
         *      being offered in Ramapo for that particular semester. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public List<Course> GetCourses()
        {
            // Use CourseReader class to parse the course information excel file. 
            // Obtain the list of Courses and return the list. 
            CourseReader courseReader = new CourseReader();
            List<Course> courseList = courseReader.ReadCourseList(CourseFilePath);
            return courseList;
        }


        /**/
        /*
         *  NAME: 
         *      GetStudents()
         *  
         *  SYNOPSIS:
         *      List<Student> GetStudents()
         *          
         *  DESCRIPTION:
         *      Obtains the list of all incoming freshmen students based on the
         *      student information excel file. 
         *     
         *  RETURNS:
         *      List<Student> --> A list of Student objects that represent each incoming
         *      freshman student. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public List<Student> GetStudents()
        {

            StudentReader studentReader = new StudentReader();
            List<Student> studentList = studentReader.ReadStudentList(StudentFilePath);
            return studentList;

        }


        /**/
        /*
         *  NAME: 
         *      GetAthletes()
         *  
         *  SYNOPSIS:
         *      List<Athlete> GetAthletes()
         *          
         *  DESCRIPTION:
         *      Obtains the list of all athletes.
         *      This will be obtained from the athletes information excel file.
         *     
         *  RETURNS:
         *      List<Athlete> --> A list of athlete object that represent each athlete student. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public List<Athlete> GetAthletes()
        {
            AthleteReader athleteReader = new AthleteReader();
            List<Athlete> list = athleteReader.ReadAthletesList(AthleteFilePath);
            return list;
        }

        /**/
        /*
         *  NAME: 
         *      GetSports()
         *  
         *  SYNOPSIs:
         *      List<Sport> GetSports()
         *          
         *  DESCRIPTION:
         *      Obtains the list of all the sport objects using SportsTimeReader. 
         *      This will be obtained from the sports information file. 
         *     
         *  RETURNS:
         *      List<Sport> --> A list of sport objects. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public List<Sport> GetSports()
        {
            SportsTimeReader sportsTimeReader = new SportsTimeReader();
            List<Sport> list = sportsTimeReader.GetSportsList(SportFilePath);
            return list;
        }

        /**/
        /*
         *  NAME: 
         *     GetFYPFromWeb()
         *  
         *  SYNOPSIS:
         *      List<Major> GetFYPFromWeb()
         *          
         *  DESCRIPTION:
         *      Obtain the list of FYPs from the Web using Webscraper class. 
         *     
         *  RETURNS:
         *      List<Major> --> A list of Major object where each object represent 
         *      the four-year plan for a particular major.
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private List<Major> GetFYPFromWeb()
        {
            Webscraper scraper = new Webscraper();
            List<Major> majorList = scraper.GetFourYearPlans();
            return majorList;
        }

        /**/
        /*
         *  NAME: 
         *     SaveFYPAsFiles()
         *  
         *  SYNOPSIS:
         *      void SaveFYPAsFiles(List<Major> a_majorList)
         *          
         *  DESCRIPTION:
         *      Saves the majorList obtained from Webscaping as organized
         *      text files in the resources folder. 
         *     
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private void SaveFYPAsFiles(List<Major> a_majorList)
        {
            foreach (Major major in a_majorList)
            {
                SerializeMajor(major);
            }
        }

        /**/
        /*
         *  NAME: 
         *     SerializeMajor()
         *  
         *  SYNOPSIS:
         *      void SerializeMajor(Major a_major)
         *          a_major --> the major and its attributes, which are to be written 
         *          into a text file as a string.
         *      
         *          
         *  DESCRIPTION:
         *      Creates a text file for each major in the resources/FYP_Year_Path folder
         *      and writes each major and its attributes as a string into the text file. 
         *      
         *      Note: The text file is later parsed to get the FYPs. This saves a lot of
         *      time as Webscraping everytime is time-consuming. 
         *     
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private void SerializeMajor(Major a_major)
        {
            string fileName = a_major.Id + ".txt";
            string filepath = FYP_Year_Path + "\\" + fileName;

            // Using the StreamWriter object to write the string format of the major into the
            // text file. 
            if (!File.Exists(filepath))
            {
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.Write(a_major.ToString());
                }
            }
        }


        /**/
        /*
         *  NAME: 
         *     GetFYPFromFiles()
         *  
         *  SYNOPSIS:
         *      List<Major> GetFYPFromFiles()
         *          
         *  DESCRIPTION:
         *      Obtains a list of FYP for each major from the serialized text file. 
         *     
         *  RETURNS:
         *      List<Major> --> A list of Major object where each object represent 
         *      the four-year plan for a particular major. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private List<Major> GetFYPFromFiles()
        {
            List<Major> majorList = new List<Major>();

            // Each file in the FYP_Year_Path directory represents a major
            // and contains the details representing the FYP.
            // We obtain each major one by one, add it to the list and 
            // return the list. 
            foreach (string filePath in Directory.GetFiles(FYP_Year_Path))
            {
                Major major = ReadMajor(filePath);
                majorList.Add(major);
            }
            return majorList;
        }


        /**/
        /*
         *  NAME: 
         *     ReadMajor()
         *  
         *  SYNOPSIS:
         *      Major ReadMajor(string a_filepath)
         *          
         *  DESCRIPTION:
         *      Obtains a major object from a file by parsing the text file. 
         *     
         *  RETURNS:
         *      Major --> the major object that represents the FYP for a particular
         *      major.
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private Major ReadMajor(string a_filepath)
        {
            Major major = new Major();
            // If the file exists, parse the file based on the serialization format. 
            if (File.Exists(a_filepath))
            {
                string[] lines = File.ReadAllLines(a_filepath);

                // MajorName and MajorId are saved in the first line, separated by "->".
                // So, they are obtained at first. 
                string header = lines[0];
                string[] tokens = Regex.Split(header, "->");
              
                string majorName = tokens[0];
                string majorId = tokens[1];

                // We obtain the list of FYP_Categories by parsing th remaining lines.
                List<FYP_Category> categoryList = ReadCourseCategories(lines);
                
                // Set all the attributes and return the major object. 
                major.Name = majorName;
                major.Id = majorId;
                major.CourseCategories = categoryList;
            }

            return major;
        }


        /**/
        /*
         *  NAME: 
         *     ReadCourseCategories()
         *  
         *  SYNOPSIS:
         *      List<FYP_Category> ReadCourseCategories(string[] a_lines)
         *          a_lines --> an array of all the lines in the text file.
         *          
         *  DESCRIPTION:
         *      Obtains the list of FYP_Categories by parsing the lines in the 
         *      major text file. 
         *     
         *  RETURNS:
         *      List<FYP_Category> --> List of all FYP_Categories, along with their
         *      course elements parsed from the lines. 
         *      
         *      NOTE: Parsing is done based on the serialization format defined in the
         *      ToString() method for Major, FYP_Category and FYP_CourseElement classes. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private List<FYP_Category> ReadCourseCategories(string[] a_lines)
        {
            List<FYP_Category> categoryList = new List<FYP_Category>();
            // Each line except for the first one represents a distinct
            // FYP_Category object. 
            for (int i = 1; i < a_lines.Length; i++)
            {
                // Note: CategoryName is seperated from the courseElements 
                // by "->" symbol. 
                string line = a_lines[i];
                string[] tokens = Regex.Split(line, "->");
                string categoryName = tokens[0];

                // We obtain the list of courseElements from the remaining
                // substring of the line.
                List<FYP_CourseElement> courseList;

                // If the remaining substring is not empty, 
                // read the courseElements and obtain a list of FYP_CourseElements.
                // Else, set the courseList to NULL.
                // NOTE: This is important to handle TOTAL (Credits) type of category
                // that has no CourseElements. 
                if (tokens.Length > 1)
                {
                    string courseElements = tokens[1];
                    courseList = ReadCourseElements(courseElements);
                }
                else
                {
                    courseList = null;
                }

                // Create a new category based on the parsed results and add it to the 
                // categoryList.
                FYP_Category category = new FYP_Category(categoryName, courseList);
                categoryList.Add(category);
            }

            return categoryList;
        }

        /**/
        /*
         *  NAME: 
         *     ReadCourseElements()
         *  
         *  SYNOPSIS:
         *      List<FYP_CourseElement> ReadCourseElements(string a_elementList)
         *          a_elementList --> the substring that holds FYP_CourseElements
         *          
         *  DESCRIPTION:
         *      Obtains the list of FYP_CourseElements from the remaining substring passed
         *      as parameter. 
         *     
         *  RETURNS:
         *      List<FYP_CourseElement> --> List of course elements parsed from the substring
         *      based on the serialization format. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private List<FYP_CourseElement> ReadCourseElements(string a_elementList)
        {
            List<FYP_CourseElement> courseList = new List<FYP_CourseElement>();

            // NOTE: Each courseElement is seperated by a ";" symbol.
            // We split the substring into tokens taking ";" as a delimeter. 
            string[] tokens = Regex.Split(a_elementList, ";");

            // Each token is a courseElement.
            foreach (string token in tokens)
            {
                // Need to consider the case if token is empty.
                if (token != "")
                {
                    // NOTE: The attributes of the FYP_CourseElement are seperated by "-".
                    // So we obtain each attribute by splitting the string based on the delimeter. 
                    string[] courseAttributes = Regex.Split(token, "-");
                    string elementTitle = courseAttributes[0];
                    string elementId = courseAttributes[1];

                    // Create a new courseElement and add it to the list of FYP_CourseElements. 
                    FYP_CourseElement newCourse = new FYP_CourseElement(elementTitle, elementId);
                    courseList.Add(newCourse);
                }
            }
            return courseList;
        }

        /**/
        /*
         *  NAME: 
         *     CreateFolder()
         *  
         *  SYNOPSIS:
         *      void CreateFolder(string a_path)
         *          a_path --> the path where the folder is to be created. 
         *          
         *  DESCRIPTION:
         *      Creates a new folder in the specified path passed as parameter. 
         *     
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private void CreateFolder(string a_path)
        {
            if (!Directory.Exists(a_path))
            {
                Directory.CreateDirectory(a_path);
            }
        }

        /**/
        /*
         *  NAME: 
         *     CreateFYPYearFolder()
         *  
         *  SYNOPSIS:
         *      void CreateFYPYearFolder()
         *          
         *  DESCRIPTION:
         *      Creates a FYPYearFolder in the resources folder based on the academic year
         *      of the Four Year Plans. 
         *     
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private void CreateFYPYearFolder()
        {
            string yearPath = FYP_Year_Path;
            try
            {
                CreateFolder(yearPath);
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not create FYP_Year folder. {0}", e.ToString());
            }
            finally { }
        }

        /**/
        /*
         *  NAME: 
         *     IsDirectoryEmpty()
         *  
         *  SYNOPSIS:
         *      bool IsDirectoryEmpty(string a_dir)
         *          
         *  DESCRIPTION:
         *      Determines if a directory is empty or not. 
         *     
         *  RETURNS:
         *      True --> if the directory is empty. 
         *      False --> if the directory is not empty. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private bool IsDirectoryEmpty(string a_dir)
        {
            return (Directory.GetFiles(a_dir).Length == 0 && Directory.GetDirectories(a_dir).Length == 0);
        }


        /**/
        /*
         *  NAME: 
         *     WriteStudentList()
         *  
         *  SYNOPSIS:
         *      void WriteStudentList(List<Student> a_prepackagedStudents)
         *          
         *  DESCRIPTION:
         *      Writes the output - prepackaged students and their details to a csv file.  
         *      The file is saved in the output folder which has been taken as a user input. 
         *     
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public void WriteStudentList(List<Student> a_prepackagedStudents)
        {
            string fileName = DecnDate.Month.ToString() + "." + DecnDate.Day.ToString() + "." + DecnDate.Year.ToString() + ".csv"; 
            string filepath = OutputDirectoryPath + "\\" + fileName;

            // Using the StreamWriter object to write the string format of the major into the
            // text file. 
            if (!File.Exists(filepath))
            {
                // Store all the information in the stringbuilder object. 
                StringBuilder content = new StringBuilder();
                content.AppendLine(Student.GetHeader());
                foreach (Student s in a_prepackagedStudents)
                {
                    content.AppendLine(s.ToString());
                }
                // Write the contents of the stringbuilder object to a csv file. 
                File.AppendAllText(filepath, content.ToString());
            }
        }
    }
}
