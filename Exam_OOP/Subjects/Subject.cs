using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam_OOP.Exams;
using Exam_OOP.Questions;

namespace Exam_OOP.Subjects
{
    internal class Subject
    {
        #region Properties
        public int Id { get; set; }
        public string? Name { get; set; }
        public Exam? exam { get; set; }

        #endregion

        #region Constructors
        public Subject()
        {
            Id = 0;
            Name = string.Empty;
            exam = null;
        }
        #endregion

        #region Methods
        public void CreateExam()
        {
            #region Type of Exam
            int num;
            bool flage;
            do
            {
                Console.Write("Please Enter Type Of Exam ( 1 for Practical , 2 for Final )\n=> ");
                flage = int.TryParse(Console.ReadLine(), out num);
            }
            while (!flage || num > 2 || num < 0);

            #endregion

            #region Time Of Exam
            int timeOfExam; bool flageTime;
            do
            {
                Console.Write("Please Enter The Time Of Exam ( 30 Min to 180 Min)\n=> ");
                flageTime = int.TryParse(Console.ReadLine(), out timeOfExam);
            }
            while (!flageTime || timeOfExam < 30 || timeOfExam > 180);
            #endregion


            #region Number Of Questions
            int numberOfQuestions; bool flageNum;
            do
            {
                Console.Write("Please Enter The Number Of Questions\n=> ");
                flageNum = int.TryParse(Console.ReadLine(), out numberOfQuestions);
            }
            while (!flageNum || numberOfQuestions <= 0);
            #endregion

            #region Questions Array & Create Questions
            Console.Clear();
            Question[]? Q = new Question[numberOfQuestions];

            // Practical Exam
            if (num == 1)
            {
                exam = new PracticalExam(timeOfExam, numberOfQuestions);

                for (int i = 0; i < numberOfQuestions; i++)
                {
                    Console.WriteLine("MCQ Question");
                    Q[i] = new MCQ().CreateQuestion();
                    Console.Clear();
                }

            }
            // Final Exam
            else if (num == 2)
            {
                exam = new FinalExam(timeOfExam, numberOfQuestions);

                for (int i = 0; i < numberOfQuestions; i++)
                {
                    #region Question Type
                    int typeOfQuestion; bool flageType;
                    do
                    {
                        Console.Write("Please Enter The Type Of Question (1 for MCQ | 2 for True | False)\n=> ");
                        flageType = int.TryParse(Console.ReadLine(), out typeOfQuestion);
                    }
                    while (!flageType || typeOfQuestion > 2 || typeOfQuestion < 0);
                    #endregion

                    Console.Clear();

                    if (typeOfQuestion == 1)
                    {
                        Console.WriteLine("MCQ Question");
                        Q[i] = new MCQ().CreateQuestion();
                    }
                    else if (typeOfQuestion == 2)
                    {

                        Console.WriteLine("True | False Question");
                        Q[i] = new TrueOrFalse().CreateQuestion();
                    }
                    
                    Console.Clear();
                }
            }
            #endregion

            #region Show Exam

            string? isStart;
            do
            {
                Console.Write("Do You Want Start Exam ? (Y , N) \n=> ");
                isStart = Console.ReadLine();
            
            
            }
            while (isStart is null || isStart == "");
            Console.Clear();
            if (isStart?.ToLower() == "y" || isStart?.ToLower() == "yes") exam?.ShowExam(Q);
            else Console.WriteLine("Okay , As You Like .");
            #endregion
        }
        #endregion
    }
}
