using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_OOP.Questions
{
    internal class Answer
    {
        #region Properties
        public int Id { get; set; }
        public string? Body { get; set; }
        #endregion

        #region Constructors
        public Answer()
        {
            Id = 0;
            Body = string.Empty;
        }
        public Answer(int id, string body)
        {
            Id = id;
            Body = body;
        }
        #endregion

        #region Overrides Object Methods
        public override string ToString()
        {
            return $"{Id} - {Body}";
        }
        override public bool Equals(object? obj)
        {
            Answer? other = obj as Answer;
            bool flage;
            if (other != null)
            {
                if (this.Id == other?.Id && this.Body == other.Body) flage = true;
                else flage = false;
            }
            else flage = false;
            return flage;
        }
        override public int GetHashCode()
        {
            return HashCode.Combine(Id, Body);
        }
        #endregion
    }
}
