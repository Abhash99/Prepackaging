using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrePackaging
{
    /**/
    /*
     *  CLASS DESCRIPTION: 
     *      A CourseReader class that inherits from ExcelReader class and contains functionality for
     *      reading course information excel files. 
     *  
     *  PURPOSE: 
     *      To parse the excel file, row by row, reading each column and creating respective Course objects based
     *      on the excel file. 
     *  
     *  AUTHOR: 
     *      Abhash Panta
     */
    /**/
    class CourseReader : ExcelReader
    {
        // Constant Value for the starting row index. (Row index where the actual course information start.)
        private const int START_INDEX = 8;


        /**/
        /*
         *  NAME: ReadCourseList()
         *  
         *  SYNOPSIS:
         *      List<Course> ReadCourseList(string a_filename)
         *         a_filename --> The full filepath of the course information excel file. 
         *         
         *  DESCRIPTION: 
         *      This function will take the course information file name, parse the file, create Course objects 
         *      for each row and return a list of courses.
         *  
         *  RETURNS:
         *      The function returns a list of Course object, which essentially is the list of all unique classes
         *      being offered at Ramapo for a particular semester. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public List<Course> ReadCourseList(string a_filename)
        {
            // Obtain DataTable object using the ExcelReader (base class) method. 
            DataTable dt = GetDataTable(a_filename);

            // Count the total number of rows in the file. 
            int rowCount = dt.Rows.Count;

            List<Course> courseList = new List<Course>();
            // For each row with course information, obtain the Course Object corresponding to the row data.
            // And add the Course to CourseList that is to be returned. 
            for (int row = START_INDEX; row < rowCount; row++)
            {
                Course newCourse = GetCourse(ref dt, row);
                courseList.Add(newCourse);
            }
            return courseList;
        }

        /**/
        /*
         *  NAME: GetCourse()
         *  
         *  SYNOPSIS:
         *      Course GetCourse(ref DataTable a_dt, int a_row)
         *         a_dt --> The dataTable object that contains all the data from excel worksheet. 
         *         a_row --> The row index that is to be parsed. 
         *         
         *  DESCRIPTION: 
         *      This function parses a single row from the course information file. Creates a new Course object based on 
         *      the parsed data and returns it.
         *  
         *  RETURNS:
         *      The function returns a single Course object that corresponds to the row data for the row inndex passed as
         *      a parameter to the function. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private Course GetCourse(ref DataTable a_dt, int a_row)
        {
            // Simply obtain string values for each column in that given row. 
            String Crn = GetString(ref a_dt, a_row, (int)CourseExcelConstants.Columns.Crn);
            String Subj = GetString(ref a_dt, a_row, (int)CourseExcelConstants.Columns.Subj);
            String Crse = GetString(ref a_dt, a_row, (int)CourseExcelConstants.Columns.Crse);
            String Sect = GetString(ref a_dt, a_row, (int)CourseExcelConstants.Columns.Sect);
            String Title = GetString(ref a_dt, a_row, (int)CourseExcelConstants.Columns.Title);
            String CrseTitle = GetString(ref a_dt, a_row, (int)CourseExcelConstants.Columns.CrseTitle);
            String Hrs = GetString(ref a_dt, a_row, (int)CourseExcelConstants.Columns.Hrs);

            String BannerCap = GetString(ref a_dt, a_row, (int)CourseExcelConstants.Columns.BannerCap);
            String Saved = GetString(ref a_dt, a_row, (int)CourseExcelConstants.Columns.Saved);
            String MaxCap = GetString(ref a_dt, a_row, (int)CourseExcelConstants.Columns.MaxCap);

            String startTime = GetString(ref a_dt, a_row, (int)CourseExcelConstants.Columns.StartTime);
            String endTime = GetString(ref a_dt, a_row, (int)CourseExcelConstants.Columns.EndTime);


            // Create a new Course object, convert the attributes to appropriate format
            // and initialize attributes. 
            Course newCourse = new Course
            {
                Crn = ConvertToInt(Crn),
                Subj = Subj.ToLower(),
                Crse = Crse.ToLower(),
                Sect = ConvertToInt(Sect),
                Title = Title.ToLower(),
                CrseTitle = CrseTitle.ToLower(),
                Hrs = ConvertToDouble(Hrs),

                BannerCap = ConvertToInt(BannerCap),
                Saved = ConvertToInt(Saved),
                MaxCap = ConvertToInt(MaxCap),

                Days = ParseDays(ref a_dt, a_row, (int)CourseExcelConstants.Columns.Monday),

                StartTime = ConvertToInt(startTime),
                EndTime = ConvertToInt(endTime)
            };

            
            if (newCourse.BannerCap < 0)
            {
                newCourse.BannerCap = 0;
            }

            if (newCourse.Saved < 0)
            {
                newCourse.Saved = 0;
            }

            if (newCourse.MaxCap < 0)
            {
                newCourse.MaxCap = 0;
            }


            return newCourse;
        }


        /**/
        /*
         *  NAME: ParseDays()
         *  
         *  SYNOPSIS:
         *     Dictionary<char, bool> ParseDays(ref DataTable a_dt, int row, int a_mondayIndex)
         *         a_dt -->  The dataTable object that contains all the data from excel worksheet. 
         *         a_row --> The row index that is to be parsed. 
         *         a_mondayIndex --> The column value corresponding to Monday column in the excel file. 
         *         
         *  DESCRIPTION: 
         *      This function reads the data in the days columns in the excel file and creates a boolean dictionary
         *      based on the data. 
         *  
         *  RETURNS:
         *      Return the dictionary<char, bool> where the key are the days (MTWRFSU) and values are true or false
         *      based on whether the course is scheduled on a certain day or not. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private Dictionary<char, bool> ParseDays(ref DataTable a_dt, int row, int a_mondayIndex)
        {
            Dictionary<char, bool> newDict = new Dictionary<char, bool>();

            // index is the counter for days value (0-6) for seven days. 
            int index = 0;
            while (index < 7)
            {
                // Obtain the value from the day column
                string text = a_dt.Rows[row][a_mondayIndex + index].ToString();

                // For each day column, if the value is "" (empty), set it to false, otherwise set it to true. 
                // Note: Thursday is represented as 'R'. Sunday is represented as 'U'.
                switch (index)
                {
                    case 0:
                        if (text == "")
                        {
                            newDict.Add('M', false);
                        }
                        else
                        {
                            newDict.Add('M', true);
                        }
                        break;
                    case 1:
                        if (text == "")
                        {
                            newDict.Add('T', false);
                        }
                        else
                        {
                            newDict.Add('T', true);
                        }
                        break;
                    case 2:
                        if (text == "")
                        {
                            newDict.Add('W', false);
                        }
                        else
                        {
                            newDict.Add('W', true);
                        }
                        break;
                    case 3:
                        if (text == "")
                        {
                            newDict.Add('R', false);
                        }
                        else
                        {
                            newDict.Add('R', true);
                        }
                        break;
                    case 4:
                        if (text == "")
                        {
                            newDict.Add('F', false);
                        }
                        else
                        {
                            newDict.Add('F', true);
                        }
                        break;
                    case 5:
                        if (text == "")
                        {
                            newDict.Add('S', false);
                        }
                        else
                        {
                            newDict.Add('S', true);
                        }
                        break;
                    case 6:
                        if (text == "")
                        {
                            newDict.Add('U', false);
                        }
                        else
                        {
                            newDict.Add('U', true);
                        }
                        break;
                }

                index++;
            }

            return newDict;
        }


    }
}
