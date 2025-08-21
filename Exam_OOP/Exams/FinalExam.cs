using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam_OOP.Questions;

namespace Exam_OOP.Exams
{
    internal class FinalExam : Exam
    {
        #region Constructors
        public FinalExam(int timeOfExam, int numberOfQuestions) : base(timeOfExam, numberOfQuestions)
        {
        }
        #endregion

        #region Methods
        public override void ShowExam(Question[] Q)
        {
            Console.WriteLine("Welcome to the Final Exam!");
            Console.WriteLine();
            DateTime startTime = DateTime.Now;
            

            decimal totalMarks = 0; 
            decimal actualMarks = 0;
           
            for (int i = 0; i < Q.Length; i++)
            {
               
                actualMarks += Q[i].Mark;
                Console.WriteLine($"Q{i + 1}: {Q[i].Body} ({Q[i].Mark} marks)");
                for (int j = 0; j < Q[i].AnswersList.Length; j++)
                {
                    Console.WriteLine(Q[i].AnswersList[j]);
                }

                #region Your Answer
                bool userAnsFlage; int YourAns;
                do
                {
                    Console.Write($"Please Enter Your Answer " + (Q[i].Header == "MCQ" ? "(1 for Choice1 , 2 for Choice2 OR 3 for Choice3)\n=> " : "(1 for True OR 2 for False)\n=> "));
                    userAnsFlage = int.TryParse(Console.ReadLine(), out YourAns);
                }
                while (!userAnsFlage || YourAns <= 0 || YourAns > Q[i].AnswersList.Length);
                Q[i].UserAnswer = new Answer(YourAns, Q[i]?.AnswersList[YourAns - 1].Body ?? "No Answer");
                #endregion

                //if (Q[i].UserAnswer is not null)
                //{
                if (Q[i].RightAnswer.Equals(Q[i].UserAnswer)) totalMarks += Q[i].Mark;
                else totalMarks += 0;

                //}

                   
            }


            // Show results
            DateTime endTime = DateTime.Now;
            Console.Clear();
            Console.WriteLine("Exam Results:");
            foreach (var item in Q)
            {
                Console.WriteLine();
                int i = 0;
                Console.WriteLine($"Q{i + 1} : {item.Body} (Marks : {item.Mark})");
                Console.WriteLine($"Your Answer => {item?.UserAnswer?.Body}.\nRight Answer => {item?.RightAnswer.Body}.");
            }
            TimeSpan timeLeft = endTime - startTime;
            Console.WriteLine();
            Console.WriteLine($"Your Grade is {totalMarks} From {actualMarks}");
            Console.WriteLine($"Time = {timeLeft:hh\\:mm\\:ss}");
            Console.WriteLine("Thank you for taking the exam!");
        }
        #endregion
    }

}
