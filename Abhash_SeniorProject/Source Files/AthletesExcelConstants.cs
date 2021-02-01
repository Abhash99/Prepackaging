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
     *      A static class that to hold constants representing the column values for Athletes Information file. 
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
    static class AthletesExcelConstants
    {
        public enum Columns
        {
            RamapoId = 0,
            Sport = 5
        }
    }
}
