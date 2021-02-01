using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PrePackaging
{
    /**/
    /*
     *  CLASS DESCRIPTION: 
     *      A StudentReader class that inherits from ExcelReader class and contains functionality for
     *      reading student information from excel file.
     *  
     *  PURPOSE: 
     *      To parse the excel file, row by row, reading each column and creating respective Student object based on
     *      the excel file. 
     *  
     *  AUTHOR: 
     *      Abhash Panta
     */
    /**/
    class StudentReader : ExcelReader
    {
        // Constant Value for the starting row index. (Row index where the actual course information start.)
        private const int START_INDEX = 1;

        /**/
        /*
         *  NAME:  ReadStudentList()
         *  
         *  SYNOPSIS:
         *      List<Student> ReadStudentList(string a_filename)
         *         a_filename --> The full filepath of the student information excel file. 
         *         
         *  DESCRIPTION: 
         *      This function will take the student information file name, parse the file, create Student object 
         *      for each row and return a list of Students. 
         *  
         *  RETURNS:
         *      The function returns a list of all Student objects that are represented in the Student Information
         *      Excel File. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public List<Student> ReadStudentList(string a_filename)
        {
            // Obtain DataTable object using the ExcelReader (base class) method. 
            DataTable dt = GetDataTable(a_filename);

            // Obtain the number of rows in the spreadsheet.
            int rowCount = dt.Rows.Count;

            List<Student> studentList = new List<Student>();
            
            // For each row in the spreadsheet, parse the row, 
            // Create a new Student object for each row and 
            // add it to the studentList.s
            for (int row = START_INDEX; row < rowCount; row++)
            {
                Student student = GetStudent(ref dt, row);
                studentList.Add(student);
            }

            return studentList;
        }

        /**/
        /*
         *  NAME: GetStudent()
         *  
         *  SYNOPSIS:
         *      Student GetStudent(ref DataTable a_dt, int a_row)
         *         a_dt --> The dataTable object that contains all the data from excel worksheet. 
         *         a_row --> The row index that is to be parsed. 
         *         
         *  DESCRIPTION: 
         *      This function parses a single row from the excel file, and create a new Student object and 
         *      set its attributes based on the data read from the row. 
         *  
         *  RETURNS:
         *      A Student object that represents the particular row in the excel file.   
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private Student GetStudent(ref DataTable a_dt, int a_row)
        {
            // Obtain each column value as string from the excel file. 
            string term = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.Term);
            string lastName = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.LastName);
            string firstName = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.FirstName);
            string middleInitial = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.MiddleInitial);
            string ramapoId = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.RamapoId);

            string enrld = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.Enrld);
            string termEnrldHours = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.TermEnrldHours);
            string termTrnsHours = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.TermTrnsHours);
            string studentType = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.StudentType);
            string admitType = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.AdmitType);

            string admitSchool = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.AdmitSchool);
            string admitMajor = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.AdmitMajor);
            string admitConcentration = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.AdmitConcentration);
            string admitMajorDesc = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.AdmitMajorDesc);
            string admitConcentrationDesc = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.AdmitConcentrationDesc);

            string dcsnDate = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.DcsnDate);
            string scholarship_1 = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.Scholarship_1);
            string scholarship_2 = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.Scholarship_2);
            string honors = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.Honors);
            string eof = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.Eof);
            string sport = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.Sport);

            string rcnjEmail = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.RcnjEmail);
            string phone = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.Phone);

            string housingDeposit = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.HousingDeposit);
            string housing = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.Housing);
            string rsvp_orientation = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.Rsvp_orientation);
            string orientation = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.Orientation);
            string orientDate = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.OrientDate);

            // Get the TestingInfo object for Student.
            TestingInfo testInfo = GetTestingInfo(ref a_dt, a_row);

            // Get the CreditInfor object for the Student.
            CreditInfo creditInfo = GetCreditInfo(ref a_dt, a_row);

            // Create a new Student object and set all the 
            // attributes based on data obtained above.
            // Also, convert each attribute to necessary format. 
            Student newStudent = new Student
            {
                Term = ConvertToInt(term),
                FirstName = firstName,
                LastName = lastName,
                MiddleInitial = middleInitial,
                RamapoId = ramapoId.ToLower(),

                // Use of ternary operator to determine the boolean value. 
                Enrld = (enrld.ToLower() == "y") ? true : false,
                TermEnrldHours = ConvertToInt(termEnrldHours),
                TermTrnsHours = ConvertToInt(termTrnsHours),

                StudentType = studentType.ToLower(),
                AdmitType = admitType.ToLower(),
                AdmitSchool = admitSchool.ToLower(),
                AdmitMajor = admitMajor.ToLower(),
                AdmitConcentration = admitConcentration.ToLower(),
                AdmitMajorDesc = admitMajorDesc.ToLower(),
                AdmitConcentrationDesc = admitConcentrationDesc.ToLower(),

                DcsnDate = ConvertToDate(dcsnDate),
                Scholarship_1 = scholarship_1.ToLower(),
                Scholarship_2 = scholarship_2.ToLower(),

                // Use of ternary operator to determine the boolean value.
                Honors = (honors.ToLower() == "y") ? true : false,
                Eof = (eof.ToLower() == "y") ? true : false,
                Sport = sport.ToLower(),

                RncjEmail = rcnjEmail,
                Phone = phone,

                // Use of ternary operator to determine the boolean value.
                HousingDeposit = (housingDeposit.ToLower() == "y") ? true : false,
                Housing = (housing.ToLower() == "y") ? true : false,
                Rsvp_orientation = (rsvp_orientation.ToLower() == "y") ? true : false,
                Orientation = orientation.ToLower(),
                OrientDate = ConvertToDate(orientDate),
                TestInfo = testInfo,
                CreditInfo = creditInfo
            };

            return newStudent;
        }


        /**/
        /*
         *  NAME: GetTestingInfo()
         *  
         *  SYNOPSIS:
         *      TestingInfo GetTestingInfo(ref DataTable a_dt, int a_row)
         *         a_dt --> The dataTable object that contains all the data from excel worksheet. 
         *         a_row --> The row index that is to be parsed. 
         *         
         *  DESCRIPTION: 
         *      This function parses the testing information of the student from the row and 
         *      creates a new TestingInfo object that holds the data.
         *  
         *  RETURNS:
         *      A TestingInfo object that contains all the test information related to the student.
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private TestingInfo GetTestingInfo(ref DataTable a_dt, int a_row)
        {
            // Obtain SAT/ACT Scores as strings
            string SAT_RW = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.SAT_RW);
            string SAT_Math = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.SAT_Math);
            string SAT_Total = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.SAT_Total);
            string ACT_Composite = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.ACT_Composite);

            // Obtain ACCUPLACER Scores/Dates as strings. 
            string ACU_Read = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.ACU_Read);
            string ACU_ReadDate = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.ACU_ReadDate);
            string ACU_Writing = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.ACU_Writing);
            string ACU_WritingDate = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.ACU_WritingDate);
            string ACU_Arith = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.ACU_Arith);
            string ACU_ArithDate = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.ACU_ArithDate);
            string ACU_Quant = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.ACU_Quant);
            string ACU_QuantDate = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.ACU_QuantDate);
            string ACU_AdvAlg = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.ACU_AdvAlg);
            string ACU_AdvAlgDate = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.ACU_AdvAlgDate);
            string ACU_Essay = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.ACU_Essay);
            string ACU_EssayDate = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.ACU_EssayDate);

            // Obtain information on Required Tests and Retest Info. 
            string CalcRequired = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.CalcRequired);
            string MathTestType = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.MathTestType);
            string ReadingTestType = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.ReadingTestType);
            string MathRetest = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.MathRetest);
            string CalcRetest = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.CalcRetest);
            string ReadingRetest = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.ReadingRetest);


            // Create a TestingInfo object and initialize all the attributes 
            // based on the data collected above. 
            // Convert each attribute to appropriate datatype. 
            TestingInfo testInfo = new TestingInfo
            {
                SAT_RW = ConvertToInt(SAT_RW),
                SAT_Math = ConvertToInt(SAT_Math),
                SAT_Total = ConvertToInt(SAT_Total),
                ACT_Composite = ConvertToInt(ACT_Composite),

                ACU_Read = ConvertToInt(ACU_Read),
                ACU_ReadDate = ConvertToDate(ACU_ReadDate),
                ACU_Writing = ConvertToInt(ACU_Writing),
                ACU_WritingDate = ConvertToDate(ACU_WritingDate),
                ACU_Arith = ConvertToInt(ACU_Arith),
                ACU_ArithDate = ConvertToDate(ACU_ArithDate),
                ACU_Quant = ConvertToInt(ACU_Quant),
                ACU_QuantDate = ConvertToDate(ACU_QuantDate),
                ACU_AdvAlg = ConvertToInt(ACU_AdvAlg),
                ACU_AdvAlgDate = ConvertToDate(ACU_AdvAlgDate),
                ACU_Essay = ConvertToInt(ACU_Essay),
                ACU_EssayDate = ConvertToDate(ACU_EssayDate),

                CalcRequired = (CalcRequired.ToLower() == "y") ? true : false,
                MathTestType = MathTestType.ToLower(),
                ReadingTestType = ReadingTestType.ToLower(),
                MathRetest = MathRetest.ToLower(),
                CalcRetest = CalcRetest.ToLower(),
                ReadingRetest = ReadingRetest.ToLower()
            };

            return testInfo;
        }

        /**/
        /*
         *  NAME: GetCreditInfo()
         *  
         *  SYNOPSIS:
         *      CreditInfo GetCreditInfo(ref DataTable a_dt, int a_row)
         *         a_dt --> The dataTable object that contains all the data from excel worksheet. 
         *         a_row --> The row index that is to be parsed. 
         *         
         *  DESCRIPTION: 
         *      This function parses the credit information of the student from the row and 
         *      creates a new CreditInfo object that holds the data.
         *  
         *  RETURNS:
         *      A CreditInfo object that contains all the credit information related to the student.
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private CreditInfo GetCreditInfo(ref DataTable a_dt, int a_row)
        {
            // Parse the credit related data from the row and create a corresponding CreditInfo Object. 
            string takenSummerCourses = GetString(ref a_dt, a_row, (int)StudentExcelConstants.Columns.TakenSummerCourses).ToLower();
            List<string> summerCourses = GetSummerCourseList(ref a_dt, a_row);
            List<string> rcnjCourses = GetRCNJCourses(ref a_dt, a_row);
            List<string> apCourses = GetAPCourses(ref a_dt, a_row);
            List<string> nonApCourses = GetNonAPCourses(ref a_dt, a_row);

            CreditInfo creditInfo = new CreditInfo()
            {
                TakenSummerRCCourses = (takenSummerCourses == "y") ? true : false,
                SummerCourses = summerCourses,
                RcnjCourses = rcnjCourses,
                APCourses = apCourses,
                NonAPCourses = nonApCourses
            };

            return creditInfo;
        }

        /**/
        /*
         *  NAME: 
         *      GetSummerCourseList()
         *  
         *  SYNOPSIS:
         *      List<string> GetSummerCourseList(ref DataTable a_dt, int a_row)
         *         a_dt --> The dataTable object that contains all the data from excel worksheet. 
         *         a_row --> The row index that is to be parsed. 
         *         
         *  DESCRIPTION: 
         *      This function reads the students summer courses (credits) from the excel file. If they exists, 
         *      it adds to a list of string an returns it. 
         *  
         *  RETURNS:
         *      List<string> --> Contains summer courses taken by the student. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private List<string> GetSummerCourseList(ref DataTable a_dt, int a_row)
        {
            List<string> courseList = new List<string>();
            for (int i = (int)StudentExcelConstants.Columns.SummerCoursesStart; i <= (int)StudentExcelConstants.Columns.SummerCoursesEnd; i++)
            {
                // Get string from the column. 
                string value = GetString(ref a_dt, a_row, i).ToLower();
                
                if (value != "")
                {
                    // We need to split the value into courseName (ex. CMPS) and courseId (ex. 147) from the string.
                    string[] tokens = Regex.Split(value, " ");

                    // Join the splitted values using "-" as the delimeter and add the formatted value to the courseList. 
                    string formattedValue = tokens[0] + "-" + tokens[1];

                    courseList.Add(formattedValue);
                }
            }

            return courseList;
        }



        /**/
        /*
         *  NAME: 
         *      GetRCNJCourses()
         *  
         *  SYNOPSIS:
         *      List<string> GetRCNJCourses(ref DataTable a_dt, int a_row)
         *         a_dt --> The dataTable object that contains all the data from excel worksheet. 
         *         a_row --> The row index that is to be parsed. 
         *         
         *  DESCRIPTION: 
         *      This function reads the students RCNJ courses (credits) from the excel file. If they exists, 
         *      it adds to a list of string an returns it. 
         *  
         *  RETURNS:
         *      List<string> --> Contains RCNJ courses taken by the student. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private List<string> GetRCNJCourses(ref DataTable a_dt, int a_row)
        {
            List<string> courseList = new List<string>();
            for (int i = (int)StudentExcelConstants.Columns.RCNJCoursesStart; i <= (int)StudentExcelConstants.Columns.RCNJCoursesEnd; i++)
            {
                // Get string from the column. 
                string value = GetString(ref a_dt, a_row, i).ToLower();
                if (value != "")
                {
                    // We need to split the value into courseName (ex. CMPS) and courseId (ex. 147) from the string.
                    string[] tokens = Regex.Split(value, " ");

                    // Join the splitted values using "-" as the delimeter and add the formatted value to the courseList. 
                    string formattedValue = tokens[0] + "-" + tokens[1];

                    courseList.Add(formattedValue);
                }
            }

            return courseList;
        }


        /**/
        /*
         *  NAME: 
         *      GetAPCourses()
         *  
         *  SYNOPSIS:
         *      List<string> GetAPCourses(ref DataTable a_dt, int a_row)
         *         a_dt --> The dataTable object that contains all the data from excel worksheet. 
         *         a_row --> The row index that is to be parsed. 
         *         
         *  DESCRIPTION: 
         *      This function reads the students AP credits from the excel file. If they exists, 
         *      it adds to a list of string an returns it. 
         *  
         *  RETURNS:
         *      List<string> --> Contains AP credits that the student has. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private List<string> GetAPCourses(ref DataTable a_dt, int a_row)
        {
            List<string> courseList = new List<string>();
            for (int i = (int)StudentExcelConstants.Columns.APCoursesStart; i <= (int)StudentExcelConstants.Columns.APCoursesEnd; i++)
            {
                // Get string from the column. 
                string value = GetString(ref a_dt, a_row, i).ToLower();
                if (value != "")
                {
                    // We need to split the value into courseName (ex. CMPS) and courseId (ex. 147) from the string.
                    string[] tokens = Regex.Split(value, " ");

                    // Join the splitted values using "-" as the delimeter and add the formatted value to the courseList. 
                    string formattedValue = tokens[0] + "-" + tokens[1];

                    courseList.Add(formattedValue);
                }
            }

            return courseList;
        }


        /**/
        /*
         *  NAME: 
         *      GetNonAPCourses()
         *  
         *  SYNOPSIS:
         *      List<string> GetNonAPCourses(ref DataTable a_dt, int a_row)
         *         a_dt --> The dataTable object that contains all the data from excel worksheet. 
         *         a_row --> The row index that is to be parsed. 
         *         
         *  DESCRIPTION: 
         *      This function reads the students Non-AP credits from the excel file. If they exists, 
         *      it adds to a list of string an returns it. 
         *  
         *  RETURNS:
         *      List<string> --> Contains Non-AP credits that the student has. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private List<string> GetNonAPCourses(ref DataTable a_dt, int a_row)
        {
            List<string> courseList = new List<string>();
            for (int i = (int)StudentExcelConstants.Columns.NonAPCoursesStart; i <= (int)StudentExcelConstants.Columns.NonAPCoursesEnd; i++)
            {
                // Get string from the column. 
                string value = GetString(ref a_dt, a_row, i).ToLower();
                if (value != "")
                {
                    // We need to split the value into courseName (ex. CMPS) and courseId (ex. 147) from the string.
                    string[] tokens = Regex.Split(value, " ");

                    // Join the splitted values using "-" as the delimeter and add the formatted value to the courseList. 
                    string formattedValue = tokens[0] + "-" + tokens[1];

                    courseList.Add(formattedValue);
                }
            }

            return courseList;

        }
    }
}
