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
     *      A SportTimeReader class that inherits from ExcelReader class and contains functionality for
     *      reading sports information excel files. 
     *  
     *  PURPOSE: 
     *      To parse the excel file, row by row, reading each column and creating respective Sport objects.
     *  
     *  AUTHOR: 
     *      Abhash Panta
     */
    /**/
    class SportsTimeReader : ExcelReader
    {
        // Constant Value for the starting row index. (Row index where the actual athletes information start.)
        private const int START_INDEX = 1;


        /**/
        /*
         *  NAME: 
         *      GetSportsList()
         *  
         *  SYNOPSIS:
         *      List<Sport> GetSportsList(string a_filename)
         *         a_filename --> The full filepath of the sports information excel file. 
         *         
         *  DESCRIPTION: 
         *      This function will take the sports information file name, parse the file, create sports objects 
         *      for each row and return a list of sports.
         *  
         *  RETURNS:
         *      List<Sport> --> The function returns a list of sports objects that are present in the excel file.
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public List<Sport> GetSportsList(string a_filename)
        {
            // Obtain DataTable object using the ExcelReader (base class) method. 
            DataTable dt = GetDataTable(a_filename);

            // Obtain the number of rows in the spreadsheet.
            int rowCount = dt.Rows.Count;

            List<Sport> sports = new List<Sport>();
            // Obtain each sport object corresponding to each row and add it to the list. 
            for (int row = START_INDEX; row < rowCount; row++)
            {
                Sport sport = GetSport(ref dt, row);
                sports.Add(sport);
            }

            return sports;
        }

        /**/
        /*
         *  NAME: 
         *      GetSport()
         *  
         *  SYNOPSIS:
         *      Sport GetSport(ref DataTable a_dt, int a_row)
         *         a_dt --> The dataTable object that contains all the data from excel worksheet. 
         *         a_row --> The row index that is to be parsed. 
         *         
         *  DESCRIPTION: 
         *      This function reads the required attributes from the row and creates a sport object
         *      based on the data that is read. 
         *  
         *  RETURNS:
         *      Sport --> An sport object corresponding to the row in the excel file. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private Sport GetSport(ref DataTable a_dt, int a_row)
        {
            // Obtain each column data for the row as string. 
            string sportName = GetString(ref a_dt, a_row, (int)SportsTimeExcelConstants.Columns.Sport).ToLower();
            string day1 = GetString(ref a_dt, a_row, (int)SportsTimeExcelConstants.Columns.Day1).ToLower();
            string day2 = GetString(ref a_dt, a_row, (int)SportsTimeExcelConstants.Columns.Day2).ToLower();
            string day3 = GetString(ref a_dt, a_row, (int)SportsTimeExcelConstants.Columns.Day3).ToLower();
            string day4 = GetString(ref a_dt, a_row, (int)SportsTimeExcelConstants.Columns.Day4).ToLower();

            string time1 = GetString(ref a_dt, a_row, (int)SportsTimeExcelConstants.Columns.Time1).ToLower();
            string time2 = GetString(ref a_dt, a_row, (int)SportsTimeExcelConstants.Columns.Time2).ToLower();
            string time3 = GetString(ref a_dt, a_row, (int)SportsTimeExcelConstants.Columns.Time3).ToLower();
            string time4 = GetString(ref a_dt, a_row, (int)SportsTimeExcelConstants.Columns.Time4).ToLower();

            List<Interval> intervalList = new List<Interval>();
            
            // Need to validate empty strings that might be present. 
            // So, day and time values are not empty, create an interval and add it to the interval list. 
            if (day1 != "" && time1 != "")
            {
                Interval i = GetInterval(day1, time1);
                intervalList.Add(i);
            }
           
            if (day2 != "" && time2 != "")
            {
                Interval i = GetInterval(day2, time2);
                intervalList.Add(i);
            }
           
            if (day3 != "" && time3 != "")
            {
                Interval i = GetInterval(day3, time3);
                intervalList.Add(i);
            }
           
            if (day4 != "" && time4 != "")
            {
                Interval i = GetInterval(day4, time4);
                intervalList.Add(i);
            }

            // Create a new sport object and return it. 
            Sport newSport = new Sport(sportName, intervalList);
            return newSport;
        }

        /**/
        /*
         *  NAME: 
         *      GetInterval()
         *  
         *  SYNOPSIS:
         *      Interval GetInterval(string a_days, string a_time)
         *          a_days --> the day string related to the particular practice time. (ex. mr, mtwr, etc.)
         *          a_time --> time string related to particular pratice time slot. (ex. 1400-1900)
         *         
         *  DESCRIPTION: 
         *      This function takes the days string and time string as a parameters and creates an interval object
         *      based on the parameters.
         *  
         *  RETURNS:
         *      Interval --> An interval object that represents the day/time for a practice time slot. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private Interval GetInterval(string a_days, string a_time)
        {
            // We need to split the time string into startTime and endTime. 
            // The delimeter used is "-"
            string[] tokens = Regex.Split(a_time, "-");

            // We convert the data into required format (int)
            int startTime = ConvertToInt(tokens[0]);
            int endTime = ConvertToInt(tokens[1]);

            // Create a new interval object from the data and return it. 
            Interval interval = new Interval()
            {
                Days = a_days.ToLower(),
                StartTime = startTime,
                EndTime = endTime
            };

            return interval;
        }



    }
}
