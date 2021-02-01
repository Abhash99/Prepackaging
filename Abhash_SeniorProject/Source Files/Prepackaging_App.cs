using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrePackaging
{
    /**/
    /*
     *  CLASS DESCRIPTION:
     *      The class contains properties of the Form Application. 
     *  
     *  PURPOSE:
     *      Contains event handlers for various actions performed in the Form app.  
     *  
     *  AUTHOR: 
     *      Abhash Panta
     */
    /**/
    public partial class Prepackaging_App : Form
    {
        // Member Variables

        // Represents the academic year for the four-year-plan.
        private string m_fypYear;

        // Represents the full path of the course information file. 
        private string m_courseFilePath;

        // Represents the full path of the student information file. 
        private string m_studentFilePath;

        // Represents the decision date (the filter) for prepackaging. 
        // Only the students who have made the decison to enroll prior to this
        // date will be prepackaged.
        private DateTime m_decisionDate;

        // Represents the full path of the output directory. The output file will be saved
        // in this location. 
        private string m_outputDirectoryPath;

        // Represents the full path of the atheletes information excel file. 
        private string m_athleteFilePath;

        // Represents the full path of the sport information excel file. 
        private string m_sportFilePath;


        // Properties for member variables. 
        public string CourseFilePath { get => m_courseFilePath; set => m_courseFilePath = value; }
        public string FypYear { get => m_fypYear; set => m_fypYear = value; }
        public string StudentFilePath { get => m_studentFilePath; set => m_studentFilePath = value; }
        public DateTime DecisionDate { get => m_decisionDate; set => m_decisionDate = value; }
        public string OutputDirectoryPath { get => m_outputDirectoryPath; set => m_outputDirectoryPath = value; }
        public string AthleteFilePath { get => m_athleteFilePath; set => m_athleteFilePath = value; }
        public string SportFilePath { get => m_sportFilePath; set => m_sportFilePath = value; }


        /**/
        /*
         *  NAME: Prepackaging_App()
         *  
         *  SYNOPSIS:
         *      Prepackaging_App() 
         *         
         *  DESCRIPTION:
         *      Constructor for the Form App. It calls the default InitializeComponent() function. 
         *      Also, initializes the member variables. 
         *  
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        public Prepackaging_App()
        {
            InitializeComponent();
            m_fypYear = "";
            m_courseFilePath = "";
            m_studentFilePath = "";
            m_decisionDate = DateTime.MinValue;
            m_outputDirectoryPath = "";
            m_athleteFilePath = "";
            m_sportFilePath = "";
        }


        /**/
        /*
         *  NAME: Button_courseFile_Click()
         *  
         *  SYNOPSIS:
         *      void Button_courseFile_Click(object sender, EventArgs e)
         *          sender --> the object that created the event. 
         *          e --> the event itself (in this case the button click).
         *         
         *  DESCRIPTION:
         *      Get the path of the course information file from OpenFileDialog.
         *      Saves the path to the member variable and prints the name of the file
         *      to the label beside the button. 
         *  
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private void Button_courseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileFialog1 = new OpenFileDialog();

            // Open FileDialog to obtain the path of the course information file. 
            if (openFileFialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CourseFilePath = openFileFialog1.FileName;
                
                // Get filename without the full path and display it in the label. 
                string[] tokens = CourseFilePath.Split('\\');
                string filename = tokens[tokens.Length - 1];
                Label_displayCourseFile.Text = filename;
                
            }
        }

        /**/
        /*
         *  NAME: Button_studentFile_Click()
         *  
         *  SYNOPSIS:
         *      void Button_studentFile_Click(object sender, EventArgs e)
         *          sender --> the object that created the event. 
         *          e --> the event itself (in this case the button click).
         *         
         *  DESCRIPTION:
         *      Get the path of the student information file from OpenFileDialog.
         *      Saves the path to the member variable and prints the name of the file
         *      to the label beside the button. 
         *  
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private void Button_studentFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileFialog1 = new OpenFileDialog();

            // Open FileDialog to obtain the path of the course information file. 
            if (openFileFialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StudentFilePath = openFileFialog1.FileName;

                // Get filename without the full path and display it in the label. 
                string[] tokens = StudentFilePath.Split('\\');
                string filename = tokens[tokens.Length - 1];
                Label_displayStudentFile.Text = filename;
            }

        }

        /**/
        /*
         *  NAME: Button_OutputFile_Click()
         *  
         *  SYNOPSIS:
         *      void Button_OutputFile_Click(object sender, EventArgs e)
         *          sender --> the object that created the event. 
         *          e --> the event itself (in this case the button click).
         *         
         *  DESCRIPTION:
         *      Get the path of the Output directory from FolderBrowserDialog.
         *      Saves the path to the member variable and prints the name of the folder
         *      to the label beside the button. 
         *  
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private void Button_OutputFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            // Open FileDialog to obtain the path of the Output folder. 
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                OutputDirectoryPath = fbd.SelectedPath;

                // Get filename without the full path and display it in the label. 
                string[] tokens = OutputDirectoryPath.Split('\\');
                string filename = tokens[tokens.Length - 1];
                Label_DisplayOutputDir.Text = filename;
            }
        }

        /**/
        /*
         *  NAME: Button_startPrepackaging_Click()
         *  
         *  SYNOPSIS:
         *      void Button_startPrepackaging_Click(object sender, EventArgs e)
         *          sender --> the object that created the event. 
         *          e --> the event itself (in this case the button click).
         *         
         *  DESCRIPTION:
         *      Obtains the input from the textBox and DateTime picker, validates that all the required information has been
         *      given by the user and starts prepackaging process. 
         *  
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private void Button_startPrepackaging_Click(object sender, EventArgs e)
        {
            // Get year and decisionDate from the form app input. 
            FypYear = TextBox_FypYear.Text;
            DecisionDate = DatePicker_descDate.Value;


            // If all information is present, start prepackaging
            // Else, diplay a messagebox requesting user to fill in all the information. 
            if (ValidateStartButton() == true)
            {
                Prepackager packager = new Prepackager(FypYear, CourseFilePath, StudentFilePath, DecisionDate, OutputDirectoryPath, AthleteFilePath, SportFilePath);
                packager.StartPrepackaging();
            }
            else
            {
                MessageBox.Show("Information needed for prepackaging is incomplete. Please complete all the information. ");
            }
        }


        /**/
        /*
         *  NAME: ValidateStartButton()
         *  
         *  SYNOPSIS:
         *      bool ValidateStartButton()
         *         
         *  DESCRIPTION:
         *      Validates that all the required information has been given by the user by comparing the values of the member
         *      variables to default values. 
         *  
         *  RETURNS:
         *      True if all the required information has been given. 
         *      False, otherwise. 
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private bool ValidateStartButton()
        {
            if (FypYear != "" && CourseFilePath != "" && StudentFilePath != "" && DecisionDate != DateTime.MinValue && OutputDirectoryPath != "" && AthleteFilePath != "" && SportFilePath != "")
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
         *      Button_AthleteFile_Click()
         *  
         *  SYNOPSIS:
         *      void Button_AthleteFile_Click(object sender, EventArgs e)
         *          sender --> the object that created the event. 
         *          e --> the event itself (in this case, the button click).
         *         
         *  DESCRIPTION:
         *      Get the path of the athletes information file from OpenFileDialog.
         *      Saves the path to the member variable and prints the name of the file
         *      to the label beside the button. 
         *  
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private void Button_AthleteFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileFialog1 = new OpenFileDialog();

            // Open FileDialog to obtain the path of the athletes information file. 
            if (openFileFialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                AthleteFilePath = openFileFialog1.FileName;

                // Get filename without the full path and display it in the label. 
                string[] tokens = AthleteFilePath.Split('\\');
                string filename = tokens[tokens.Length - 1];
                Label_displayAthleteFile.Text = filename;
            }

        }

        /**/
        /*
         *  NAME: 
         *      Button_SportFile_Click()
         *  
         *  SYNOPSIS:
         *      void Button_SportFile_Click(object sender, EventArgs e)
         *          sender --> the object that created the event. 
         *          e --> the event itself (in this case, the button click).
         *         
         *  DESCRIPTION:
         *      Get the path of the sport information file from OpenFileDialog.
         *      Saves the path to the member variable and prints the name of the file
         *      to the label beside the button. 
         *  
         *  RETURNS:
         *      None
         *      
         *  AUTHOR:
         *      Abhash Panta
         */
        /**/
        private void Button_SportFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileFialog1 = new OpenFileDialog();

            // Open FileDialog to obtain the path of the sports information file. 
            if (openFileFialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SportFilePath = openFileFialog1.FileName;

                // Get filename without the full path and display it in the label. 
                string[] tokens = SportFilePath.Split('\\');
                string filename = tokens[tokens.Length - 1];
                Label_displaySportFile.Text = filename;
            }

        }
    }
}
