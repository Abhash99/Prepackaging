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
     *      Represents the test information related to a particular student. 
     *  
     *  PURPOSE:
     *      Holds all the test related data for a particular student. 
     *      Used to encapsulate similar attributes (Test Data) for better readability. 
     *  
     *  AUTHOR: 
     *      Abhash Panta
     */
    /**/
    class TestingInfo
    {
        // Member Variables

        // SAT Reading Score
        int m_SAT_RW;

        // SAT Math Score
        int m_SAT_Math;

        // SAT Total Score
        int m_SAT_Total;

        // ACT Composite Score
        int m_ACT_Composite;


        // Accuplacer Reading Score
        int m_ACU_Read;

        // Accuplacer Reading Test Date
        DateTime m_ACU_ReadDate;


        // Accuplacer Writing Score
        int m_ACU_Writing;

        // Accuplacer Writing Test Date
        DateTime m_ACU_WritingDate;


        // Accuplacer Arithmetic Score
        int m_ACU_Arith;

        // Accuplacer Arithmetic Test Date
        DateTime m_ACU_ArithDate;


        // Accuplacer Quantitative Reasoning Score
        int m_ACU_Quant;

        // Accuplacer Quantitative Reasoning Test Date
        DateTime m_ACU_QuantDate;


        // Accuplacer Advance Algebra Score
        int m_ACU_AdvAlg;

        // Accuplacer Advance Algebra Test Date
        DateTime m_ACU_AdvAlgDate;


        // Accuplacer Essay Score
        int m_ACU_Essay;

        // Accuplacer Essay Test Date
        DateTime m_ACU_EssayDate;


        // Determines if calculus test is required for the student. 
        bool m_calcRequired;

        // States the Math test type required for the student. 
        string m_mathTestType;

        // States the Reading test type required for the student. 
        string m_readingTestType;

        // Determines if mathRetest is allowed. 
        string m_mathRetest;

        // Determines if calcRetest is allowed.
        string m_calcRetest;

        // Determines if readingRetest is allowed. 
        string m_readingRetest;


        // Properties for respective member variables
        public int SAT_RW { get => m_SAT_RW; set => m_SAT_RW = value; }
        public int SAT_Math { get => m_SAT_Math; set => m_SAT_Math = value; }
        public int SAT_Total { get => m_SAT_Total; set => m_SAT_Total = value; }
        public int ACT_Composite { get => m_ACT_Composite; set => m_ACT_Composite = value; }

        public int ACU_Read { get => m_ACU_Read; set => m_ACU_Read = value; }
        public DateTime ACU_ReadDate { get => m_ACU_ReadDate; set => m_ACU_ReadDate = value; }
        public int ACU_Writing { get => m_ACU_Writing; set => m_ACU_Writing = value; }
        public DateTime ACU_WritingDate { get => m_ACU_WritingDate; set => m_ACU_WritingDate = value; }
        public int ACU_Arith { get => m_ACU_Arith; set => m_ACU_Arith = value; }
        public DateTime ACU_ArithDate { get => m_ACU_ArithDate; set => m_ACU_ArithDate = value; }
        public int ACU_Quant { get => m_ACU_Quant; set => m_ACU_Quant = value; }
        public DateTime ACU_QuantDate { get => m_ACU_QuantDate; set => m_ACU_QuantDate = value; }
        public int ACU_AdvAlg { get => m_ACU_AdvAlg; set => m_ACU_AdvAlg = value; }
        public DateTime ACU_AdvAlgDate { get => m_ACU_AdvAlgDate; set => m_ACU_AdvAlgDate = value; }
        public int ACU_Essay { get => m_ACU_Essay; set => m_ACU_Essay = value; }
        public DateTime ACU_EssayDate { get => m_ACU_EssayDate; set => m_ACU_EssayDate = value; }


        public bool CalcRequired { get => m_calcRequired; set => m_calcRequired = value; }
        public string MathTestType { get => m_mathTestType; set => m_mathTestType = value; }
        public string ReadingTestType { get => m_readingTestType; set => m_readingTestType = value; }
        public string MathRetest { get => m_mathRetest; set => m_mathRetest = value; }
        public string CalcRetest { get => m_calcRetest; set => m_calcRetest = value; }
        public string ReadingRetest { get => m_readingRetest; set => m_readingRetest = value; }
    }
}
