using Exam_OOP.Exams;
using Exam_OOP.Subjects;

namespace Exam_OOP
{
    
    internal class Program
    {
        public static void ExamProcess()
        {
            Subject sub = new Subject();
            sub.CreateExam();
           
        }
        static void Main(string[] args)
        {
            ExamProcess();
        }
    }
}
