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
     *      The class that represents a individual course element. (Ex. CMPS 364, PHIL 101, MATH 101, etc.)

     *  PURPOSE:
     *      The class holds the title (ex. MATH) and id (ex. 101) for each course element.
     *      The FYP_CourseElement object will be contained in the FYP_Category and will ultimately
     *      be a part of the Major Class. 
     *      
     *  AUTHOR: 
     *      Abhash Panta
     */
    /**/
    class FYP_CourseElement
    {
        // Member Variables
        
        // Represents the course subject (Ex. INTD, CMPS, etc.)
        private string m_title;

        // Represents course id (Ex. 101, 267, etc.)
        // Using string type because the id might contain letter (Ex. 214L - for lab courses)
        private string m_id;

        /**/
        /*
         *  NAME: 
         *      FYP_CourseElement()
         *  
         *  SYNOPSIS:
         *      FYP_CourseElement()
         *         
         *  DESCRIPTION:
         *     Default Constructor for FYP_CourseElement class. 
         *     Sets all attributes to null. 
         *     
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public FYP_CourseElement()
        {
            Title = null;
            Id = null;
        }

        /**/
        /*
         *  NAME: 
         *      FYP_Category()
         *  
         *  SYNOPSIS:
         *      FYP_CourseElement(string a_title, string a_id)
         *          a_title --> the title of the course (ex. CMPS, MATH)
         *          a_id --> the id of the course (ex. 101, 237)
         *         
         *  DESCRIPTION:
         *      Parametrized constructor for FYP_CourseElement class. 
         *      
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public FYP_CourseElement(string a_title, string a_id)
        {
            Title = a_title;
            Id = a_id;
        }

        // Properties for Member Variables
        public string Title { get => m_title; set => m_title = value; }
        public string Id { get => m_id; set => m_id = value; }


        /**/
        /*
         *  NAME:  
         *      ToString()
         *  
         *  SYNOPSIS:
         *      string ToString()
         *      
         *         
         *  DESCRIPTION:
         *      Converts the object into a string for serialization purposes.
         *      
         *  RETURNS:
         *      A string format that represents the FYP_CourseElement object and 
         *      its attributes. 
         *     
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public override string ToString()
        {
            // Note the delimeter that seperates title and id is "-".
            // This will be needed for serialization (parsing). 
            return Title + "-" + Id;
        }
    }
}
