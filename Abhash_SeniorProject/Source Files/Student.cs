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
     *      Represents each incoming freshmen students who need to be prepackaged. 
     *  
     *  PURPOSE: 
     *      To hold all the information about the student which are required for prepackaging
     *      purposes. 
     *  
     *  AUTHOR: 
     *      Abhash Panta
     */
    /**/
    class Student
    {
        // Member Variables

        // Represents The term (semester) ID
        int m_term;

        // Last Name of the Student
        string m_lastName;

        // First name of the Student
        string m_firstName;
        
        // Middle Initial of the Student
        string m_middleInitial;

        // Ramapo ID of the Student
        string m_ramapoId;

        // If the student is enrolled into courses or not. 
        // (Has registered for courses?)
        bool m_enrld;
        
        // Number of hours they are enrolled for. 
        int m_termEnrldHours;

        // Number of transferred hours. 
        int m_termTrnsHours;

        // Type of student (New (N) / Transfer (T)
        // NOTE: The file will already by filtered 
        // and contain new students only. 
        string m_studentType;

        // Represents admission type.
        // The only admit type that will be considered 
        // are freshmen (F).
        string m_admitType;

        // Admission School (Ex. TAS, ASB, SHSS, etc.)
        string m_admitSchool;

        // Four-letter code for major
        string m_admitMajor;

        // Full major name
        string m_admitMajorDesc;

        // Unique code for concentration
        string m_admitConcentration;

        // Full concentration name
        string m_admitConcentrationDesc;

        // Date when they made their enrollment deposit. 
        // NOTE: This will be used as the filter to determine
        // which students to prepackage.
        DateTime m_dcsnDate;

        // Scholarships awarded
        string m_scholarship_1;
        string m_scholarship_2;

        // Determines if they are Honors student or not.
        bool m_honors;

        // Determiens if they are EOF student or not. 
        bool m_eof;

        // The type of sport they are in (only for athletes)
        // 'None' for non-athletes.
        string m_sport;

        // Ramapo Email ID
        string m_rncjEmail;

        // Phone number
        string m_phone;

        // Determines if the housing deposit has been paid.
        bool m_housingDeposit;

        // Determines if they want housing or not.
        bool m_housing;

        // Determines if they have registered for orientation
        bool m_rsvp_orientation;

        // ID of the orientation session
        string m_orientation;

        // Date for orientation
        DateTime m_orientDate;

        // Information about the placement tests. 
        TestingInfo m_testInfo;

        // Information about the student's credits.
        CreditInfo m_creditInfo;

        List<Course> m_prepackagedCourses;


        // Properties for respective member variables
        public int Term { get => m_term; set => m_term = value; }
        public string LastName { get => m_lastName; set => m_lastName = value; }
        public string FirstName { get => m_firstName; set => m_firstName = value; }
        public string MiddleInitial { get => m_middleInitial; set => m_middleInitial = value; }
        public string RamapoId { get => m_ramapoId; set => m_ramapoId = value; }

        public bool Enrld { get => m_enrld; set => m_enrld = value; }
        public int TermEnrldHours { get => m_termEnrldHours; set => m_termEnrldHours = value; }
        public int TermTrnsHours { get => m_termTrnsHours; set => m_termTrnsHours = value; }
        public string StudentType { get => m_studentType; set => m_studentType = value; }
        public string AdmitType { get => m_admitType; set => m_admitType = value; }

        public string AdmitSchool { get => m_admitSchool; set => m_admitSchool = value; }
        public string AdmitMajor { get => m_admitMajor; set => m_admitMajor = value; }
        public string AdmitConcentration { get => m_admitConcentration; set => m_admitConcentration = value; }
        public string AdmitMajorDesc { get => m_admitMajorDesc; set => m_admitMajorDesc = value; }
        public string AdmitConcentrationDesc { get => m_admitConcentrationDesc; set => m_admitConcentrationDesc = value; }

        public DateTime DcsnDate { get => m_dcsnDate; set => m_dcsnDate = value; }
        public string Scholarship_1 { get => m_scholarship_1; set => m_scholarship_1 = value; }
        public string Scholarship_2 { get => m_scholarship_2; set => m_scholarship_2 = value; }
        public bool Honors { get => m_honors; set => m_honors = value; }
        public bool Eof { get => m_eof; set => m_eof = value; }
        public string Sport { get => m_sport; set => m_sport = value; }

        public string RncjEmail { get => m_rncjEmail; set => m_rncjEmail = value; }
        public string Phone { get => m_phone; set => m_phone = value; }


        public bool HousingDeposit { get => m_housingDeposit; set => m_housingDeposit = value; }
        public bool Housing { get => m_housing; set => m_housing = value; }
        public bool Rsvp_orientation { get => m_rsvp_orientation; set => m_rsvp_orientation = value; }
        public string Orientation { get => m_orientation; set => m_orientation = value; }
        public DateTime OrientDate { get => m_orientDate; set => m_orientDate = value; }
        public TestingInfo TestInfo { get => m_testInfo; set => m_testInfo = value; }
        public CreditInfo CreditInfo { get => m_creditInfo; set => m_creditInfo = value; }
        public List<Course> PrepackagedCourses { get => m_prepackagedCourses; set => m_prepackagedCourses = value; }



        /**/
        /*
         *  NAME: 
         *      IsPrepackaged()
         *  
         *  SYNOPSIS:
         *      bool IsPrepackaged()
         *         
         *  DESCRIPTION: 
         *      This function determines if a student has been previously prepackaged and registered into courses. 
         *  
         *  RETURNS:
         *      True, if the student has been prepackaged and registered.
         *      False, otherwise. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public bool IsPrepackaged()
        {
            // If student is enrl (which means registered) and enrolled hours for the term >= 12, 
            // the student is considered to be prepackaged and registered. 
            if (Enrld == true && TermEnrldHours >= 12)
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
         *      HasRequiredTests()
         *  
         *  SYNOPSIS:
         *      bool HasRequiredTests()
         *         
         *  DESCRIPTION: 
         *      This function determines if a student has taken the tests that are required.
         *  
         *  RETURNS:
         *      True, if the student has all the required tests. 
         *      False, otherwise. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public bool HasRequiredTests()
        {
            // If math test is required and the student has no scores, return false. 
            if (TestInfo.MathTestType == "math test required" || TestInfo.MathTestType == "math and calc required")
            {
                if (TestInfo.ACU_Quant == -1)
                {
                    return false;
                }
            }
            
            // If reading/essay test is required and the student has no scores, return false.
            if (TestInfo.ReadingTestType == "reading/essay test required")
            {
                if (TestInfo.ACU_Read == -1 || TestInfo.ACU_Essay == -1)
                {
                    return false;
                }
            }

            return true;
        }

        /**/
        /*
         *  NAME: 
         *      GetCourseCredits()
         *  
         *  SYNOPSIS:
         *      List<string> GetCourseCredits()
         *         
         *  DESCRIPTION: 
         *      This function returns a list of string, each of which represent a course credit
         *      that they have acquired.
         *  
         *  RETURNS:
         *      List<string> --> list containing the student's credits. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public List<string> GetCourseCredits()
        {
            List<string> creditList = new List<string>();
            creditList.AddRange(CreditInfo.SummerCourses);
            creditList.AddRange(CreditInfo.RcnjCourses);
            creditList.AddRange(CreditInfo.APCourses);
            creditList.AddRange(CreditInfo.NonAPCourses);

            return creditList;
        }

        /**/
        /*
         *  NAME: 
         *      IsPresidentialScholar()
         *  
         *  SYNOPSIS:
         *      bool IsPresidentialScholar()
         *         
         *  DESCRIPTION: 
         *      This function determines is a student is presidential scholar or not.
         *  
         *  RETURNS:
         *      True if the student is presidential scholar.
         *      False, otherwise. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public bool IsPresidentialScholar()
        {
            if (Scholarship_1.Contains("presidential") || Scholarship_2.Contains("presidential"))
            {
                return true;
            }
            return false;
        }

        /**/
        /*
         *  NAME: 
         *      IsDeanScholar()
         *  
         *  SYNOPSIS:
         *      bool IsDeanScholar()
         *         
         *  DESCRIPTION: 
         *      This function determines is a student is dean scholar or not.
         *  
         *  RETURNS:
         *      True if the student is dean scholar.
         *      False, otherwise. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public bool IsDeanScholar()
        {
            if (Scholarship_1.Contains("dean") || Scholarship_2.Contains("dean"))
            {
                return true;
            }
            return false;
        }


        /**/
        /*
         *  NAME: 
         *      ToString()
         *  
         *  SYNOPSIS:
         *      string ToString()
         *         
         *  DESCRIPTION: 
         *      This function returns a string, which represents the serialized student object
         *      with partial details.
         *      The details include the prepackaged courses and their details (Name, CRN, Day/Time). 
         *  
         *  RETURNS:
         *      string --> a string that represents the serialized student object. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public override string ToString()
        {
            string serial = "";
            serial += RamapoId + ",";
            serial += FirstName + ",";
            serial += LastName + ",";
            serial += RncjEmail + ",";
            serial += AdmitMajor + ",";
            serial += AdmitMajorDesc + ",";
            serial += AdmitConcentration + ",";
            serial += AdmitConcentrationDesc + ",";
            serial += TermEnrldHours + ",";
            serial += DcsnDate + ",";
            serial += m_scholarship_1 + ",";
            serial += m_scholarship_2 + ",";
            serial += Honors + ",";
            serial += Eof + ",";
            serial += Sport + ",";
            serial += HousingDeposit + ",";
            foreach (Course c in PrepackagedCourses)
            {
                serial += c.Subj + " " + c.Crse + ",";
                serial += c.GetDayTime() + ",";
                serial += c.Crn + ",";
            }
            serial += " ";

            return serial;
        }


        /**/
        /*
         *  NAME: 
         *      GetHeader()
         *  
         *  SYNOPSIS:
         *      string GetHeader()
         *         
         *  DESCRIPTION: 
         *      This function contains the header string for the output csv file. 
         *      The header values must each match with the respective student data included in the
         *      ToString() method. 
         *  
         *  RETURNS:
         *      string --> a string that represents the header string for the csv file. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public static string GetHeader()
        {
            string serial = "";
           
            serial += "RamapoId" + ",";
            serial += "FirstName" + ",";
            serial += "LastName" + ",";
            serial += "RncjEmail" + ",";
            serial += "AdmitMajor" + ",";
            serial += "AdmitMajorDesc" + ",";
            serial += "AdmitConcentration" + ",";
            serial += "AdmitConcentrationDesc" + ",";
            serial += "TermEnrldHours" + ",";
            serial += "DcsnDate" + ",";
            serial += "m_scholarship_1" + ",";
            serial += "m_scholarship_2" + ",";
            serial += "Honors" + ",";
            serial += "Eof" + ",";
            serial += "Sport" + ",";
            serial += "Housing" + ",";
            for (int i = 1; i < 10; i++)
            {
                serial += "Course" + i + ",";
                serial += "Days" + i + ",";
                serial += "CRN" + i + ",";
            }
            serial += " ";

            return serial;
        }
    }
}
