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
     *      Represents the credit information related to a particular student.
     *  
     *  PURPOSE:
     *      Holds all the credits related data for a particular student. 
     *      Used to encapsulate similar attributes (Credits Data) for better readability. 
     *  
     *  AUTHOR: 
     *      Abhash Panta
     */
    /**/
    class CreditInfo
    {
        // Member Variables

        // Determines if the student has taken summer courses or not. 
        bool m_takenSummerRCCourses;

        // Represents a list of summer courses taken by the student. 
        List<string> m_summerCourses;

        // Represents a list of RCNJ courses that the student has taken. 
        List<string> m_rcnjCourses;

        // Represents a list of AP course credits that the student has. 
        List<string> m_APCourses;

        // Represents a list of Non_AP course credits that the student has. 
        List<string> m_nonAPCourses;


        // Properties for member variables
        public bool TakenSummerRCCourses { get => m_takenSummerRCCourses; set => m_takenSummerRCCourses = value; }
        public List<string> SummerCourses { get => m_summerCourses; set => m_summerCourses = value; }
        public List<string> RcnjCourses { get => m_rcnjCourses; set => m_rcnjCourses = value; }
        public List<string> APCourses { get => m_APCourses; set => m_APCourses = value; }
        public List<string> NonAPCourses { get => m_nonAPCourses; set => m_nonAPCourses = value; }
    }
}
