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
     *      A static class that to hold constants representing the column values for Student Information File
     *  
     *  PURPOSE: 
     *      To hold an enum with values corresponding to the column values in the input excel file.
     *      Any changes to the order of columns in the Student excel file can be easily reflected in the source code by
     *      changing the values in the enum. 
     *  
     *  NOTE: 
     *      The enum names match with the member variable of the Student class and TestInfo class so it increases writability
     *      and readability. 
     *  
     *  AUTHOR: 
     *      Abhash Panta
     */
    /**/
    static class StudentExcelConstants
    {

        public enum Columns
        {
            // Information pertaining to Student Class
            Term=0,
            LastName,
            FirstName,
            MiddleInitial,
            RamapoId,

            Enrld,
            TermEnrldHours,
            TermTrnsHours,
            StudentType,
            AdmitType,

            AdmitSchool,
            AdmitMajor,
            AdmitMajorDesc,
            AdmitConcentration,
            AdmitConcentrationDesc,

            DcsnDate,
            Scholarship_1,
            Scholarship_2,
            Honors,
            Eof,
            Sport,

            RcnjEmail,
            Phone,
            HousingDeposit,
            Housing,

            Rsvp_orientation,
            Orientation,
            OrientDate,

            // Information pertaining to TestInfo class
            SAT_RW,
            SAT_Math,
            SAT_Total,
            ACT_Composite,

            ACU_Read,
            ACU_ReadDate,
            ACU_Writing,
            ACU_WritingDate,
            ACU_Arith,
            ACU_ArithDate,
            ACU_Quant,
            ACU_QuantDate,
            ACU_AdvAlg,
            ACU_AdvAlgDate,
            ACU_Essay,
            ACU_EssayDate,

            CalcRequired,
            MathTestType,
            ReadingTestType,
            MathRetest,
            CalcRetest,
            ReadingRetest,

            // Information pertaining to CreditInfo class
            TakenSummerCourses,
            SummerCoursesStart = 51,
            SummerCoursesEnd = 54,
            RCNJCoursesStart = 55,
            RCNJCoursesEnd = 62,
            APCoursesStart = 63,
            APCoursesEnd = 77,
            NonAPCoursesStart = 78,
            NonAPCoursesEnd = 107

        }

    }
}
