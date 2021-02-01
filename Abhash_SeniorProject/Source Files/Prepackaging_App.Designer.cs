namespace PrePackaging
{
    partial class Prepackaging_App
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Prepackaging_App));
            this.Input = new System.Windows.Forms.GroupBox();
            this.Label_displaySportFile = new System.Windows.Forms.Label();
            this.Label_displayAthleteFile = new System.Windows.Forms.Label();
            this.Button_SportFile = new System.Windows.Forms.Button();
            this.Label_SportFile = new System.Windows.Forms.Label();
            this.Button_AthleteFile = new System.Windows.Forms.Button();
            this.Label_AthleteFile = new System.Windows.Forms.Label();
            this.Label_displayStudentFile = new System.Windows.Forms.Label();
            this.Label_displayCourseFile = new System.Windows.Forms.Label();
            this.Button_studentFile = new System.Windows.Forms.Button();
            this.Button_courseFile = new System.Windows.Forms.Button();
            this.Label_studentFile = new System.Windows.Forms.Label();
            this.Label_courseFile = new System.Windows.Forms.Label();
            this.Label_descDate = new System.Windows.Forms.Label();
            this.DatePicker_descDate = new System.Windows.Forms.DateTimePicker();
            this.Label_fypYearEx = new System.Windows.Forms.Label();
            this.Label_fypYear = new System.Windows.Forms.Label();
            this.TextBox_FypYear = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Output = new System.Windows.Forms.GroupBox();
            this.Label_DisplayOutputDir = new System.Windows.Forms.Label();
            this.Button_OutputFile = new System.Windows.Forms.Button();
            this.Label_outputFile = new System.Windows.Forms.Label();
            this.Button_startPrepackaging = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Input.SuspendLayout();
            this.Output.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Input
            // 
            this.Input.Controls.Add(this.Label_displaySportFile);
            this.Input.Controls.Add(this.Label_displayAthleteFile);
            this.Input.Controls.Add(this.Button_SportFile);
            this.Input.Controls.Add(this.Label_SportFile);
            this.Input.Controls.Add(this.Button_AthleteFile);
            this.Input.Controls.Add(this.Label_AthleteFile);
            this.Input.Controls.Add(this.Label_displayStudentFile);
            this.Input.Controls.Add(this.Label_displayCourseFile);
            this.Input.Controls.Add(this.Button_studentFile);
            this.Input.Controls.Add(this.Button_courseFile);
            this.Input.Controls.Add(this.Label_studentFile);
            this.Input.Controls.Add(this.Label_courseFile);
            this.Input.Controls.Add(this.Label_descDate);
            this.Input.Controls.Add(this.DatePicker_descDate);
            this.Input.Controls.Add(this.Label_fypYearEx);
            this.Input.Controls.Add(this.Label_fypYear);
            this.Input.Controls.Add(this.TextBox_FypYear);
            this.Input.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Input.ForeColor = System.Drawing.Color.White;
            this.Input.Location = new System.Drawing.Point(12, 330);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(537, 312);
            this.Input.TabIndex = 0;
            this.Input.TabStop = false;
            this.Input.Text = "Input";
            // 
            // Label_displaySportFile
            // 
            this.Label_displaySportFile.AutoSize = true;
            this.Label_displaySportFile.Location = new System.Drawing.Point(347, 237);
            this.Label_displaySportFile.Name = "Label_displaySportFile";
            this.Label_displaySportFile.Size = new System.Drawing.Size(0, 20);
            this.Label_displaySportFile.TabIndex = 16;
            // 
            // Label_displayAthleteFile
            // 
            this.Label_displayAthleteFile.AutoSize = true;
            this.Label_displayAthleteFile.Location = new System.Drawing.Point(347, 197);
            this.Label_displayAthleteFile.Name = "Label_displayAthleteFile";
            this.Label_displayAthleteFile.Size = new System.Drawing.Size(0, 20);
            this.Label_displayAthleteFile.TabIndex = 15;
            // 
            // Button_SportFile
            // 
            this.Button_SportFile.BackColor = System.Drawing.Color.Silver;
            this.Button_SportFile.ForeColor = System.Drawing.Color.Black;
            this.Button_SportFile.Location = new System.Drawing.Point(196, 228);
            this.Button_SportFile.Name = "Button_SportFile";
            this.Button_SportFile.Size = new System.Drawing.Size(135, 29);
            this.Button_SportFile.TabIndex = 14;
            this.Button_SportFile.Text = "Choose File";
            this.Button_SportFile.UseVisualStyleBackColor = false;
            this.Button_SportFile.Click += new System.EventHandler(this.Button_SportFile_Click);
            // 
            // Label_SportFile
            // 
            this.Label_SportFile.AutoSize = true;
            this.Label_SportFile.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_SportFile.Location = new System.Drawing.Point(6, 233);
            this.Label_SportFile.Name = "Label_SportFile";
            this.Label_SportFile.Size = new System.Drawing.Size(171, 18);
            this.Label_SportFile.TabIndex = 13;
            this.Label_SportFile.Text = "Sports Information File:";
            // 
            // Button_AthleteFile
            // 
            this.Button_AthleteFile.BackColor = System.Drawing.Color.Silver;
            this.Button_AthleteFile.ForeColor = System.Drawing.Color.Black;
            this.Button_AthleteFile.Location = new System.Drawing.Point(196, 188);
            this.Button_AthleteFile.Name = "Button_AthleteFile";
            this.Button_AthleteFile.Size = new System.Drawing.Size(135, 29);
            this.Button_AthleteFile.TabIndex = 12;
            this.Button_AthleteFile.Text = "Choose File";
            this.Button_AthleteFile.UseVisualStyleBackColor = false;
            this.Button_AthleteFile.Click += new System.EventHandler(this.Button_AthleteFile_Click);
            // 
            // Label_AthleteFile
            // 
            this.Label_AthleteFile.AutoSize = true;
            this.Label_AthleteFile.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_AthleteFile.Location = new System.Drawing.Point(6, 193);
            this.Label_AthleteFile.Name = "Label_AthleteFile";
            this.Label_AthleteFile.Size = new System.Drawing.Size(180, 18);
            this.Label_AthleteFile.TabIndex = 11;
            this.Label_AthleteFile.Text = "Athlete Information File:";
            // 
            // Label_displayStudentFile
            // 
            this.Label_displayStudentFile.AutoSize = true;
            this.Label_displayStudentFile.Location = new System.Drawing.Point(347, 153);
            this.Label_displayStudentFile.Name = "Label_displayStudentFile";
            this.Label_displayStudentFile.Size = new System.Drawing.Size(0, 20);
            this.Label_displayStudentFile.TabIndex = 10;
            // 
            // Label_displayCourseFile
            // 
            this.Label_displayCourseFile.AutoSize = true;
            this.Label_displayCourseFile.Location = new System.Drawing.Point(347, 114);
            this.Label_displayCourseFile.Name = "Label_displayCourseFile";
            this.Label_displayCourseFile.Size = new System.Drawing.Size(0, 20);
            this.Label_displayCourseFile.TabIndex = 9;
            // 
            // Button_studentFile
            // 
            this.Button_studentFile.BackColor = System.Drawing.Color.Silver;
            this.Button_studentFile.ForeColor = System.Drawing.Color.Black;
            this.Button_studentFile.Location = new System.Drawing.Point(196, 149);
            this.Button_studentFile.Name = "Button_studentFile";
            this.Button_studentFile.Size = new System.Drawing.Size(135, 29);
            this.Button_studentFile.TabIndex = 8;
            this.Button_studentFile.Text = "Choose File";
            this.Button_studentFile.UseVisualStyleBackColor = false;
            this.Button_studentFile.Click += new System.EventHandler(this.Button_studentFile_Click);
            // 
            // Button_courseFile
            // 
            this.Button_courseFile.BackColor = System.Drawing.Color.Silver;
            this.Button_courseFile.ForeColor = System.Drawing.Color.Black;
            this.Button_courseFile.Location = new System.Drawing.Point(196, 105);
            this.Button_courseFile.Name = "Button_courseFile";
            this.Button_courseFile.Size = new System.Drawing.Size(135, 29);
            this.Button_courseFile.TabIndex = 7;
            this.Button_courseFile.Text = "Choose File";
            this.Button_courseFile.UseVisualStyleBackColor = false;
            this.Button_courseFile.Click += new System.EventHandler(this.Button_courseFile_Click);
            // 
            // Label_studentFile
            // 
            this.Label_studentFile.AutoSize = true;
            this.Label_studentFile.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_studentFile.Location = new System.Drawing.Point(6, 144);
            this.Label_studentFile.Name = "Label_studentFile";
            this.Label_studentFile.Size = new System.Drawing.Size(186, 18);
            this.Label_studentFile.TabIndex = 6;
            this.Label_studentFile.Text = "Student Information File: ";
            // 
            // Label_courseFile
            // 
            this.Label_courseFile.AutoSize = true;
            this.Label_courseFile.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_courseFile.Location = new System.Drawing.Point(6, 105);
            this.Label_courseFile.Name = "Label_courseFile";
            this.Label_courseFile.Size = new System.Drawing.Size(184, 18);
            this.Label_courseFile.TabIndex = 5;
            this.Label_courseFile.Text = "Course Information File: ";
            // 
            // Label_descDate
            // 
            this.Label_descDate.AutoSize = true;
            this.Label_descDate.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_descDate.Location = new System.Drawing.Point(6, 70);
            this.Label_descDate.Name = "Label_descDate";
            this.Label_descDate.Size = new System.Drawing.Size(115, 18);
            this.Label_descDate.TabIndex = 4;
            this.Label_descDate.Text = "Decision Date:";
            // 
            // DatePicker_descDate
            // 
            this.DatePicker_descDate.Location = new System.Drawing.Point(127, 64);
            this.DatePicker_descDate.Name = "DatePicker_descDate";
            this.DatePicker_descDate.Size = new System.Drawing.Size(300, 26);
            this.DatePicker_descDate.TabIndex = 3;
            // 
            // Label_fypYearEx
            // 
            this.Label_fypYearEx.AutoSize = true;
            this.Label_fypYearEx.Location = new System.Drawing.Point(337, 29);
            this.Label_fypYearEx.Name = "Label_fypYearEx";
            this.Label_fypYearEx.Size = new System.Drawing.Size(103, 20);
            this.Label_fypYearEx.TabIndex = 2;
            this.Label_fypYearEx.Text = "ex. 2019-2020";
            // 
            // Label_fypYear
            // 
            this.Label_fypYear.AutoSize = true;
            this.Label_fypYear.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_fypYear.Location = new System.Drawing.Point(6, 26);
            this.Label_fypYear.Name = "Label_fypYear";
            this.Label_fypYear.Size = new System.Drawing.Size(157, 18);
            this.Label_fypYear.TabIndex = 1;
            this.Label_fypYear.Text = "FYP Academic Year:";
            // 
            // TextBox_FypYear
            // 
            this.TextBox_FypYear.Location = new System.Drawing.Point(169, 23);
            this.TextBox_FypYear.Name = "TextBox_FypYear";
            this.TextBox_FypYear.Size = new System.Drawing.Size(162, 26);
            this.TextBox_FypYear.TabIndex = 0;
            // 
            // Output
            // 
            this.Output.Controls.Add(this.Label_DisplayOutputDir);
            this.Output.Controls.Add(this.Button_OutputFile);
            this.Output.Controls.Add(this.Label_outputFile);
            this.Output.ForeColor = System.Drawing.Color.White;
            this.Output.Location = new System.Drawing.Point(588, 372);
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(511, 134);
            this.Output.TabIndex = 1;
            this.Output.TabStop = false;
            this.Output.Text = "Output";
            // 
            // Label_DisplayOutputDir
            // 
            this.Label_DisplayOutputDir.AutoSize = true;
            this.Label_DisplayOutputDir.Location = new System.Drawing.Point(342, 62);
            this.Label_DisplayOutputDir.Name = "Label_DisplayOutputDir";
            this.Label_DisplayOutputDir.Size = new System.Drawing.Size(0, 19);
            this.Label_DisplayOutputDir.TabIndex = 9;
            // 
            // Button_OutputFile
            // 
            this.Button_OutputFile.BackColor = System.Drawing.Color.Silver;
            this.Button_OutputFile.ForeColor = System.Drawing.Color.Black;
            this.Button_OutputFile.Location = new System.Drawing.Point(170, 51);
            this.Button_OutputFile.Name = "Button_OutputFile";
            this.Button_OutputFile.Size = new System.Drawing.Size(165, 29);
            this.Button_OutputFile.TabIndex = 8;
            this.Button_OutputFile.Text = "Choose Folder";
            this.Button_OutputFile.UseVisualStyleBackColor = false;
            this.Button_OutputFile.Click += new System.EventHandler(this.Button_OutputFile_Click);
            // 
            // Label_outputFile
            // 
            this.Label_outputFile.AutoSize = true;
            this.Label_outputFile.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_outputFile.Location = new System.Drawing.Point(6, 55);
            this.Label_outputFile.Name = "Label_outputFile";
            this.Label_outputFile.Size = new System.Drawing.Size(158, 18);
            this.Label_outputFile.TabIndex = 7;
            this.Label_outputFile.Text = "Output File Location:";
            // 
            // Button_startPrepackaging
            // 
            this.Button_startPrepackaging.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Button_startPrepackaging.ForeColor = System.Drawing.Color.Black;
            this.Button_startPrepackaging.Location = new System.Drawing.Point(588, 534);
            this.Button_startPrepackaging.Name = "Button_startPrepackaging";
            this.Button_startPrepackaging.Size = new System.Drawing.Size(312, 38);
            this.Button_startPrepackaging.TabIndex = 2;
            this.Button_startPrepackaging.Text = "Start Prepackaging";
            this.Button_startPrepackaging.UseVisualStyleBackColor = false;
            this.Button_startPrepackaging.Click += new System.EventHandler(this.Button_startPrepackaging_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Desktop;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1113, 312);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Prepackaging_App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(1111, 660);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Button_startPrepackaging);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.Input);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Prepackaging_App";
            this.Text = "Pre-Packaging Software ";
            this.Input.ResumeLayout(false);
            this.Input.PerformLayout();
            this.Output.ResumeLayout(false);
            this.Output.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Input;
        private System.Windows.Forms.Label Label_fypYearEx;
        private System.Windows.Forms.Label Label_fypYear;
        private System.Windows.Forms.TextBox TextBox_FypYear;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button Button_studentFile;
        private System.Windows.Forms.Button Button_courseFile;
        private System.Windows.Forms.Label Label_studentFile;
        private System.Windows.Forms.Label Label_courseFile;
        private System.Windows.Forms.Label Label_descDate;
        private System.Windows.Forms.DateTimePicker DatePicker_descDate;
        private System.Windows.Forms.Label Label_displayStudentFile;
        private System.Windows.Forms.Label Label_displayCourseFile;
        private System.Windows.Forms.GroupBox Output;
        private System.Windows.Forms.Button Button_OutputFile;
        private System.Windows.Forms.Label Label_outputFile;
        private System.Windows.Forms.Label Label_DisplayOutputDir;
        private System.Windows.Forms.Button Button_startPrepackaging;
        private System.Windows.Forms.Label Label_displaySportFile;
        private System.Windows.Forms.Label Label_displayAthleteFile;
        private System.Windows.Forms.Button Button_SportFile;
        private System.Windows.Forms.Label Label_SportFile;
        private System.Windows.Forms.Button Button_AthleteFile;
        private System.Windows.Forms.Label Label_AthleteFile;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

