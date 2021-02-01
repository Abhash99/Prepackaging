using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrePackaging
{

    /**/
    /*
     *  CLASS DESCRIPTION:
     *      An abstract class that provides the functionality for parsing excel spreadsheets. 
     *  
     *  PURPOSE:
     *      To provide general functionalities for parsing excel spreadsheet using the Excel DataReader package. 
     *  
     *  AUTHOR: 
     *      Abhash Panta
     */
    /**/
    abstract class ExcelReader
    {
        /**/
        /*
         *  NAME: GetDataTable()
         *  
         *  SYNOPSIS:
         *      DataTable GetDataTable(string a_filename)
         *         a_filename --> The full filepath of the excel file to be parsed. 
         *         
         *  DESCRIPTION:
         *      This function will take the filepath of the excel file to be parsed and will get a datatable object
         *      corresponding to the spreadsheet using the ExcelDataReader package. 
         *  
         *  RETURNS:
         *      The function will return a datatable object that holds the data contained in the excel spreadsheet. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        protected DataTable GetDataTable(string a_filename)
        {
            DataTable dt;

            // Open the excel file to read
            // Using IExcelDataReader to obtain the dataTable
            using (var stream = File.Open(a_filename, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader reader;
                // Reading Excel file
                if (Path.GetExtension(a_filename).ToUpper() == ".XLS")
                {
                    // Reading from a binary Excel file ('97-2003 format; *.xls)
                    reader = ExcelReaderFactory.CreateBinaryReader(stream);
                }
                else
                {
                    // Reading from a OpenXml Excel file (2007 format; *.xlsx)
                    reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                }

                DataSet result = reader.AsDataSet();
                dt = result.Tables[0];
            }

            return dt;
        }



        /**/
        /*
         *  NAME: GetString()
         *  
         *  SYNOPSIS:
         *      string GetString(ref DataTable a_dt, int a_row, int a_column)
         *         a_dt --> the DataTable object that holds the data of the spreadsheet. 
         *         a_row --> the row index of the data to be read.
         *         a_column --> the column index of the data to be read.
         *         
         *  DESCRIPTION:
         *      This function takes the dataTable object, row index and column index to obtain the value at a specific
         *      cell from the dataTable and returns the value as a string. 
         *  
         *  RETURNS:
         *      Returns the value at a particular cell [row][column] as a string. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        protected string GetString(ref DataTable a_dt, int a_row, int a_column)
        {
            return a_dt.Rows[a_row][a_column].ToString();
        }


        /**/
        /*
         *  NAME: ConvertToInt()
         *  
         *  SYNOPSIS:
         *      int ConvertToInt(String a_str)
         *          a_str --> the string that is to be converted into integer. 
         *         
         *  DESCRIPTION:
         *      This function takes a string and converts it into integer. 
         *  
         *  RETURNS:
         *      Returns the integer converted from the string if the conversion is possible. 
         *      Else, it returns -1. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        protected int ConvertToInt(String a_str)
        {
            int val;
            bool success = Int32.TryParse(a_str, out int x);
            if (success)
            {
                val = x;
            }
            else
            {
                val = -1;
            }

            return val;
        }

        /**/
        /*
         *  NAME: ConvertToDouble()
         *  
         *  SYNOPSIS:
         *      double ConvertToDouble(String a_str)
         *         a_str --> the string that is to be converted into integer. 
         *         
         *  DESCRIPTION:
         *      This function takes a string and converts it into double.
         *  
         *  RETURNS:
         *      Returns the double converted from the string if the conversion is possible. 
         *      Else, it returns -1.
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        protected double ConvertToDouble(String a_str)
        {
            double val;
            bool success = Double.TryParse(a_str, out double x);
            if (success)
            {
                val = x;
            }
            else
            {
                val = -1;
            }

            return val;
        }



        /**/
        /*
         *  NAME: ConvertToDate()
         *  
         *  SYNOPSIS:
         *     DateTime ConvertToDate(String a_str)
         *         a_str --> the string that is to be converted into DateTime format. 
         *         
         *  DESCRIPTION:
         *      This function takes a string and converts it into a DateTime object. 
         *  
         *  RETURNS:
         *      Returns the DateTime object converted from the string if the conversion is possible. 
         *      Else, it returns it return the DateTime object with the minimum possible value (DateTime.MinValue).
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        protected DateTime ConvertToDate(String a_str)
        {
            DateTime date;

            if (a_str != "")
            {
                date = DateTime.Parse(a_str);
            }
            else
            {
                date = DateTime.MinValue;
            }

            return date;
        }

    }
}
