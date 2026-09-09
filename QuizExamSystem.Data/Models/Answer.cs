using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizExamSystem.Data.Models
{
    public class Answer : BaseEntity
    {
        private string _text;
        private bool _isCorrect;
        public string Text
        {
            get => _text;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Answer text cannot be null or empty.", nameof(value));
                _text = value;
            }
        }
        private string _studentAnswer;
        public string StudentAnswer
        {
            get => _studentAnswer;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Answer text cannot be null or empty.", nameof(value));
                _text = value;
            }
        }
        public bool IsCorrect
        {
            get => _isCorrect;  
            set => _isCorrect = value;
        }
        public Answer(string text, bool isCorrect) : base()
        {
            this.Text = text;
            this.IsCorrect = isCorrect;
        }
    }
}
