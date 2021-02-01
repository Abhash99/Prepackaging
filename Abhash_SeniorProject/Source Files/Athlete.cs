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
     *     Represents an athlete read from the athlete excel file. 
     *  
     *  PURPOSE: 
     *      To hold RamapoID and sport for each athlete. 
     *      We will match RamapoId of the athlete with Students in the StudentList.
     *      If match is found, we update the student's sport attribute. 
     *      
     *  AUTHOR: 
     *      Abhash Panta
     */
    /**/

    class Athlete
    {
        // Member variables 
        
        // Represents the athlete's unique ID (Ramapo ID)
        // If the athlete is present in the student list, he/she will have the same RamapoId.
        private string m_ramapoId;

        // Represents the name of sport that the athlete is in.
        // NOTE: The spelling and format of the sport is important. 
        private string m_sport;

        /**/
        /*
         *  NAME: Athlete()
         *  
         *  SYNOPSIS:
         *       public Athlete(string a_ramapoId, string a_sport)
         *         a_ramapoId --> athlete's ramapo Id read from the excel file. 
         *         a_sport --> athlete's sport
         *         
         *  DESCRIPTION:
         *      Constructor of Athlete Object. Takes the two attributes as parameters and 
         *      initializes them.
         *  
         *  RETURNS:
         *      Nothing 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public Athlete(string a_ramapoId, string a_sport)
        {
            RamapoId = a_ramapoId;
            Sport = a_sport;
        }

        // Properties for member attributes
        public string RamapoId { get => m_ramapoId; set => m_ramapoId = value; }
        public string Sport { get => m_sport; set => m_sport = value; }
    }
}
