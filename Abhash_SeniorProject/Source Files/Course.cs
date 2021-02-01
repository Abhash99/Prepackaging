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
     *      Represents a unique class offered at Ramapo College. (Each instance has an unique CRN).
     *  
     *  PURPOSE: 
     *      To hold critical information about the course. 
     *  
     *  AUTHOR: 
     *      Abhash Panta
     */
    /**/

    class Course
    {
        // Member Variables (Attributes)
        
        // Represents the unique ID (CRN) of the course. 
        int m_crn;

        // Represents the Subject for the course. Ex. ACCT, INTD, CMPS
        string m_subj;

        // Represents the Course Number. EX. 101, 221, etc. 
        // Needs to be string because there are lab courses like BIOL 111L.
        string m_crse;

        // Represent the section number for the class. 
        int m_sect;

        // Represents secondary title for the course. 
        string m_title;

        // Represents the course title. Ex. Federal Taxation, Corporate Finance, etc. 
        string m_crseTitle;

        // Represents the number of hours for the course (Ex. 4 hrs)
        double m_hrs;

        // Represents the avaiable seats for the course in Banner. 
        int m_bannerCap;

        // Represents the number of saved seats for Freshmen (Prepackaging). 
        int m_saved;

        // Represent maximum number of seats for the course. 
        int m_maxCap;

        // Hold the boolean values representing what days the course is offered on. 
        // True --> the course is offered on that day. 
        // False --> the course is not offered on that day. 
        Dictionary<char, bool> m_days;

        // Represents the start time of the course. (Note: (Format) 7:45pm --> 1945 | 8:15 --> 815)
        int m_startTime;

        // Represents the end time of the course. (Note: (Format) 7:45pm --> 1945 | 8:15 --> 815)
        int m_endTime;

        int m_scheduledStudents;
        
        
        // Properties (Accessor/Mutators) for member variables listed above.
        public int Crn { get => m_crn; set => m_crn = value; }
        public string Subj { get => m_subj; set => m_subj = value; }
        public string Crse { get => m_crse; set => m_crse = value; }

        public int Sect { get => m_sect; set => m_sect = value; }
        public string Title { get => m_title; set => m_title = value; }
        public string CrseTitle { get => m_crseTitle; set => m_crseTitle = value; }
        public double Hrs { get => m_hrs; set => m_hrs = value; }

        public int BannerCap { get => m_bannerCap; set => m_bannerCap = value; }
        public int Saved { get => m_saved; set => m_saved = value; }
        public int MaxCap { get => m_maxCap; set => m_maxCap = value; }

        public Dictionary<char, bool> Days { get => m_days; set => m_days = value; }
        public int StartTime { get => m_startTime; set => m_startTime = value; }
        public int EndTime { get => m_endTime; set => m_endTime = value; }
        public int ScheduledStudents { get => m_scheduledStudents; set => m_scheduledStudents = value; }



        /**/
        /*
         *  NAME: GetDaysString()
         *  
         *  SYNOPSIS:
         *      string GetDaysString()
         *         
         *  DESCRIPTION:
         *      This function computes the day string related to the course. 
         *      Since days are stored as a dictionary, we need this function to easily obtain the day string. 
         *      Example of daystring: mr, mwr, tf. etc. 
         *  
         *  RETURNS:
         *      The function returns a string that represents the days for the course.
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public string GetDaysString()
        {
            string dayString = "";

            // If the value for a key is true, add the key to the string.
            foreach (KeyValuePair<char,bool> item in Days)
            {
                if (item.Value == true)
                {
                    dayString += item.Key;
                }
            }

            return dayString.ToLower();
        }


        /**/
        /*
         *  NAME: GetDayTime()
         *  
         *  SYNOPSIS:
         *      string GetDayTime()
         *         
         *  DESCRIPTION:
         *      This function generates the days and time related to a specific course. 
         *      Example: "mr: 1805 - 2135", "mr: 830 - 950", "tf: 1120 - 1300"
         *      Note: The times are in military format. 
         *      
         *  RETURNS:
         *      The function returns a string that represents the days and time for the course. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public string GetDayTime()
        {
            string dayTime = "";
            // Obtain the days string.
            dayTime += GetDaysString();
            dayTime += ": ";
            // Add startTime and endTime to the string.
            dayTime += StartTime + "-" + EndTime;
            return dayTime;
        }

    }
}
