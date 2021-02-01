using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/**/
/*
 *  CLASS DESCRIPTION:
 *      The class represents the prepackager which provides an interface to initiate 
 *      aspects of prepackaging process. 
 *  PURPOSE:
 *      This class serves as the link between the front-end user interface and back-end
 *      business logic.
 *      
 *  AUTHOR: 
 *      Abhash Panta
 */
/**/
namespace PrePackaging
{
    class Prepackager
    {
        // Member Variables

        // Represents the academic year for the four-year-plan
        private string m_fypYear;

        // Full path of the course information excel file 
        private string m_courseFilePath;

        // Full path of the student information excel file
        private string m_studentFilePath;

        // The date when student made the enrollment decision
        private DateTime m_decisionDate;

        // Path for the output direcotory (where the output file will be stored)
        private string m_outputDirectoryPath;

        // Path for the athlete information excel file
        private string m_athleteFilePath;

        // Path for the sport information excel file
        private string m_sportFilePath;


        /**/
        /*
         *  NAME: 
         *      Prepackager()
         *  
         *  SYNOPSIS:
         *      Prepackager(string a_year, string a_courseFilePath, string a_studentFilePath, DateTime a_decisionDate, string a_outputDirPath, string a_athletesFilePath, string a_sportsFilePath)
         *          a_year --> academic year
         *          a_courseFilePath --> course excel filepath
         *          a_studentFilePath --> Student excel filepath
         *          a_decisionDate --> Date when student made the enrollment decision
         *          a_outputDirPath --> Path of the output directory
         *          a_athletesFilePath --> athletes excel filepath
         *          a_sportsFilePath --> sports excel filepath
         *         
         *  DESCRIPTION:
         *      Parametrized Constructor of Prepackager Class. Obtains attribute values as parameters and sets respective attributes. 
         *     
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public Prepackager(string a_year, string a_courseFilePath, string a_studentFilePath, DateTime a_decisionDate, string a_outputDirPath, string a_athletesFilePath, string a_sportsFilePath)
        {
            m_fypYear = a_year;
            m_courseFilePath = a_courseFilePath;
            m_studentFilePath = a_studentFilePath;
            m_decisionDate = a_decisionDate;
            m_outputDirectoryPath = a_outputDirPath;
            m_athleteFilePath = a_athletesFilePath;
            m_sportFilePath = a_sportsFilePath;
        }


        // Properties for member variables
        public string CourseFilePath { get => m_courseFilePath; set => m_courseFilePath = value; }
        public string FypYear { get => m_fypYear; set => m_fypYear = value; }
        public string StudentFilePath { get => m_studentFilePath; set => m_studentFilePath = value; }
        public DateTime DecisionDate { get => m_decisionDate; set => m_decisionDate = value; }
        public string OutputDirectoryPath { get => m_outputDirectoryPath; set => m_outputDirectoryPath = value; }
        public string AtheleFilePath { get => m_athleteFilePath; set => m_athleteFilePath = value; }
        public string SportFilePath { get => m_sportFilePath; set => m_sportFilePath = value; }

        /**/
        /*
         *  NAME: 
         *      StartPrepackaging()
         *  
         *  SYNOPSIS:
         *      void StartPrepackaging()
         *         
         *  DESCRIPTION:
         *      Handles all elements of the prepackaging process. 
         *      Gets all necessary inputs from the IOManager class. 
         *      Schedules the students using Scheduler class.
         *      Writes the output to a csv file using IOManager class.  
         *     
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public void StartPrepackaging()
        {
            // Get all necessary inputs using IOManager. 
            IOManager iomanager = new IOManager(FypYear, CourseFilePath, StudentFilePath, OutputDirectoryPath, AtheleFilePath, SportFilePath, DecisionDate);
            
            List<Course> courseList = iomanager.GetCourses();
            List<Student> studentList = iomanager.GetStudents();
            List<Major> majors = iomanager.GetFYPMajors();
            List<Athlete> athletes = iomanager.GetAthletes();
            List<Sport> sports = iomanager.GetSports();

            // Prepackaing students using the Scheduler class. 
            Scheduler scheduler = new Scheduler(courseList, studentList, majors, DecisionDate, athletes, sports);
            List<Student> prepackedStudents = scheduler.StartScheduling();
            
            // Write the prepackaged output to a csv file. 
            iomanager.WriteStudentList(prepackedStudents);
       
            Console.WriteLine("Input succeded.");
            MessageBox.Show("Prepackaging Completed Successfully. Please check the selected output location for output file.");
            
        }
    }
}
