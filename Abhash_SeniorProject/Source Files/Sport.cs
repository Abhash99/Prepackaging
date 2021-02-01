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
     *     Represents a sport read from the sports information file.
     *  PURPOSE: 
     *      Holds the sport (name) and the practice times as intervals. 
     *      
     *  AUTHOR: 
     *      Abhash Panta
     */
    /**/
    class Sport
    {
        // Member variables

        // Represents the name of the sport (Ex. Men's Soccer)
        private string m_name;

        // Represents the list of practice times (as an interval object) for the sport
        private List<Interval> m_intervals;

        /**/
        /*
         *  NAME: Sport()
         *  
         *  SYNOPSIS:
         *       Sport()
         *         
         *  DESCRIPTION:
         *      Default constructor of the sport class. 
         *      Sets name to empty string and intervals to null.
         * 
         *  RETURNS:
         *      Nothing 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public Sport()
        {
            Name = "";
            Intervals = null;
        }

        /**/
        /*
         *  NAME: Sport()
         *  
         *  SYNOPSIS:
         *       Sport(string a_name, List<Interval> a_intervalList)
         *          a_name --> name of the sport
         *          a_intervalList --> list of intervals (each of which represent a practive time slot for the sport. 
         *         
         *  DESCRIPTION:
         *      Parametrized constructor for Sport class. It obtains attribute values as parameters and sets each attribute
         *      respectively. 
         * 
         *  RETURNS:
         *      Nothing 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public Sport(string a_name, List<Interval> a_intervalList)
        {
            Name = a_name;
            Intervals = a_intervalList;
        }

        // Properties for member variables
        public string Name { get => m_name; set => m_name = value; }
        public List<Interval> Intervals { get => m_intervals; set => m_intervals = value; }


        /**/
        /*
         *  NAME: IsNull()
         *  
         *  SYNOPSIS:
         *       bool IsNull()
         *         
         *  DESCRIPTION:
         *      Determines if the Sport is a null sport (no value).
         *      If the name is empty string and intervals is null, it is a null sport.
         *      
         *  RETURNS:
         *      True, if the sport is null. 
         *      False, otherwise. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public bool IsNull()
        {
            if (Name == "" && Intervals == null)
            {
                return true;
            }
            return false;
        }
    }
}
