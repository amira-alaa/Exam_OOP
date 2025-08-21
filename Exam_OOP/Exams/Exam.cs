using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam_OOP.Questions;

namespace Exam_OOP.Exams
{
    internal abstract class Exam
    {
        #region Properties
        public int TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }
        #endregion

        #region Constructors
        public Exam(int timeOfExam, int numberOfQuestions)
        {
            TimeOfExam = timeOfExam;
            NumberOfQuestions = numberOfQuestions;
        }
        #endregion

        #region Methods
        public abstract void ShowExam(Question[] Q);
        #endregion

    }
}
