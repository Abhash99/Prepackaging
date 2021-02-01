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
     *      The class represents the scheduler which is reponsible to schedule each student into 
     *      appropriate classes based on their attributes.

     *  PURPOSE:
     *      This class contains the critical scheduling logic needed to consider the criteria and 
     *      requirements for scheduling students.
     *      This class schedules students based on the scheudling requirements outlined by the Center of Student
     *      Success. 
     *      
     *  AUTHOR: 
     *      Abhash Panta
     */
    /**/
    class Scheduler
    {
        // Member Variables

        // Represents the list containing all the classes being offered at Ramapo
        // during the semester. 
        private List<Course> m_courseList;

        // Represents the list of all freshmen students who are to be prepackaged.
        private List<Student> m_studentList;

        // Represents the list of Major Four-Year Plans.
        private List<Major> m_majorList;

        // Represents the date when student made enrollment decision.
        private DateTime m_decisionDate;

        // Represents the list of all athletes.
        private List<Athlete> m_athleteList;

        // Represents the list of sports at Ramapo and their practice times.
        private List<Sport> m_sportList;


        // Properties for respective member variables.
        public List<Course> CourseList { get => m_courseList; set => m_courseList = value; }
        public List<Student> StudentList { get => m_studentList; set => m_studentList = value; }
        public List<Major> MajorList { get => m_majorList; set => m_majorList = value; }
        public DateTime DecisionDate { get => m_decisionDate; set => m_decisionDate = value; }
        public List<Athlete> AthleteList { get => m_athleteList; set => m_athleteList = value; }
        public List<Sport> SportList { get => m_sportList; set => m_sportList = value; }


        /**/
        /*
         *  NAME: 
         *      Scheduler()
         *  
         *  SYNOPSIS:
         *      Scheduler(List<Course> a_courseList, List<Student> a_studentList, List<Major> a_majorList, DateTime a_decisionDate, List<Athlete> a_athleteList, List<Sport> a_sportList)
         *          a_courseList --> list of courses being offered at Ramapo college. 
         *          a_studentList --> list of students that need to be prepackaged (read from excel file). 
         *          a_majorList --> list of majors' four year plans
         *          a_decisionDate --> date when student made enrollment decision
         *          a_athleteList --> list of all athletes. 
         *          a_sportList --> list of all sport objects (hold sport name and practice times). 
         *         
         *  DESCRIPTION:
         *      Parametrized constructor for scheduler object. Takes required attributes as parameters and sets those attributes. 
         *     
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public Scheduler(List<Course> a_courseList, List<Student> a_studentList, List<Major> a_majorList, DateTime a_decisionDate, List<Athlete> a_athleteList, List<Sport> a_sportList)
        {
            this.CourseList = a_courseList;
            this.StudentList = a_studentList;
            this.MajorList = a_majorList;
            this.DecisionDate = a_decisionDate;
            this.AthleteList = a_athleteList;
            this.SportList = a_sportList;
        }


        /**/
        /*
         *  NAME: 
         *      StartScheduling()
         *  
         *  SYNOPSIS:
         *      List<Student> StartScheduling()
         *         
         *  DESCRIPTION:
         *      This function starts the scheduling process, by scheduling qualified 
         *      students based on priority characteristics and returns a list of prepackaged
         *      students. 
         *     
         *  RETURNS:
         *      List<Student> --> The list of prepackaged students, who have been scheduled into respective 
         *      classes. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public List<Student> StartScheduling()
        {
            List<Student> filteredList = GetFilteredStudentList();
            UpdateSport(ref filteredList);

            // Schedule Athletes First
            ScheduleAthletes(ref filteredList);
            
            // Schedule Honors Students
            ScheduleHonors(ref filteredList);

            // Schedule Scholars
            ScheduleScholars(ref filteredList);

            // Schedule Remaining
            ScheduleRemaining(ref filteredList);

            //********************     Athletes Scheduling Test ****************************************************************************************************************
            //int index = 0;
            //foreach (Student s in filteredList)
            //{
            //    if (s.Sport != "none")
            //    {
            //        Console.WriteLine(index + " " + s.FirstName + " " + s.LastName + "--> Sport: " + s.Sport);
            //        index++;
            //        foreach (Course c in s.PrepackagedCourses)
            //        {
            //            Console.WriteLine(c.Subj + "-" + c.Crse + "--->" + c.GetDaysString() + ": " + c.StartTime + "-" + c.EndTime);
            //        }

            //        Console.WriteLine("================= Practice Times ===========================");
            //        Sport studentSport = GetStudentSport(s);
            //        int timeIndex = 1;
            //        foreach (Interval interval in studentSport.Intervals)
            //        {
            //            Console.WriteLine(timeIndex + ". " + interval.Days + ": " + interval.StartTime + " - " + interval.EndTime);
            //        }

            //        Console.WriteLine("==========================================================================");

            //    }
            //}

            // ****************************************************************************************************************************************************************************


            //********************     Commuter Scheduling Test ****************************************************************************************************************
            int index = 0;
            foreach (Student s in filteredList)
            {

                // Output Test
                if (s.HousingDeposit != true)
                {
                    Console.WriteLine(index + " " + s.FirstName + " " + s.LastName + "--> Sport: " + s.Sport);
                    index++;
                    foreach (Course c in s.PrepackagedCourses)
                    {
                        Console.WriteLine(c.Subj + "-" + c.Crse + "--->" + c.GetDaysString() + ": " + c.StartTime + "-" + c.EndTime);
                    }

                    Console.WriteLine("==========================================================================");
                }
            }

            // ****************************************************************************************************************************************************************************


            //*****************  Credit Substitution Test  ******************************************************************************************************************
            //int index = 0;
            //foreach (Student s in filteredList)
            //{

            //    // Output Test
            //    if (s.GetCourseCredits().Count != 0)
            //    {
            //        Console.WriteLine(index + " " + s.FirstName + " " + s.LastName +  "   | Major -> " + s.AdmitMajorDesc);
            //        index++;
            //        foreach (Course c in s.PrepackagedCourses)
            //        {
            //            Console.WriteLine(c.Subj + "-" + c.Crse + "--->" + c.GetDaysString() + ": " + c.StartTime + "-" + c.EndTime);
            //        }

            //        Console.WriteLine("====== Credits ==================================");
            //        int creditIndex = 1;
            //        foreach (string credit in s.GetCourseCredits())
            //        {
            //            Console.WriteLine(creditIndex + " " + credit);
            //            creditIndex++;
            //        }

            //        Console.WriteLine("==========================================================================");
            //    }
            //}

            // ****************************************************************************************************************************************************************************


            //***************  Course Statistics Change Test  **********************************************************************************************

            //int courseIndex = 0;
            //foreach (Course c in CourseList)
            //{
            //    if (c.ScheduledStudents != 0)
            //    {
            //        Console.WriteLine(courseIndex + ". " + c.Crn + " : " + c.Subj + "-" + c.Crse + " ------> Scheduled: " + c.ScheduledStudents + " | BannerCap : " + c.BannerCap + " | Saved : " + c.Saved);
            //        courseIndex++;
            //    }
            //}

            // Console.WriteLine("==========================================================================");

            //*************************************************************************************************************************************************

            Console.WriteLine("End");

            return filteredList;
        }


        /**/
        /*
         *  NAME: 
         *      GetFilteredStudentList()
         *  
         *  SYNOPSIS:
         *      List<Student> GetFilteredStudentList()
         *         
         *  DESCRIPTION:
         *     This function gets the list of qualified students (who are qualified to be 
         *     prepackaged) from the list of all freshmen students. 
         *     
         *     NOTE: The students are qualified for prepackaing if they have made their enrollment decision
         *     before the selected decision date, if they they have not been already registered for more than 
         *     12 credits, and if they have the taken the ACCUPLACER Quantitative Reasoning and Reading/Essay tests.
         *     
         *  RETURNS:
         *      List<Student> --> the filtered list of students who are qualified for prepackaging based on the above 
         *      mentioned criteria. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private List<Student> GetFilteredStudentList()
        {
            List<Student> filteredList = new List<Student>();
            foreach (Student student in StudentList)
            {
                if (student.DcsnDate != DateTime.MinValue && student.DcsnDate <= DecisionDate && !student.IsPrepackaged() && student.HasRequiredTests())
                {
                    filteredList.Add(student);
                }
            }

            return filteredList;
        }


        /**/
        /*
         *  NAME: 
         *      UpdateSport()
         *  
         *  SYNOPSIS:
         *      UpdateSport(ref List<Student> a_filteredStudents)
         *          a_filteredStudents --> The list of students who are qualified to be prepackaged. 
         *         
         *  DESCRIPTION:
         *      This function matches athletes by comparing filteredStudentList and athleteList.
         *      If the match is found, we update the student's sport attribute to the respective sport
         *      they are participating in. 
         *      
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private void UpdateSport(ref List<Student> a_filteredStudents)
        {
            foreach (Athlete athlete in AthleteList)
            {
                foreach (Student s in a_filteredStudents)
                {
                    // If the Ramapo Id match, the student is an athlete. 
                    if (athlete.RamapoId == s.RamapoId)
                    {
                        s.Sport = athlete.Sport;
                        // Console.WriteLine("Name: " + s.FirstName + " " + s.LastName + " | Sport: " + s.Sport);
                    }
                }
            }
        }


        /**/
        /*
         *  NAME: 
         *      ScheduleAthletes()
         *  
         *  SYNOPSIS:
         *      void ScheduleAthletes(ref List<Student> a_filteredList)
         *          a_filteredList --> The list of students who are qualified to be prepackaged. 
         *         
         *  DESCRIPTION:
         *      This function schedules all athletes into their respective courses. 
         *  
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private void ScheduleAthletes(ref List<Student> a_filteredList)
        {
            for (int i  = 0; i < a_filteredList.Count; i++)
            {
                if (a_filteredList[i].Sport != "none" && a_filteredList[i].PrepackagedCourses == null)
                {
                    a_filteredList[i] = ScheduleStudent(a_filteredList[i]);
                }
            }
        }

        /**/
        /*
         *  NAME: 
         *      ScheduleHonors()
         *  
         *  SYNOPSIS:
         *      void ScheduleHonors(ref List<Student> a_filteredList)
         *          a_filteredList --> The list of students who are qualified to be prepackaged. 
         *         
         *  DESCRIPTION:
         *      This function schedules all honors students into their respective courses. 
         *  
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private void ScheduleHonors(ref List<Student> a_filteredList)
        {
            for (int i = 0; i < a_filteredList.Count; i++)
            {
                if (a_filteredList[i].Honors == true && a_filteredList[i].PrepackagedCourses == null)
                {
                    a_filteredList[i] = ScheduleStudent(a_filteredList[i]);
                }
            }

        }


        /**/
        /*
         *  NAME: 
         *      ScheduleScholars()
         *  
         *  SYNOPSIS:
         *      void ScheduleScholars(ref List<Student> a_filteredList)
         *          a_filteredList --> The list of students who are qualified to be prepackaged. 
         *         
         *  DESCRIPTION:
         *      This function schedules all scholars (Presidential and Dean) into their respective courses. 
         *  
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private void ScheduleScholars(ref List<Student> a_filteredList)
        {
            // Prepackage Presidential Scholars first (Priority)
            for (int i = 0; i < a_filteredList.Count; i++)
            {
                if (a_filteredList[i].IsPresidentialScholar() && a_filteredList[i].PrepackagedCourses == null)
                {
                    a_filteredList[i] = ScheduleStudent(a_filteredList[i]);
                }
            }

            // Prepackage Dean Scholars after presidential scholars
            for (int i = 0; i < a_filteredList.Count; i++)
            {
                if (a_filteredList[i].IsDeanScholar() && a_filteredList[i].PrepackagedCourses == null)
                {
                    a_filteredList[i] = ScheduleStudent(a_filteredList[i]);
                }
            }
        }


        /**/
        /*
         *  NAME: 
         *      ScheduleRemaining()
         *  
         *  SYNOPSIS:
         *      void ScheduleRemaining(ref List<Student> a_filteredList)
         *          a_filteredList --> The list of students who are qualified to be prepackaged. 
         *         
         *  DESCRIPTION:
         *      This function schedules all the remaining students in the filteredList(who haven't been prepackaged) into their respective courses. 
         *  
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private void ScheduleRemaining(ref List<Student> a_filteredList)
        {
            for (int i = 0; i < a_filteredList.Count; i++)
            {
                if (a_filteredList[i].PrepackagedCourses == null)
                {
                    a_filteredList[i] = ScheduleStudent(a_filteredList[i]);
                }
            }
        }


        /**/
        /*
         *  NAME: 
         *      ScheduleStudent()
         *  
         *  SYNOPSIS:
         *      Student ScheduleStudent(Student a_student)
         *          a_student --> the student who will be prepackaged into first semester courses. 
         *         
         *  DESCRIPTION:
         *      This function prepackages a single student into their first semester courses based on their 
         *      attributes. 
         *  
         *  RETURNS:
         *      Student --> The copy of the student object that contains the recommended courses (prepackagedCourses). 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private Student ScheduleStudent(Student a_student)
        {
            // Set students prepackaged courses
            a_student.PrepackagedCourses = GetPrepackagedCourses(a_student);
            
            // Update the course statisctics (decrease seat counts after scheduling student).
            UpdateCoursesStats(a_student);
            return a_student;
        }

        /**/
        /*
         *  NAME: 
         *      GetPrepackagedCourses()
         *  
         *  SYNOPSIS:
         *      List<Course> GetPrepackagedCourses(Student a_student)
         *          a_student --> the student who will be prepackaged into first semester courses. 
         *         
         *  DESCRIPTION:
         *      This function finds the perfect combination of courses for the student's first semester and 
         *      returns them as list of course objects. 
         *  
         *  RETURNS:
         *      List<Course> --> A list of courses that are recommended for the student based on the prepackaging 
         *      business logic. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public List<Course> GetPrepackagedCourses(Student a_student)
        {

            // Obtain student's major's FYP and find the categories of courses he/she is 
            // recommended to take. 
            Major major = GetStudentMajor(a_student);
            List<FYP_Category> firstSemCategories = GetFirstSemCategories(a_student, major);

            // We store all the potential combination of courses using List<List<Course>>. 
            List<List<Course>> ultimateList = new List<List<Course>>();

            // For each category, obtain the list of all courses and add the list to the ultimateList. 
            foreach (FYP_Category category in firstSemCategories)
            {
                List<Course> catCourses = GetCoursesFromCategory(a_student, category);
                ultimateList.Add(catCourses);
            }

            // Each list<Course> in ultimateList contains coureses that fall under one category. 
            // However, we can only schedule the student into one course in each category. 
            // So we obtain all possible combinations of courses in required categories. 

            List<List<Course>> combinations = GetSingleCombinationsList(ultimateList);

            // If the student is a commuter, we want to schedule them in classes are close.
            // Have classes spread over at most 4 days. (Preferred but not absolute requirement). 
            if (a_student.HousingDeposit == false)
            {
                // From all the combinations, we add the time-conflict free combinations into a new list. 
                List<List<Course>> filteredCombinations = new List<List<Course>>();
                foreach (List<Course> comb in combinations)
                {
                    // We create intervals for each course in the combinations and find if they have time conflicts. 
                    Interval[] appt = new Interval[comb.Count];
                    for (int i = 0; i < comb.Count; i++)
                    {
                        Interval newInterval = new Interval(comb[i].StartTime, comb[i].EndTime, comb[i].GetDaysString());
                        appt[i] = newInterval;
                    }
                    
                    // If they don't have time conflicts, add it to the filteredCombinations.
                    if (!IsConflicting(appt))
                    {
                        filteredCombinations.Add(comb);
                    }
                }

                // We obtain the combination of courses with maximum proximity value and return that course. 
                return GetMaximumProximityCourses(ref filteredCombinations);

            }
            else
            {

                // If they are not commuters, we find the first combination that doesn't have time conflicts and return it. 
                foreach (List<Course> comb in combinations)
                {
                    Interval[] appt = new Interval[comb.Count];
                    for (int i = 0; i < comb.Count; i++)
                    {
                        Interval newInterval = new Interval(comb[i].StartTime, comb[i].EndTime, comb[i].GetDaysString());
                        appt[i] = newInterval;
                    }
                    if (!IsConflicting(appt))
                    {
                        return comb;
                    }
                }
            }

            // If we get to this step, there is an error. Returns a null combination. 
            List<Course> nullCombination = new List<Course>();
            return nullCombination;

        }


        /**/
        /*
         *  NAME: 
         *      GetStudentMajor()
         *  
         *  SYNOPSIS:
         *      Major GetStudentMajor(Student a_student)
         *          a_student --> the student who will be prepackaged into first semester courses. 
         *         
         *  DESCRIPTION:
         *      This function finds the Major object (which represents the Four Year Plan) based on the student's major attribute. 
         *      
         *  RETURNS:
         *      Major --> The major object that represents the Four-year plan corresponding to student's major. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private Major GetStudentMajor(Student a_student)
        {
            string majorCode = a_student.AdmitMajor;
            string majorOnly = majorCode;
            // If student's concentration is present, add concentration to major string.
            if (a_student.AdmitConcentration != "")
            {
                majorCode = majorCode + "-" + a_student.AdmitConcentration;
            }

            // Find the major object corresponding to major + concentration string. 
            foreach (Major maj in MajorList)
            {
                if (maj.Id == majorCode)
                {
                    return maj;
                }
            }

            // If the major + concentration string is not found, we fall back to just the majorOnly code. 
            // Find the major corresponding to majorOnly string and return it. 
            foreach (Major maj in MajorList)
            {
                if (maj.Id == majorOnly)
                {
                    return maj;
                }
            }

            // If we get to this point, the major doesn't exist in our list of Majors. There is an error. 
            Major nullMajor = new Major();
            return nullMajor;
        }




        /**/
        /*
         *  NAME: 
         *      GetFirstSemCategories()
         *      
         *  
         *  SYNOPSIS:
         *      List<FYP_Category> GetFirstSemCategories(Student a_student, Major a_major)
         *          a_student --> the student who will be prepackaged into first semester courses. 
         *          a_major --> student's FYP representation. 
         *         
         *  DESCRIPTION:
         *      This function returns the list of categories that the student is recommended to take based on their 
         *      FYP and their attributes. 
         *      
         *  RETURNS:
         *      List<FYP_Category> --> The list of recommended course categories. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private List<FYP_Category> GetFirstSemCategories(Student a_student, Major a_major)
        {
            // Get the list of categories for the first sem
            List<FYP_Category> categories = new List<FYP_Category>();
            if (!a_major.IsNull())
            {
                // First semester courses are seperated from the rest by the element "total" in the 
                // list of course categories. 
                foreach (FYP_Category cat in a_major.CourseCategories)
                {
                    // When we get to "total", we are done. 
                    if (cat.Name.StartsWith("total"))
                    {
                        break;
                    }

                    // Obtain a single category -  (maybe straightforward or maybe replacement if student has credits for that category)
                    FYP_Category finalCategory = GetSingleCategory(a_student, a_major, cat, categories);

                    // If it is first year seminar, we don't add it to the categoryList as students have the 
                    // option to pick the course of their liking. 
                    if (!finalCategory.IsFYS())
                    {
                        categories.Add(finalCategory);
                    }
                }
            }

            return categories;
        }


        /**/
        /*
         *  NAME: 
         *      GetFirstSemCategories()
         *      
         *  
         *  SYNOPSIS:
         *      bool CreditExists(FYP_Category a_category, List<string> a_creditList)
         *          a_category --> the category to be considered
         *          a_creditList --> list of credits the student has
         *         
         *  DESCRIPTION:
         *      This function determines if a student has credit for a particular category. 
         *      The function compares the courses that fall under the category and the student's
         *      creditList. If an element is common in both lists, credit exists. 
         *      
         *  RETURNS:
         *      True, if credit exists for the category.
         *      False, otherwise. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private bool CreditExists(FYP_Category a_category, List<string> a_creditList)
        {
            foreach (FYP_CourseElement element in a_category.CourseList)
            {
                foreach (string credit in a_creditList)
                {
                    // If both match, credit exists. 
                    if (element.ToString() == credit)
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        /**/
        /*
         *  NAME: 
         *      CategoryExistsInList()
         *  
         *  SYNOPSIS:
         *      bool CategoryExistsInList(FYP_Category a_category, List<FYP_Category> a_categoryList)
         *          a_category --> the category to be considered
         *          a_categorylist --> the list of categories which is to be searched. 
         *         
         *  DESCRIPTION:
         *      This function determiens if a category exists in a list of categories. This is done by simple 
         *      comparison of category names between the category and the categories in the list. 
         *      
         *  RETURNS:
         *      True, if category exists in the list. 
         *      False, otherwise. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private bool CategoryExistsInList(FYP_Category a_category, List<FYP_Category> a_categoryList)
        {
            foreach (FYP_Category cat in a_categoryList)
            {
                if (cat.ToString() == a_category.ToString())
                {
                    return true;
                }
            }

            return false;
        }


        /**/
        /*
         *  NAME: 
         *      GetSingleCategory()
         *  
         *  SYNOPSIS:
         *      FYP_Category GetSingleCategory(Student a_student, Major a_major, FYP_Category a_category, List<FYP_Category> a_categoryList)
         *          a_student --> the student who is being prepackaged
         *          a_major --> student's four-year plan representation
         *          a_category --> initial category that is being considered. 
         *          a_categoryList --> the list of categories that have already been chosen
         *          
         *  DESCRIPTION:
         *      This function checks if the student has credits for the considered category, or if the category is already present in the list.
         *      If yes to any of these, we find a replacement category, otherwise we return the initial category that was considered. 
         *      
         *      
         *  RETURNS:
         *      FYP_Category --> The category that has been selected based on the FYP and student's credits. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private FYP_Category GetSingleCategory(Student a_student, Major a_major, FYP_Category a_category, List<FYP_Category> a_categoryList)
        {
            // check if student has credits for the category or if the category already exists in the category list. 
            if (CreditExists(a_category, a_student.GetCourseCredits()) == true || CategoryExistsInList(a_category, a_categoryList) == true)
            {
                FYP_Category replacement = GetReplacementCategory(a_student, a_major, a_categoryList);
                return replacement;
            }

            return a_category;
        }


        /**/
        /*
         *  NAME: 
         *      GetReplacementCategory()
         *  
         *  SYNOPSIS:
         *      FYP_Category GetReplacementCategory(Student a_student, Major a_major, List<FYP_Category> a_categoryList)
         *          a_student --> the student who is being prepackaged
         *          a_major --> student's four-year plan representation 
         *          a_categoryList --> the list of categories that have already been chosen
         *          
         *  DESCRIPTION:
         *      This function finds a replacement category in case the student has credits for a category or if the considered category
         *      already exists in the list. 
         *      
         *      NOTE: Replacement categories are always general education courses. 
         *      
         *      
         *  RETURNS:
         *      FYP_Category --> Replacement category. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private FYP_Category GetReplacementCategory(Student a_student, Major a_major, List<FYP_Category> a_categoryList)
        {
            // Get all the general education courses listed in the FYP. 
            List<FYP_Category> genEdCourses = a_major.GetGenEds();
            
            // For each gen ed, check if student has credits, or if the category already exists in the list, or if it is First Year Seminar or Global Awareness category. 
            // If none of the above conditions are true, return the category.
            foreach (FYP_Category category in genEdCourses)
            {
                if (!CreditExists(category, a_student.GetCourseCredits()) && !CategoryExistsInList(category, a_categoryList) && !category.IsFYS() && !category.IsGlobalAwareness())
                {
                    return category;
                }
            }

            // If we get here, there has to be an error. We couldn't find any replacement category. 
            FYP_Category nullCategory = new FYP_Category();
            return nullCategory;
        }


        /**/
        /*
         *  NAME: 
         *      GetCoursesFromCategory()
         *  
         *  SYNOPSIS:
         *      List<Course> GetCoursesFromCategory(Student a_student, FYP_Category a_category)
         *          a_student --> the student who is being prepackaged
         *          a_category --> the category from which the courses are going to be extracted. 
         *          
         *  DESCRIPTION:
         *      This function obtains all the courses that fall under the category, which are being offered
         *      at Ramapo.
         *  
         *  RETURNS:
         *      List<Course> --> the courses that fall under the specified category. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public List<Course> GetCoursesFromCategory(Student a_student, FYP_Category a_category)
        {
            List<Course> courses = new List<Course>();
            bool isHonors = a_student.Honors;
            foreach (FYP_CourseElement element in a_category.CourseList)
            {
                // Handle the Honors FYS Case
                // If the student is honors and the course element is "intd - 101",
                // find Courses in the course list that represent "hnrs - 101" -- Honors FYS Course.
                if (isHonors == true && element.Title == "intd" && element.Id == "101")
                {
                    foreach (Course course in CourseList)
                    {
                        if (course.Subj == "hnrs" && course.Crse.ToString() == element.Id)
                        {
                            courses.Add(course);
                        }
                    }

                    // Sort courses based on saved cap value
                    SortCourseList(ref courses);
                    return courses;
                }

                // Find the Courses from the course list, corresponding to the FYP_CourseElement in the
                // four-year plan.
                foreach (Course course in CourseList)
                {
                    // Match FYP_CourseElement with Course object
                    if (course.Subj == element.Title && course.Crse.ToString() == element.Id)
                    {
                        int totalCap = course.BannerCap + course.Saved;
                        // Don't add the course if the capacity is 0.
                        if (totalCap != 0)
                        {
                            courses.Add(course);
                        }
                    }
                }
            }

            // If student is honors, select honors courses if applicable. 
            if (a_student.Honors == true)
            {
                FindHonorsCourses(ref courses);
            }
            // If student is not honors, remove honors courses (if applicable). 
            if (a_student.Honors == false)
            {
                RemoveHonorsCourses(ref courses);
            }

            // If the sport != none, the student is an athlete.
            // So, remove courses that conflict with practice times. 
            if (a_student.Sport != "none")
            {
                FilterByPracticeTimes(ref courses, a_student);
            }

            // Remove courses with invalid attributes. (start/end time == -1/0)
            RemoveInvalidCourses(ref courses);

            // Sort courses based on capacity value
            SortCourseList(ref courses);
            return courses;
        }


        /**/
        /*
         *  NAME: 
         *      SortCourseList()
         *  
         *  SYNOPSIS:
         *      void SortCourseList(ref List<Course> a_courseList)
         *          a_courseList --> the list of courses which is to be sorted. 
         *          
         *  DESCRIPTION:
         *      This function sorts the courses (first based on the course id: ex. CMPS 101 comes before CMPS 110)
         *      Within each course Id values, the courses are sorted based on the number of saved seats available.
         *      (One with higher seat count occurs first in the list). 
         *  
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private void SortCourseList(ref List<Course> a_courseList)
        {
            int size = a_courseList.Count;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size - i - 1; j++)
                {
                    // If succeding course has a higher course id, swap. 
                    if (a_courseList[j].Crse.CompareTo(a_courseList[j + 1].Crse) > 0)
                    {
                        SwapCourses(ref a_courseList, j, j + 1);

                    }
                    // if the course ids are equal, sort based on saved seat count. 
                    else if (a_courseList[j].Crse.CompareTo(a_courseList[j + 1].Crse) == 0)
                    {
                        // if the succeding course's saved seat count is greater, swap.  
                        if (a_courseList[j].Saved < a_courseList[j + 1].Saved)
                        {
                            SwapCourses(ref a_courseList, j, j + 1);
                        }

                        // if the saved seat counts are equal, sort by banner cap. 
                        if (a_courseList[j].Saved == a_courseList[j + 1].Saved)
                        {
                            // if the succeding course's banner cap is greater, swap. 
                            if (a_courseList[j].BannerCap < a_courseList[j + 1].BannerCap)
                            {
                                SwapCourses(ref a_courseList, j, j + 1);
                            }
                        }
                    }
                }
            }
        }


        /**/
        /*
         *  NAME: 
         *      SwapCourses()
         *  
         *  SYNOPSIS:
         *      void SwapCourses(ref List<Course> a_courseList, int a_index1, int a_index2)
         *          a_courseList --> list of courses that contains the two elements. 
         *          a_index1 --> index of the first element to be swapped in the list. 
         *          a_index2 --> index of the second element to be swapped in the list. 
         *      
         *          
         *  DESCRIPTION:
         *      This function swaps two course elements in the courseList. 
         *      
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private void SwapCourses(ref List<Course> a_courseList, int a_index1, int a_index2)
        {
            Course temp = a_courseList[a_index1];
            a_courseList[a_index1] = a_courseList[a_index2];
            a_courseList[a_index2] = temp;
        }


        /**/
        /*
         *  NAME: 
         *      FindHonorsCourses()
         *  
         *  SYNOPSIS:
         *      void FindHonorsCourses(ref List<Course> a_courses)
         *          a_courses --> the list of courses. 
         *      
         *          
         *  DESCRIPTION:
         *      If honors courses exists in the list of courses, this function removes all other 
         *      non-honors courses. 
         *      
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private void FindHonorsCourses(ref List<Course> a_courses)
        {
            bool honorsExist = false;
            // Find if honors courses exist. 
            foreach (Course c in a_courses)
            {
                if (c.Subj == "hnrs")
                {
                    honorsExist = true;
                }
            }

            // if honors courses exist, remove all other non-honors courses. 
            if (honorsExist == true)
            {
                for (int i = 0; i < a_courses.Count; i++)
                {
                    if (a_courses[i].Subj != "hnrs")
                    {
                        a_courses.Remove(a_courses[i]);
                        i--;
                    }
                }
            }

        }


        /**/
        /*
         *  NAME: 
         *      RemoveHonorsCourses()
         *  
         *  SYNOPSIS:
         *      void RemoveHonorsCourses(ref List<Course> a_courses)
         *          a_courses --> the list of courses. 
         *      
         *          
         *  DESCRIPTION:
         *      Removes all the honors courses that are present in the list of courses. 
         *      
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private void RemoveHonorsCourses(ref List<Course> a_courses)
        {
            for (int i = 0; i < a_courses.Count; i++)
            {
                if (a_courses[i].Subj == "hnrs")
                {
                    a_courses.Remove(a_courses[i]);
                    i--;
                }
            }
        }


        /**/
        /*
         *  NAME: 
         *      FilterByPracticeTimes()
         *      
         *  SYNOPSIS:
         *      void FilterByPracticeTimes(ref List<Course> a_courses, Student a_student)
         *          a_courses --> the list of courses. 
         *          a_student --> the student who is being prepackaged. 
         *      
         *          
         *  DESCRIPTION:
         *      This function removes all the courses from the courseList that conflict with 
         *      the student's sport practice times. 
         *      
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private void FilterByPracticeTimes(ref List<Course> a_courses, Student a_student)
        {
            // Find the student's sport
            Sport sport = GetStudentSport(a_student);

            // For all the courses in the courseList, remove courses that conflict with the sport's practice times. 
            for (int i = 0; i < a_courses.Count; i++)
            {
                Interval[] intervalList = new Interval[sport.Intervals.Count + 1];
                for(int j = 0; j < sport.Intervals.Count; j++)
                {
                    intervalList[j] = sport.Intervals[j];
                }

                // Interval object for the course. 
                Interval courseInterval = new Interval(a_courses[i].StartTime, a_courses[i].EndTime, a_courses[i].GetDaysString());
                intervalList[intervalList.Length - 1] = courseInterval;
                
                if (IsConflicting(intervalList))
                {
                    a_courses.Remove(a_courses[i]);
                    i--;
                }
            }
        }


        /**/
        /*
         *  NAME: 
         *      GetStudentSport()
         *      
         *  SYNOPSIS:
         *      Sport GetStudentSport(Student a_student)
         *          a_student --> the student who is being prepackaged.     
         *          
         *  DESCRIPTION:
         *      This function obtains the sport object related to a student athlete. 
         *      
         *  RETURNS:
         *      Sport --> The sport object that represents the student athlete's sport. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private Sport GetStudentSport(Student a_student)
        {
            foreach (Sport s in SportList)
            {
                if (a_student.Sport == s.Name)
                {
                    return s;
                }
            }

            Sport nullSport = new Sport();
            return nullSport;
        }


        /**/
        /*
         *  NAME: 
         *      RemoveInvalidCourses()
         *      
         *  SYNOPSIS:
         *      void RemoveInvalidCourses(ref List<Course> a_courses)
         *          a_courses --> list of courses    
         *          
         *  DESCRIPTION:
         *      This function removes all the courses that have invalid start and end times (less than 0). 
         *      
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private void RemoveInvalidCourses(ref List<Course> a_courses)
        {
            for (int i = 0; i < a_courses.Count; i++)
            {
                if (a_courses[i].StartTime < 0 || a_courses[i].EndTime < 0)
                {
                    a_courses.Remove(a_courses[i]);
                    i--;
                }
            }

        }


        /**/
        /*
         *  NAME: 
         *      GetSingleCombinationsList()
         *      
         *  SYNOPSIS:
         *      List<List<Course>> GetSingleCombinationsList(List<List<Course>> a_ultimateList)
         *          a_ultimateList --> List of <list of courses>, each of which represent courses related to each course category.
         *          
         *  DESCRIPTION:
         *      This function returns a list of single combinations, essentially the list of all possible single combination of courses under 
         *      different categories. 
         *      
         *  RETURNS:
         *      List<List<Course>> --> The list containing all possible single combinations of courses.
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public List<List<Course>> GetSingleCombinationsList(List<List<Course>> a_ultimateList)
        {
            // Get a list of all combinations.
            List<List<Course>> singleCombinationsList = new List<List<Course>>();
            
            // Number of lists. 
            int size = a_ultimateList.Count;

            // Keeps tract of next element in the each list.
            int[] indices = new int[size];

            // Initialize the attay with first element's index. 
            for (int i = 0; i < size; i++)
            {
                indices[i] = 0;
            }

            while (true)
            {
                // Add course from each category into a combination list. 
                List<Course> combination = new List<Course>();
                for (int i = 0; i < size; i++)
                {
                    combination.Add(a_ultimateList[i][indices[i]]);
                }
                
                // Add the combination list to the single combination list. 
                singleCombinationsList.Add(combination);

                // Find the rightmost sub-list that has more 
                // elements left after the current element  
                // in that list.
                int next = size - 1;
                while (next >= 0 && (indices[next] + 1 >= a_ultimateList[next].Count))
                {
                    next--;
                }

                // If no such sub-list is found, no combination are left. 
                if (next < 0)
                {
                    break;
                }

                // If sublist is found, move to next element in the list. 
                indices[next]++;

                // For all sublist to the right of this sublist, 
                // current index points to the first element of the sublist. 
                for (int i = next + 1; i < size; i++)
                {
                    indices[i] = 0;
                }
            }

            return singleCombinationsList;
        }


        /**/
        /*
         *  NAME: 
         *      GetMaximumProximityCourses()
         *      
         *  SYNOPSIS:
         *      List<Course> GetMaximumProximityCourses(ref List<List<Course>> a_filteredCombinations)
         *         a_filteredCombinations --> the list of all the combinations of courses from different categories.
         *          
         *  DESCRIPTION:
         *      This function returns the combination of courses which has the maximum proximity (courses are close to each other). 
         *      
         *  RETURNS:
         *      List<Course> --> list of courses that have the maximum proximity. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private List<Course> GetMaximumProximityCourses(ref List<List<Course>> a_filteredCombinations)
        {
            // Set the max comb to first element of the filteredCombinations
            // MaxProximity value is the proximity value of the first element. 
            List<Course> max = a_filteredCombinations[0];
            int maxProximity = GetProximityValue(max);
            
            // Iterate through each combination
            foreach (List<Course> comb in a_filteredCombinations)
            {
                // If proximity value is greater than maxProximity value, replace max combination and maxProximity value. 
                int proximity = GetProximityValue(comb);
                if (proximity > maxProximity)
                {
                    max = comb;
                    maxProximity = proximity;
                }
            }

            return max;
        }

        /**/
        /*
         *  NAME: 
         *      GetProximityValue()
         *      
         *  SYNOPSIS:
         *      int GetProximityValue(List<Course> a_combination)
         *          
         *  DESCRIPTION:
         *      This function returns the proximity value of a combination of courses. 
         *      
         *  RETURNS:
         *      int --> the proximity value of the combination. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private int GetProximityValue(List<Course> a_combination)
        {
            // Initially proximity value is 0. 
            int proximityValue = 0;

            // For each course in combination, compare the day strings with other courses in the combination. 
            // Each time the courses have a common day, increment the proximity value by 1. 
            foreach (Course course in a_combination)
            {
                foreach (char c in course.GetDaysString())
                {
                    foreach (Course otherCourse in a_combination)
                    {
                        if (otherCourse.GetDaysString().Contains(c))
                        {
                            proximityValue++;
                        }
                    }
                }
            }

            return proximityValue;
        }



        /**/
        /*
         *  NAME: 
         *      UpdateCoursesStats()
         *      
         *  SYNOPSIS:
         *      void UpdateCoursesStats(Student a_student)
         *          a_student --> the student who is being prepackaged
         *          
         *  DESCRIPTION:
         *      This function updates courses statistics (updates seat counts) for courses in which
         *      the student has been placed. 
         *      
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private void UpdateCoursesStats(Student a_student)
        {
            foreach (Course c in a_student.PrepackagedCourses)
            {
                int courseIndex = GetCourseIndex(c);
                
                if (courseIndex != -1)
                {
                    // If saved seats is not 0, decrement saved count. 
                    if (CourseList[courseIndex].Saved != 0)
                    {
                        CourseList[courseIndex].Saved--;
                    }
                    else
                    {
                        // If banner cap is not zero, decrement banner count. 
                        if (CourseList[courseIndex].BannerCap != 0)
                        {
                            CourseList[courseIndex].BannerCap--;
                        }
                    }
                }
                // Increase the scheduled student count for the course. 
                CourseList[courseIndex].ScheduledStudents++;
            }
        }



        /**/
        /*
         *  NAME: 
         *      GetCourseIndex()
         *      
         *  SYNOPSIS:
         *      int GetCourseIndex(Course a_course)
         *          a_course --> the course whose index is to be found.
         *          
         *  DESCRIPTION:
         *      This function returns the index of a particular course in the CourseList member variable. 
         *      
         *  RETURNS:
         *      int --> index of the course in CourseList. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private int GetCourseIndex(Course a_course)
        {
            // Compare the crn of the course with elements in the courseList, 
            // if crn is matched, return the index. 
            for (int i = 0; i < CourseList.Count; i++)
            {
                if (a_course.Crn == CourseList[i].Crn)
                {
                    return i;
                }
            }

            return -1;
        }


        /**/
        /*
         *  NAME: 
         *      IsConflicting()
         *      
         *  SYNOPSIS:
         *      bool IsConflicting(Interval[] a_appt)
         *          a_appt --> an array of intervals
         *          
         *  DESCRIPTION:
         *      This function determines if there are time conflicts among the intervals in a_appt array. 
         *      
         *  RETURNS:
         *      True, if time conflicts.
         *      False, otherwise. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private bool IsConflicting(Interval[] a_appt)
        {
            //ITNode root = null;
            //root = Insert(root, appt[0]);
            //for (int i = 1; i < appt.Length; i++)
            //{
            //    Interval res = OverlapSearch(root, appt[i]);
            //    if (res != null)
            //    {
            //        return true;
            //    }

            //    root = Insert(root, appt[i]);
            //}


            // For each interval in appt, check for overlap with other intervals. 
            foreach (Interval i1 in a_appt)
            {
                foreach (Interval i2 in a_appt)
                {
                    if (i1 != i2)
                    {
                        if (DoOverlap(i1, i2))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }


        /**/
        /*
         *  NAME: 
         *      DoOverlap()
         *      
         *  SYNOPSIS:
         *      bool DoOverlap(Interval a_i1, Interval a_i2)
         *          a_i1 --> first interval
         *          a_i2 --> second interval
         *          
         *  DESCRIPTION:
         *      This function determines two intervals passed as parameters overlap or not. 
         *      
         *  RETURNS:
         *      True, if overlaps.
         *      False, otherwise. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private bool DoOverlap(Interval a_i1, Interval a_i2)
        {
            if (a_i1.StartTime < a_i2.EndTime && a_i2.StartTime < a_i1.EndTime && DaysOverlap(a_i1, a_i2))
            {
                return true;
            }
            return false;
        }


        /**/
        /*
         *  NAME: 
         *      DaysOverlap()
         *      
         *  SYNOPSIS:
         *      bool DaysOverlap(Interval a_i1, Interval a_i2)
         *          a_i1 --> first interval
         *          a_i2 --> second interval
         *          
         *  DESCRIPTION:
         *      This function determines if two intervals have the overlap in terms of days. 
         *      (If they have a common day). 
         *      
         *  RETURNS:
         *      True, if overlaps.
         *      False, otherwise. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private bool DaysOverlap(Interval a_i1, Interval a_i2)
        {
            foreach (char c in a_i1.Days)
            {
                if (a_i2.Days.Contains(c.ToString()))
                {
                    return true;
                }
            }

            return false;
        }


        //**************************************************************************************************************************************

        //private ITNode NewNode(Interval i)
        //{
        //    ITNode temp = new ITNode
        //    {
        //        Interval = i,
        //        Max = i.EndTime,
        //    };
        //    temp.Left = temp.Right = null;

        //    return temp;
        //}

        //private ITNode Insert(ITNode root, Interval i)
        //{
        //    if (root == null)
        //        return NewNode(i);

        //    int l = root.Max;

        //    if (i.EndTime < l)
        //    {
        //        root.Left = Insert(root.Left, i);
        //    }
        //    else
        //    {
        //        root.Right = Insert(root.Right, i);
        //    }

        //    if (root.Max < i.EndTime)
        //    {
        //        root.Max = i.EndTime;
        //    }

        //    return root;
        //}



        //Interval OverlapSearch(ITNode root, Interval i)
        //{
        //    if (root == null)
        //    {
        //        return null;
        //    }

        //    if (DoOverlap((root.Interval), i))
        //    {
        //        return root.Interval;
        //    }

        //    if (root.Left != null && root.Left.Max >= i.EndTime)
        //    {
        //        return OverlapSearch(root.Left, i);
        //    }

        //    return OverlapSearch(root.Right, i);
        //}


        //*******************************************************************************************************************************************



    }
}