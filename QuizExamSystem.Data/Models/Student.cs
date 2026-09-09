using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizExamSystem.Data.Models
{
    public class Student : User

    {
        private double _grade;
        public double Grade
        {
            get => this._grade;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Grade must be between 0 and 100.");
                }
                this._grade = value;
            }
        }
        private List<Enrollment> _enrollments;
        private List<StudentQuiz> _studentQuizzes;
        public List<Enrollment> Enrollments { get => this._enrollments; }
        public List<StudentQuiz> StudentQuizzes { get => this._studentQuizzes; }
        public Student(string name, string email, string password) : base(name, email, password)
        {
            this._studentQuizzes = new List<StudentQuiz>();
            this._enrollments = new List<Enrollment>();
        }
    }
}
