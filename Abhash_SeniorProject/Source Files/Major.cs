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
     *      The class represents the Four-Year Plan for a single major.

     *  PURPOSE:
     *      To represent the FYP for a major by holding the Course Categories and 
     *      the Course elements recommended for the major. 
     *      
     *  AUTHOR: 
     *      Abhash Panta
     */
    /**/
    class Major
    {
        // Member Variables

        // Represents the name of the major
        private string m_name;

        // Represents the unique letter code for each major
        private string m_id;

        // The list of course categories outlined in the four-year plan
        private List<FYP_Category> m_courseCategories;

        /**/
        /*
         *  NAME: 
         *      Major()
         *  
         *  SYNOPSIS:
         *      Major()
         *         
         *  DESCRIPTION:
         *      Default constructor of Major class. Sets all the member
         *      variables to null.
         *     
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public Major()
        {
            Name = null;
            Id = null;
            CourseCategories = null;
        }

        /**/
        /*
         *  NAME: 
         *      Major()
         *  
         *  SYNOPSIS:
         *      Major(string a_name, string a_id, List<FYP_Category> a_courseCategories)
         *          a_name --> the name of the major
         *          a_id --> the unique major code for each major
         *          a_courseCategories --> list of courseCategories recommended for the major
         *         
         *  DESCRIPTION:
         *      Parametrized constructor for Major class. 
         *      
         *     
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public Major(string a_name, string a_id, List<FYP_Category> a_courseCategories)
        {
            Name = a_name;
            Id = a_id;
            CourseCategories = a_courseCategories;
        }

        // Properties for member variables
        public string Name { get => m_name; set => m_name = value; }
        public string Id { get => m_id; set => m_id = value; }
        public List<FYP_Category> CourseCategories { get => m_courseCategories; set => m_courseCategories = value; }



        /**/
        /*
         *  NAME: 
         *      ToString()
         *  
         *  SYNOPSIS:
         *      string ToString()
         *          
         *  DESCRIPTION:
         *      Converts the object into a string for serialization purposes.    
         *     
         *  RETURNS:
         *      A string format that represents the Major object and 
         *      its attributes. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public override string ToString()
        {
            // NOTE: The first line will contain Major Name and Major ID
            // They will be seperated by "->" symbol. 
            string composite = Name + "->" + Id + Environment.NewLine;

            // The rest of the lines will contain the serialized
            // list of FYP_Category objects. 
            // Each line will represent a single FYP_Category object. 
            foreach (FYP_Category category in CourseCategories)
            {
                composite += (category.ToString() + Environment.NewLine);
            }
            return composite;
        }

        /**/
        /*
         *  NAME: 
         *      IsNull()
         *  
         *  SYNOPSIS:
         *      bool IsNull()
         *          
         *  DESCRIPTION:
         *      Determines if the major object is null or not.
         *      If both name and courseCategies are null, the major is considered to be null.
         *     
         *  RETURNS:
         *      True, if the major is null. 
         *      False, if the major is not null. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public bool IsNull()
        {
            if (Name == null && Id == null && CourseCategories == null)
            {
                return true;
            }

            return false;
        }


        /**/
        /*
         *  NAME: 
         *      GetGenEds()
         *  
         *  SYNOPSIS:
         *      List<FYP_Category> GetGenEds()
         *          
         *  DESCRIPTION:
         *      Obtain all the general education categories from the CourseCategories. 
         *     
         *  RETURNS:
         *      List<FYP_Category> --> the list of all general education categories.
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public List<FYP_Category> GetGenEds()
        {
            List<FYP_Category> genEds = new List<FYP_Category>();
            foreach (FYP_Category category in CourseCategories)
            {
                if (category.IsGenEd() == true)
                {
                    genEds.Add(category);
                }
            }
            return genEds;
        }
    }
}
