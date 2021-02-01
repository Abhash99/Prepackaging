using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrePackaging
{
    /**/
    /*
     *  CLASS DESCRIPTION:
     *      A static class that to hold constants representing the column values for Course
     *      Information File. 
     *  
     *  PURPOSE: 
     *      To hold an enum with values corresponding to the column values in the input excel file.
     *      Any changes to the order of columns in the course excel file can be easily reflected in the source code by
     *      changing the values in the enum. 
     *  
     *  NOTE: 
     *      The enum names match with the member variable of the course class so it increases writability
     *      and readability. 
     *  
     *  AUTHOR: 
     *      Abhash Panta
     */
    /**/
    static class CourseExcelConstants
    {
        public enum Columns
        {
            Crn = 0,
            Subj = 1,
            Crse = 2,
            Sect = 3,

            Title = 4,
            CrseTitle = 5,
            Hrs = 9,
            BannerCap = 10,
            Saved = 11,
            MaxCap = 12,

            // Days columns in excel file. CourseReader parses the values and creates a boolean dictionary based on
            // the values for each day. 
            Monday = 13,
            Tuesday = 14,
            Wednesday = 15,
            Thursday = 16,
            Friday = 17,
            Saturday = 18,
            Sunday = 19,

            StartTime = 20,
            EndTime = 21
        }
    }
}
