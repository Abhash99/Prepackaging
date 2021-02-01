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
     *      The AthleteReader class that inherits from ExcelReader class and contains functionality for
     *      reading athletes information excel files. 
     *  
     *  PURPOSE: 
     *      To parse the excel file, row by row, reading each column and creating respective Athlete objects. 
     *  
     *  AUTHOR: 
     *      Abhash Panta
     */
    /**/
    class AthleteReader : ExcelReader
    {
        // Constant Value for the starting row index. (Row index where the actual athletes information start.)
        private const int START_INDEX = 1;

        /**/
        /*
         *  NAME:
         *      ReadAthletesList()
         *  
         *  SYNOPSIS:
         *      List<Athlete> ReadAthletesList(string a_filename)
         *         a_filename --> The full filepath of the athletes information excel file. 
         *         
         *  DESCRIPTION: 
         *      This function will take the athletes information file name, parse the file, create Athlete objects 
         *      for each row and return a list of athletes.
         *  
         *  RETURNS:
         *      List<Athlete> --> The function returns a list of Athlete objects that are present in the excel file.
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public List<Athlete> ReadAthletesList(string a_filename)
        {
            // Obtain DataTable object using the ExcelReader (base class) method. 
            DataTable dt = GetDataTable(a_filename);

            // Obtain the number of rows in the spreadsheet.
            int rowCount = dt.Rows.Count;

            // Obtain an athlete from each row in the file and add it to the list. 
            List<Athlete> athletes = new List<Athlete>();
            for (int row = START_INDEX; row < rowCount; row++)
            {
                Athlete athlete = GetAthlete(ref dt, row);
                athletes.Add(athlete);
            }

            return athletes;
        }

        /**/
        /*
         *  NAME: 
         *      GetAthlete()
         *  
         *  SYNOPSIS:
         *      Athlete GetAthlete(ref DataTable a_dt, int a_row)
         *         a_dt --> The dataTable object that contains all the data from excel worksheet. 
         *         a_row --> The row index that is to be parsed. 
         *         
         *  DESCRIPTION: 
         *      This function reads the required attributes from the athletes information excel file and 
         *      creates an athletes object. 
         *  
         *  RETURNS:
         *      The function returns an Athlete object corresponding to the row in excel file. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private Athlete GetAthlete(ref DataTable a_dt, int a_row)
        {
            string ramapoId = GetString(ref a_dt, a_row, (int)AthletesExcelConstants.Columns.RamapoId).ToLower();
            string sport = GetString(ref a_dt, a_row, (int)AthletesExcelConstants.Columns.Sport).ToLower();
            Athlete newAthlete = new Athlete(ramapoId, sport);
            return newAthlete;
        }

    }
}
