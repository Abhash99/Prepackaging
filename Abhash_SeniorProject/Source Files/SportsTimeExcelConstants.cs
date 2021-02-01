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
     *      A static class that to hold constants representing the column values for Sports Information File.
     *  
     *  PURPOSE: 
     *      To hold an enum with values corresponding to the column values in the input excel file.
     *      Any changes to the order of columns in the course excel file can be easily reflected in the source code by
     *      changing the values in the enum. 
     *  
     *  AUTHOR: 
     *      Abhash Panta
     */
    /**/
    static class SportsTimeExcelConstants
    {
        public enum Columns
        {
            Sport = 0,
            Day1 = 1,
            Time1 = 2,
            Day2 = 3,
            Time2 = 4,
            Day3 = 5,
            Time3 = 6,
            Day4 = 7,
            Time4 = 8
        }
    }
}
