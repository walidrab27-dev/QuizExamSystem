using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizExamSystem.Data.Models
{
    public class Quiz : BaseEntity
    {
        private string _name;
        private TimeSpan _duration;
        private Course _course;
        private Teacher _teacher;
        public string Name
        {
            get => this._name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }
                this._name = value;
            }
        }
        public TimeSpan Duration
        {
            get => this._duration;
            set => this._duration = value;
        }
        public Course Course
        {
            get => this._course;
            set => this._course = value;
        }
        public Teacher Teacher
        {
            get => this._teacher;
            set => this._teacher = value;
        }
        private List<Question> _questions;
        public List<Question> Questions { get => this._questions; }
        private List<StudentQuiz> _studentQuizzes;
        public List<StudentQuiz> StudentQuizzes { get => this._studentQuizzes; }
        public void AddQuestion(Question question)
        {
            if (question == null)
            {
                throw new ArgumentNullException(nameof(question), "Question cannot be null.");
            }
            this._questions.Add(question);
        }
        public Quiz(string name, TimeSpan duration, Course course, Teacher teacher) : base()
        {
            this.Name = name;
            this.Duration = duration;
            this.Course = course;
            this.Teacher = teacher;
            this._questions = new List<Question>();
            this._studentQuizzes = new List<StudentQuiz>();
        }
    }
}
