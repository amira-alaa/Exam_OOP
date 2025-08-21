using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_OOP.Questions
{
    internal class MCQ : Question
    {
        #region Constructors
        public MCQ(string header, string body, decimal mark, Answer[] answers , Answer rightAnswer) : base(header, body, mark, answers, rightAnswer)
        {
            
        }
        public MCQ(): this("MCQ", "", 0, new Answer[3],new Answer())
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

            #region Answers & Right Answer

            // Answers
            
            for (int j = 0; j < AnswersList.Length; j++)
            {
                
                #region Enter Answers 
                string? choice;
                do
                {
                    Console.Write($"Please Enter Choice Number {j + 1}\n=> ");
                    choice = Console.ReadLine();
                } while (choice == null || choice == "");
                #endregion
                
                AnswersList[j] = new Answer(j + 1, choice);
            }


            // Right Answer
            int rightAnswer; bool flagRightAnswer;
            do
            {
                Console.Write("Please Enter Right Answer ( 1 for Choice1 , 2 for Choice2 OR 3 for Choice3)\n=> ");
                flagRightAnswer = int.TryParse(Console.ReadLine(), out rightAnswer);
            }
            while (!flagRightAnswer || rightAnswer < 1 || rightAnswer > AnswersList.Length);

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

            // create Question
            if (AnswersList is null) return new MCQ();
            return new MCQ("MCQ", body, mark, AnswersList, new Answer(rightAnswer, AnswersList?[rightAnswer - 1].Body ?? "No Answer"));
        }
        #endregion
    }
}
