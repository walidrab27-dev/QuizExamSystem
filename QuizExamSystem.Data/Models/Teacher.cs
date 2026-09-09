using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizExamSystem.Data.Enums;

namespace QuizExamSystem.Data.Models
{
    public class Teacher : User
    {
        private TeacherTitles _title;
        public TeacherTitles Title
        {
            get => _title;
            set=> _title = value;
        }
        private List<Course> _courses;
        private List<Quiz> _quizzes;
        public List<Quiz> Quizzes { get => this._quizzes; }
        public List<Course> Courses { get => this._courses; }
        public void AddQuiz(Quiz quiz)
        {
            this._quizzes.Add(quiz);
        }
        public Teacher(string name, string email, string password,TeacherTitles title) : base(name, email, password)
        {
            this.Title = title;
            this._courses = new List<Course>();
            this._quizzes = new List<Quiz>();
        }
    }
}
