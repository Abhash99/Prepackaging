using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Xml;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PrePackaging
{
    /**/
    /*
     *  CLASS DESCRIPTION:
     *      The class responsible for parsing Four-Year Plans from the ramapo four-year plan webpage. 
     *  
     *  PURPOSE: 
     *      To read four-year-plan from the web for each major in Ramapo College and create a usuable format of the FYP
     *      for each major. 
     *      
     *  AUTHOR: 
     *      Abhash Panta
     */
    /**/
    class Webscraper
    {
        // Member Variables
        // m_year represents the academic-year for the four-year plan
        private string m_year;

        // m_url represents the url that holds the list of majors and their respective four-year plans
        private string m_url;

        // Properties for the member variables
        public string Year { get => m_year; set => m_year = value; }
        public string Url { get => m_url; set => m_url = value; }


        /**/
        /*
         *  NAME: 
         *      Webscraper()
         *  
         *  SYNOPSIS:
         *      Webscraper()
         *         
         *  DESCRIPTION:
         *      Default Constructor for Webscraper Class.
         *      Set m_year to 2019-2020 by default. 
         *      The url is based on the year. 
         *     
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public Webscraper()
        {
            Year = "2019-2020";
            Url = "https://www.ramapo.edu/four-year-" + Year + "/";
        }

        /**/
        /*
         *  NAME: 
         *      Webscraper()
         *  
         *  SYNOPSIS:
         *      Webscraper(string a_year)
         *          a_year --> the academic year for the four-year plan
         *         
         *  DESCRIPTION:
         *      Parametrized constructor for Webscraper class. 
         *      Sets m_year based on the parameter.
         *      Sets url based on the academic year. 
         *     
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public Webscraper(string a_year)
        {
            this.Year = a_year;
            Url = "http://www.ramapo.edu/four-year-" + Year + "/";
            // TO DO: Validate URL and throw exception
        }

        // TO DO: URL Validation
        /**/
        /*
         *  NAME: 
         *      GetFourYearPlans()
         *  
         *  SYNOPSIS:
         *      List<Major> GetFourYearPlans()
         *         
         *  DESCRIPTION:
         *      Obtain the FYP representation for each major offered
         *      at Ramapo from the four-year plan webpage. 
         *     
         *  RETURNS:
         *      List<Major> --> List of Major objects, each of which represents
         *      the FYP for that particular major. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public List<Major> GetFourYearPlans()
        {
            // Parse the webpage containing the list of all majors
            // Each major listed acts as a link to its four-year-plan
            WebClient client = new WebClient();

            // Get the html source as a string
            string htmlCode = client.DownloadString(Url);

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlCode);

            // Holds all the list elements <li> from the html source code
            List<HtmlNode> facts = new List<HtmlNode>();
            // Holds only the majors <li> elements filtered from the facts
            List<HtmlNode> MajorLinks = new List<HtmlNode>();

            // Get all the <li> elements from the source code and add it to facts 
            foreach (HtmlNode li in htmlDoc.DocumentNode.SelectNodes("//div/ul/li"))
            {
                facts.Add(li);
            }

            // Filter out all the unnecessary <li> elements from the facts.
            // Since "Accounting" is the first major and "Undecided" is the last
            // major in the list, we use these as reference points to filter <li> elements.
            
            // NOTE: Changes to the Major List in the webpage (adding of major) might affect
            // the results. 
            for (int i = 0; i < facts.Count; i++)
            {
                if (facts[i].InnerText.ToLower() == "Accounting".ToLower())
                {
                    while (facts[i].InnerText.ToLower() != "Undecided".ToLower())
                    {
                        MajorLinks.Add(facts[i]);
                        i++;
                    }
                    if (facts[i].InnerText.ToLower() == "Undecided".ToLower())
                    {
                        MajorLinks.Add(facts[i]);
                    }
                }
            }

            // Get a list of all the urls corresponding to the major in the homepage
            List<string> urlList = new List<string>();
            foreach (HtmlNode maj in MajorLinks)
            {
                string tempUrl = maj.Element("a").GetAttributeValue("href", "unknown");
                urlList.Add(tempUrl);
            }

            // Get the list of pagesources for each major url as string
            List<string> pageSourceList = GetPageSource(urlList);

            // List to hold all the Majors with their respective Four-Year-Plan representation
            List<Major> majorList = new List<Major>();

            // For each majorLink, we parse the corresponding pageSource, obtain the necessary elements,
            // create a new Major object and add it to the majorList. 
            for (int i = 0; i < pageSourceList.Count; i++)
            {
                HtmlNode maj = MajorLinks.ElementAt(i);

                // Major name is the inner text of the link.
                String majName = maj.InnerText.ToLower();
                // Major ID (Unique id) is held in the attribute called "data-guid" within the link. 
                String majId = maj.Element("a").GetAttributeValue("data-guid", "unknown").ToLower();

                // Create a new major and add it to the list. 
                Major major = new Major(majName, majId, ParseMajor(pageSourceList.ElementAt(i)));
                majorList.Add(major);
            }
            return majorList; 
        }

        /**/
        /*
         *  NAME: 
         *      ParseMajor()
         *  
         *  SYNOPSIS:
         *      List<FYP_Category> ParseMajor(string a_htmlCode)
         *          a_htmlCode --> the source code of the four-year plan for a 
         *                         particular major
         *         
         *  DESCRIPTION:
         *      Parse the html source code to obtain the list of FYP_Cateogies which contains 
         *      individual FYP_CourseElements. 
         *     
         *  RETURNS:
         *      List<FYP_Category> --> List of FYP_Categories. Each row in the four-year plan table 
         *                             in the webpage is a FYP_Category. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private List<FYP_Category> ParseMajor(string a_htmlCode)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(a_htmlCode);

            // Get all the elements (list items) representing a category of course from the four-year plan
            List<HtmlNode> facts = new List<HtmlNode>();
            foreach (HtmlNode li in htmlDoc.DocumentNode.SelectNodes(@"//div[@class='fouryear']/ul/li"))
            {
                facts.Add(li);
            }

            // Get the FYP_Category from each list item
            // FYP_Category will contain the list of all the CourseElements
            List<FYP_Category> categoryList = new List<FYP_Category>();
            foreach (HtmlNode li in facts)
            {
                // NOTE: We add the Total row into the FYP_Category list 
                // because it helps us differentiate courses from different 
                // semesters. 
                if (li.InnerText.StartsWith("Total"))
                {
                    // Set the name but list of courseElements is null.
                    FYP_Category category = new FYP_Category
                    {
                        Name = li.InnerText.ToLower()
                    };
                    categoryList.Add(category);
                }
                else
                {
                    // Obtain the FYP_Category object. If it is null, don't add it to the categoryList. 
                    FYP_Category category = GetCourseCategory(li);
                    if (category.IsNull() == false)
                    {
                        categoryList.Add(category);
                    }
                }
            }

            return categoryList;
        }

        /**/
        /*
         *  NAME: 
         *      GetPageSource()
         *  
         *  SYNOPSIS:
         *      List<string> GetPageSource(List<string> a_urlList)
         *          a_urlList --> the list of url strings which are the url for each major's 
         *                        Four-Year Plan page. 
         *         
         *  DESCRIPTION:
         *      Uses the Selenium driver and ChromeDriver to navigate to each major's FYP url, 
         *      click on the clickable elements to expand the hidden elements and obtain the html
         *      source code, and add the source code string to the list. 
         *     
         *  RETURNS:
         *      List<string> --> the list that contains the html source codes for each major's FYP page. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private List<string> GetPageSource(List<string> a_urlList)
        {
            // Use selenium to open chrome browser in the background. 
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("--headless");
            option.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(option);

            List<string> htmlCodeList = new List<string>();
            // Navigate to each url in the a_urlList, click on the elements 
            // that have the class name "bannerDetailed".
            // This unhides the hidden elements (like list of courses) that are required for the parsing the FYP page. 
            foreach (string url in a_urlList)
            {
                driver.Navigate().GoToUrl(url);
                var allClickables = driver.FindElements(By.ClassName("bannerDetailed"));
                foreach (IWebElement element in allClickables)
                {
                    // NOTE: We need to click on all clickables but sometimes the page might not load on time. 
                    // We might get an exception. So, we keep clicking on these elements until the click succeeds. 

                    ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(" + element.Location.X + "," + element.Location.Y + ")");
                    
                    // Click success flag.
                    Boolean clickSuccess = false;
                    while (clickSuccess == false)
                    {
                        try
                        {
                            element.Click();
                            clickSuccess = true;
                        }
                        catch
                        {
                            // if we catch an exception, we set the flag to false. 
                            clickSuccess = false;
                        }
                    }
                }

                // Get the page source and add it to the list. 
                string pageSource = driver.PageSource;
                htmlCodeList.Add(pageSource);
            }
            driver.Close();
            driver.Dispose();
            driver.Quit();

            return htmlCodeList;
        }



        /**/
        /*
         *  NAME: 
         *      GetCourseCategory()
         *  
         *  SYNOPSIS:
         *      FYP_Category GetCourseCategory(HtmlNode a_li)
         *          a_li --> a list element that contains a course category
         *                   (each category is a li element in the html source code)
         *         
         *  DESCRIPTION:
         *      Finds the type of category and obtains the FYP_Category object by parsing the html 
         *      elements based on the type of category. 
         *        
         *     
         *  RETURNS:
         *     FYP_Category --> The FYP_Category object that holds the list of course elements that fall
         *                      under that category. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private FYP_Category GetCourseCategory(HtmlNode a_li)
        {
            int type = GetCategoryType(a_li);

            // type == 0 refers to a single course. Ex. MATH 110
            if (type == 0)
            {
                HtmlNode span = a_li.SelectSingleNode(".//span");
                FYP_Category category = GetSingleCourse(span);
                
                // Obtain the category name and preprend it to the categoryName
                if (category.IsNull() == false)
                {
                    string categoryTypeName = GetCategoryTypeName(a_li);
                    category.Name = category.Name.Insert(0, categoryTypeName + ":");
                }
                return category;
                
            }
            // type == 1 refers to a single category with multiple listings.
            // Ex. Gen Ed: Social Science Inquiry
            else if (type == 1)
            {
                HtmlNode span = a_li.SelectSingleNode(".//span");
                FYP_Category category = GetMultipleCourses(span);

                // Obtain the category name and preprend it to the categoryName
                if (category.IsNull() == false)
                {
                    string categoryTypeName = GetCategoryTypeName(a_li);
                    category.Name = category.Name.Insert(0, categoryTypeName + ":");
                }
                return category;
            }
            // type == 2 refers to a list element that holds multiple categories
            // Ex 1. MATH 108 or MATH 110 or MATH 121
            // EX 2. 'Gen Ed: Systems, Sustainability' and 'Society OR Gen Ed; Culture and Creativity'
            else if (type == 2)
            {
                FYP_Category composite = new FYP_Category();
                
                // For this kind of category, the format is a little different. The list element a_li has 
                // multiple "span" elements, each of which represents one category. 
                // So, we need to combine those categories into one single FYP_Category. 
                HtmlNodeCollection coll = a_li.ChildNodes;
                foreach (HtmlNode childNode in coll)
                {
                    if (childNode.Name == "span")
                    {
                        // NOTE: The multiple explicit category type (type == 2) is a combination of 
                        // type 0 and/or type 1 categories.
                        // This is where we apply the overloaded + operator defined for FYP_Category class. 
                        if (IsSingle(childNode))
                        {
                            composite += GetSingleCourse(childNode);
                        }
                        else
                        {
                            composite += GetMultipleCourses(childNode);
                        }
                    }
                }

                // Obtain the category name and preprend it to the categoryName
                if (composite.IsNull() == false)
                {
                    string categoryTypeName = GetCategoryTypeName(a_li);
                    composite.Name = composite.Name.Insert(0, categoryTypeName + ":");
                }
                return composite;
            }
            
            // In case of any exceptions, return a null category.
            // NOTE: A lot of the categories that don't have specific courses listed in the FYP
            // will be returned as null FYP_Category.
            // We avoid adding the null categories to out final list of FYP_Categories. 
            FYP_Category nullCategory = new FYP_Category();
            return nullCategory;
            
        }


        /**/
        /*
         *  NAME: 
         *    GetCategoryTypeName()
         *  
         *  SYNOPSIS:
         *      int GetCategoryTypeName(HtmlNode a_li)
         *          a_li --> a list element that contains a course category
         *                   (each category is a li element in the html source code)
         *         
         *  DESCRIPTION:
         *      Obtains the type of category based on the innerText of the html <li> tag.
         *      Ex. Gen Ed, Major, School Core, etc. 
         *          
         *     
         *  RETURNS:
         *      Returns the category type in string format (lowercase). Ex. "gen ed", "major", "school core", etc. 
         *      Returns empty string if category type is not present. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private string GetCategoryTypeName(HtmlNode a_li)
        {
            // Get the categoryType (Gen Ed, School Core, Major, etc)
            string innerText = a_li.InnerText.ToString();

            // Note: The innertext of the links begin in the following format:
            // Ex. Gen Ed: <rest of the text>
            // Ex. Major: <rest of the text>
            // So, we obtain the 1st substring until the ':' character. 
            int index = innerText.IndexOf(":");

            if (index >= 0)
            {
                return innerText.Substring(0, innerText.IndexOf(":")).ToLower();
            }
            // If the substring is not present, we return an empty string. 
            else
            {
                return "";
            }
        }


        /**/
        /*
         *  NAME: 
         *    GetCategoryType()
         *  
         *  SYNOPSIS:
         *      int GetCategoryType(HtmlNode a_li)
         *          a_li --> a list element that contains a course category
         *                   (each category is a li element in the html source code)
         *         
         *  DESCRIPTION:
         *      Determines the type of category:
         *          0 --> Single --> Single Course. Ex. MATH 101
         *          1 --> Multiple (Implicit) --> A single category with multiple courses. Ex. "Gen Ed. Social Science Inquiry"
         *          2 --> Multiple (Explicit) --> Multiple categories combined. Ex. "ECON 101 or ECON 102".
         *          
         *        
         *     
         *  RETURNS:
         *     int --> an integer who value represents the type of category. 
         *             0 --> single
         *             1 --> multiple (implicit)
         *             2 --> multiple (explicit)
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private int GetCategoryType(HtmlNode a_li)
        {
            int count = 0;
            HtmlNodeCollection coll = a_li.ChildNodes;
            
            // We count the number of "span" child nodes the list element has. 
            foreach (HtmlNode childNode in coll)
            {
                if (childNode.Name == "span")
                {
                    count++;
                }
            }

            // Single and Multiple implicit types have only one "span" child. 
            if (count == 1)
            {
                HtmlNode child = a_li.SelectSingleNode(".//span");
                // if it is a single element (ex. MATH 101), return 0
                if (IsSingle(child))
                {
                    return 0;
                }
                // if it is a listing element (ex. Gen Ed: Social Science Inquiry), return 1. 
                else
                {
                    return 1;
                } 
            }

            // Multiple explicit type has more than one "span" child, return 2. 
            return 2;
        }


        /**/
        /*
         *  NAME: 
         *      IsSingle()
         *  
         *  SYNOPSIS:
         *      bool IsSingle(HtmlNode a_span)
         *          a_span --> the span element which represents a single category.
         *         
         *  DESCRIPTION:
         *      Determines whether the span element is a single element or a listing.
         *        
         *     
         *  RETURNS:
         *      True --> if the span element is a single element. 
         *      False --> if the span element is a listing element. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private bool IsSingle(HtmlNode a_span)
        {
            HtmlNode child = a_span.SelectSingleNode(".//a");
            
            // NOTE: the <a> element within the span has an attribute called data-type. 
            // if the data-type value is single, it is a single element. 
            // Else, the data-type is listing.
            if (child != null && child.Attributes["data-type"].Value == "single")
            {
                return true;
            }

            return false;
        }


        /**/
        /*
         *  NAME: 
         *      GetSingleCourse()
         *  
         *  SYNOPSIS:
         *      FYP_Category GetSingleCourse(HtmlNode a_span)
         *          a_span --> the span element which represents a single category.
         *         
         *  DESCRIPTION:
         *      Obtains the FYP_Category from a single element (type == 0). 
         *        
         *  RETURNS:
         *      FYP_Category --> the FYP_Category object that represents the single course. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private FYP_Category GetSingleCourse(HtmlNode a_span)
        {
            FYP_Category category = new FYP_Category();

            
            HtmlNode child = a_span.SelectSingleNode(".//a");
            // Need to handle case where a_span element might not have any <a> element as child. 
            if (child != null)
            {
                // Obtain the attributes of the category and course element from the <a> element. 
                string categoryName = child.InnerText.ToLower();
                string courseTitle = child.Attributes["data-subject"].Value.ToLower();
                string courseId = child.Attributes["data-id"].Value.ToLower();

                // Create a new list of FYP_CourseElement and add a newly created FYP_CourseElement to it. 
                // NOTE: the list of FYP_CourseElement will only have one course in this case. 
                List<FYP_CourseElement> courseList = new List<FYP_CourseElement>();
                FYP_CourseElement course = new FYP_CourseElement(courseTitle, courseId);
                courseList.Add(course);

                // Create a new category and return the category.
                category = new FYP_Category(categoryName, courseList);
            }
            return category;
        }


        /**/
        /*
         *  NAME: 
         *      GetMultipleCourses()
         *  
         *  SYNOPSIS:
         *      FYP_Category GetMultipleCourses(HtmlNode a_span)
         *          a_span --> the span element which represents a single category.
         *         
         *  DESCRIPTION:
         *      Obtains the FYP_Category from a listing category type (ex. GEN ED. Social Science Inquiry)
         *      by parsing the html cource code. 
         *      
         *  RETURNS:
         *      FYP_Category --> the FYP_Category object which represents multiple courses that belong to 
         *                       a particular category. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private FYP_Category GetMultipleCourses(HtmlNode a_span)
        {
            FYP_Category category = new FYP_Category();
            HtmlNode child = a_span.SelectSingleNode(".//a");

            // Need to handle case where a_span element might not have any <a> element as child. 
            if (child != null)
            {
                string categoryName = child.InnerText.ToLower();
                
                // NOTE: If the type is a listing (type == 1), there is a specific html format of 
                // how the course elements are listed.
                HtmlNodeCollection subCategories = a_span.SelectNodes(".//span/p/span/a");
                
                List<FYP_CourseElement> courseList = new List<FYP_CourseElement>();

                if (subCategories != null && subCategories.Count != 0)
                {
                    // Each element in the subCategories represents a single courseElement.
                    // We create a FYP_CourseElement for each element in subCategories and add
                    // it to a list of FYP_CourseElement. 
                    foreach (HtmlNode element in subCategories)
                    {
                        string courseTitle = element.Attributes["data-subject"].Value.ToLower();
                        string courseId = element.Attributes["data-id"].Value.ToLower();
                        FYP_CourseElement course = new FYP_CourseElement(courseTitle, courseId);
                        courseList.Add(course);
                    }
                }
                
                // Finally, we create the FYP_Category with the categoryName and courseList obtained. 
                category = new FYP_Category(categoryName, courseList);
            }

            // NOTE: If the a_span has no <a> element, a null FYP_Category object is returned. 
            return category;
        }
    }
    
}
