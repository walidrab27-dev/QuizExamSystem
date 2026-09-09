using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizExamSystem.Data.Models
{
    public class StudentQuiz : BaseEntity
    {
        private Student _student;
        private Quiz _quiz;
        private double _finalScore;
        public Student Student
        {
            get => _student;
            set => _student = value;
        }
        public Quiz Quiz
        {
            get => _quiz;
            set => _quiz = value;
        }
        public double FinalScore
        {
            get => _finalScore;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Final Score cannot be negative.");
                }
                this._finalScore = value;
            }
        }
        public List<string> _submittedAnswers;
        public List<string> SubmittedAnswers
        {
            get => _submittedAnswers;
            set => _submittedAnswers = value;
        }
        public StudentQuiz(Student student, Quiz quiz, double finalScore,List<string> submittedAnswers)
        {
            this.Student = student;
            this.Quiz = quiz;
            this.FinalScore = finalScore;
            this.SubmittedAnswers = submittedAnswers;
        }
        public StudentQuiz()
        {
        }
    }
}
