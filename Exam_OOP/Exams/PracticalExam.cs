using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam_OOP.Questions;

namespace Exam_OOP.Exams
{
    internal class PracticalExam : Exam
    {
        #region Constructors
        public PracticalExam(int timeOfExam, int numOfQuestions) : base(timeOfExam, numOfQuestions)
        {
        }
        #endregion

        #region Methods
        public override void ShowExam(Question[] Q)
        {
            Console.WriteLine("Welcome to the Practical Exam!");
            Console.WriteLine();
            DateTime startTime = DateTime.Now;
            

            for (int i = 0; i < Q.Length; i++)
            {
                
                Console.WriteLine($"Q{i + 1}: {Q[i].Body} ({Q[i].Mark} marks)");

                for (int j = 0; j < Q[i].AnswersList.Length; j++)
                {
                    Console.WriteLine(Q[i].AnswersList[j]);
                }

                #region Your Answer
                bool userAnsFlage; int YourAns;
                do
                {
                    Console.Write("Please Enter Your Answer (1 for Choice1 , 2 for Choice2 OR 3 for Choice3 )\n=> ");
                    userAnsFlage = int.TryParse(Console.ReadLine(), out YourAns);
                }
                while (!userAnsFlage || YourAns <= 0 || YourAns > Q[i].AnswersList.Length);
                Q[i].UserAnswer = new Answer(YourAns, Q[i]?.AnswersList[YourAns - 1].Body ?? "No Answer");
                #endregion

                

            }

          

            // Show Results

            DateTime endTime = DateTime.Now;
            Console.Clear();
            Console.WriteLine("Exam Results:");

            foreach (var Que in Q)
            {
                Console.WriteLine();
                int i = 0;  
                Console.WriteLine($"Q{i + 1}: {Que.Body}");
                Console.WriteLine($"Right Answer : {Que.RightAnswer.Body} .");
                i++;
            }
            Console.WriteLine();
            TimeSpan timeLeft = endTime - startTime;

            Console.WriteLine($"Time = {timeLeft:hh\\:mm\\:ss}");
            Console.WriteLine("Thank you for taking the exam!");
       


        }

        #endregion
    }
}
