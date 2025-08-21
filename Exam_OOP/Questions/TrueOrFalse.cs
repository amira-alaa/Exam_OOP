using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_OOP.Questions
{
    internal class TrueOrFalse : Question
    {
        #region Constructors
        public TrueOrFalse() : this("", "", 0, new Answer[2] , new Answer())
        {
        }
        public TrueOrFalse(string header, string body, decimal mark, Answer[] answers , Answer rightAnswer) : base(header, body, mark, answers , rightAnswer)
        {
        }
        #endregion

        #region Create Question Method
        public override Question CreateQuestion()
        {
            
            #region body
            string? body;
            do
            {
                Console.Write($"Please Enter Body Of Question\n=> ");
                body = Console.ReadLine();
            }
            while (body == null || body == "");
            #endregion

            #region Mark
            decimal mark; bool flageMark;
            do
            {
                Console.Write("Please Enter Question Mark\n=> ");
                flageMark = decimal.TryParse(Console.ReadLine(), out mark);
            }
            while (!flageMark || mark < 0);
            #endregion

            #region Answers & Right Answer
            AnswersList = new Answer[] // my answers & right answer
                { new Answer(1, "True"),
                new Answer(2, "False")};

            // Right Answer
            int rightAnswerInput; bool flagRightAnswer;
            do
            {
                Console.Write("Please Enter Right Answer (1 for True OR 2 for False )\n=> ");
                flagRightAnswer = int.TryParse(Console.ReadLine(), out rightAnswerInput);
            }
            while (!flagRightAnswer || rightAnswerInput < 1 || rightAnswerInput > AnswersList.Length);

            RightAnswer = new Answer(rightAnswerInput, AnswersList?[rightAnswerInput - 1].Body ?? "No Answer");

            #endregion

            // Create Question
            if (AnswersList is null) return new TrueOrFalse();
            return new TrueOrFalse("True Or False", body, mark , AnswersList , RightAnswer);
        }
        #endregion
    }
}
