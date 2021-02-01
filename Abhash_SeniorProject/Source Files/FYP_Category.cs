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
     *      The class that represents a category of courses.
     *      The category could be a representative of a single course. Ex. Critical Reading and Writing II
     *      The category could be a representative of multiple courses. Ex. Gen Ed. Social Science Inquiry
     *  
     *  PURPOSE:
     *      Provides a generalized object to represent each category in the four-year plan. 
     *      Contains the list of course elements, which are actual courses. (Ex. MATH 101)
     *      For a single course (like. MATH 101), the list will have only one element.
     *      For a category of courses (like Gen Ed. courses), the list will have multiple courses. 
     *      
     *  AUTHOR: 
     *      Abhash Panta
     */
    /**/
    class FYP_Category
    {
        // Represents the name of the category
        private string m_categoryName;
        
        // Holds the list of courses
        // Ex. A list for Gen Ed: Math category might have MATH 101, MATH 110, MATH 121, etc. 
        private List<FYP_CourseElement> m_courseList;
        
        // Properties for member variables
        public string Name { get => m_categoryName; set => m_categoryName = value; }
        public List<FYP_CourseElement> CourseList { get => m_courseList; set => m_courseList = value; }

        /**/
        /*
         *  NAME: 
         *      FYP_Category()
         *  
         *  SYNOPSIS:
         *      FYP_Category()
         *         
         *  DESCRIPTION:
         *      This is the default constructor for FYP_Category class. Initializes the member variables to null. 
         *  
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public FYP_Category()
        {
            Name = null;
            CourseList = null;
        }


        /**/
        /*
         *  NAME: 
         *      FYP_Category()
         *  
         *  SYNOPSIS:
         *      FYP_Category(string category, List<FYP_CourseElement> courseList)
         *          a_category --> name of the FYP_Category object.
         *          a_courseList --> list of courses containing the FYP_CourseElements.
         *         
         *  DESCRIPTION:
         *      Parametrized constructor for FYP_Category class. 
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public FYP_Category(string a_category, List<FYP_CourseElement> a_courseList)
        {
            Name = a_category;
            CourseList = a_courseList;
        }

        /**/
        /*
         *  NAME: 
         *      FYP_Category operator+()
         *  
         *  SYNOPSIS:
         *      FYP_Category operator+ (FYP_Category a_cat1, FYP_Category a_cat2)
         *          a_cat1 --> category one the is to be combined with another category. 
         *          a_cat2 --> another category that is to be combined.
         *         
         *  DESCRIPTION:
         *      Overaloaing + operator for FYP_Category class. Helps in combining the courses
         *      in two different categories. 
         *      
         *  RETURNS:
         *      FYP_Category --> A new FYP_Category object that contains the combined list of courses
         *      from the two objects passed as parameters. 
         *      
         *      NOTE: Might return an object will null propertes if both the parameters are null. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public static FYP_Category operator+ (FYP_Category a_cat1, FYP_Category a_cat2)
        {
            FYP_Category category = new FYP_Category();

            // If both of them are null, return a null category.
            if (a_cat1.IsNull() && a_cat2.IsNull())
            {
                return category;
            }
            // If one of them is null, return the other one.
            else if (a_cat1.IsNull())
            {
                return a_cat2;
            }
            else if (a_cat2.IsNull())
            {
                return a_cat1;
            }
            // If both of them are not null, concatenate the category names and extend the list by combining
            // the list of courseElements from both categories.
            else
            { 
                category.Name = a_cat1.Name + " & " + a_cat2.Name;

                List<FYP_CourseElement> composite = new List<FYP_CourseElement>();
                composite.AddRange(a_cat1.CourseList);
                composite.AddRange(a_cat2.CourseList);
                category.CourseList = composite;

                return category;
            }
        }

        /**/
        /*
         *  NAME:  
         *      IsNull()
         *  
         *  SYNOPSIS:
         *      bool IsNull()
         *      
         *         
         *  DESCRIPTION:
         *      Determines if the object is a null object or not. 
         *      
         *      
         *  RETURNS:
         *      True if both the name and courseList are null.
         *      False, otherwise. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public bool IsNull()
        {
            if (this.Name == null && this.CourseList == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /**/
        /*
         *  NAME:  
         *      IsGenEd()
         *  
         *  SYNOPSIS:
         *      bool IsGenEd()
         *      
         *         
         *  DESCRIPTION:
         *      Determines if the FYP_Category is a Gen Ed category or not. 
         *      
         *  RETURNS:
         *      True if the category is a Gen Ed category. 
         *      False, otherwise. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public bool IsGenEd()
        {
            // If the category name starts with "gen ed", 
            // it is a gen ed category. 

            // Note: We prepend the category typename to the categoryName
            // when creating the FYP_Category object. 
            // See WebScraper class for reference. 
            if (this.Name.StartsWith("gen ed"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


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
         *      A string format that represents the FYP Category object and 
         *      its attributes. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public override string ToString()
        {
            // Note: "->" is the delimeter that separates categoryName and the list of courseElements. 
            string composite = Name + "->";
            if (CourseList != null)
            {
                // Each FYP_CourseElement in the list will be seperated by a ';'
                foreach (FYP_CourseElement element in CourseList)
                {
                    composite += element.ToString() + ";";
                }
            }
            return composite;
        }


        /**/
        /*
         *  NAME:  
         *      IsFYS()
         *  
         *  SYNOPSIS:
         *      bool IsFYS()
         *      
         *         
         *  DESCRIPTION:
         *      Determines if the FYP_Category is a FYS (First Year Seminar) category or not. 
         *      
         *      NOTE: This is important because we don't want to prepackage students into FYS classes. 
         *      They have the option to pick their FYS classes themselves. 
         *      
         *  RETURNS:
         *      True if the category is a FYS category. 
         *      False, otherwise. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public bool IsFYS()
        {
            if (Name.Contains("first year seminar"))
            {
                return true;
            }
            return false;
        }

        /**/
        /*
         *  NAME:  
         *      IsGlobalAwareness()
         *  
         *  SYNOPSIS:
         *      bool IsGlobalAwareness()
         *      
         *         
         *  DESCRIPTION:
         *      Determines if the FYP_Category is a Global Awareness category or not. 
         *      
         *      NOTE: This is important because we don't want to prepackage students into Global Awareness classes.  
         *      
         *      This is because Global Awareness classes often require language testing which the student might not
         *      have necessarily tested into. 
         *      
         *  RETURNS:
         *      True if the category is a FYS category. 
         *      False, otherwise. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public bool IsGlobalAwareness()
        {
            if (Name.Contains("global awareness"))
            {
                return true;
            }
            return false;
        }
    }
}
