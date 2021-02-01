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
     *      The class represents a time interval of a particular course/sport. 

     *  PURPOSE:
     *      The class holds the startTime, endTime and days for a particular course/sport. 
     *      This will be used to determine time conflicts by the scheduler. 
     *      
     *  AUTHOR: 
     *      Abhash Panta
     */
    /**/
    class Interval
    {

        // Member Variables

        // Represents start time of the interval
        private int m_startTime;

        // Represents end time of the interval
        private int m_endTime;

        // Represents days of the interval
        private string m_days;


        /**/
        /*
         *  NAME: 
         *      Interval()
         *  
         *  SYNOPSIS:
         *      Interval()
         *         
         *  DESCRIPTION:
         *     Default Constructor for Interval class. 
         *     Sets times to -1 and days to empty string.
         *     
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public Interval()
        {
            StartTime = -1;
            EndTime = -1;
            Days = "";
        }

        /**/
        /*
         *  NAME: 
         *      Interval()
         *  
         *  SYNOPSIS:
         *      Interval(int a_startTime, int a_endTime, string a_days)
         *         
         *  DESCRIPTION:
         *      Parametrized constructor for Interval. Takes all the attributes 
         *      as parameters and sets them. 
         *     
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public Interval(int a_startTime, int a_endTime, string a_days)
        {
            StartTime = a_startTime;
            EndTime = a_endTime;
            Days = a_days;
        }


        // Properties for member variables
        public int StartTime { get => m_startTime; set => m_startTime = value; }
        public int EndTime { get => m_endTime; set => m_endTime = value; }
        public string Days { get => m_days; set => m_days = value; }
    }
}
