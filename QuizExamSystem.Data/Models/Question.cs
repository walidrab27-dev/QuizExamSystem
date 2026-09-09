using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizExamSystem.Data.Models
{
    public abstract class Question : BaseEntity
    {
        private string _text;
        private double _score;
        private Quiz _quiz;
        public Quiz Quiz
        {
            get => this._quiz;
            set => this._quiz = value;
        }
        public string Text
        {
            get => this._text;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Question text cannot be empty.");
                }
                this._text = value;
            }
        }
        public double Score
        {
            get => this._score;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Score cannot be negative.");
                }
                this._score = value;
            }
        }
        public abstract double Evaluate(string answer);
        private List<Answer> _answers;
        public List<Answer> Answers { get => _answers; }
        public void AddAnswer(Answer answer)
        {
            if (answer == null)
            {
                throw new ArgumentNullException(nameof(answer), "Answer cannot be null.");
            }
            this._answers.Add(answer);
        }
        protected Question(string text, double score, Quiz quiz) : base()
        {
            this.Text = text;
            this.Score = score;
            this.Quiz = quiz;
            this._answers = new List<Answer>();
        }
    }
}
