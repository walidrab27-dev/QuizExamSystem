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
        public bool IsCorrect
        {
            get => _isCorrect;  
            set => _isCorrect = value;
        }
        private Question _question;
        public Question Question
        {
            get => this._question;
            set => this._question = value;
        }
        public Answer(string text, bool isCorrect, Question question) : base()
        {
            this.Text = text;
            this.IsCorrect = isCorrect;
            this.Question = question;
        }
    }
}
