using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Exam_OOP.Questions
{
    internal abstract class Question
    {
        #region Properties
        public string? Header { get; set; }
        public string? Body { get; set; }
        public decimal Mark { get; set; }
        public Answer[] AnswersList { get; set; } 
        public Answer RightAnswer{ get; set; }
        public Answer? UserAnswer { get; set; } 

        #endregion

        #region Constructors
        public Question(string header, string body, decimal mark, Answer[] answers, Answer rightAnswer)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswersList = answers;
            RightAnswer = rightAnswer;
        }
        #endregion

        #region create Question
        public abstract Question CreateQuestion();
        #endregion


    }
}
