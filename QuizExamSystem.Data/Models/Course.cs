using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizExamSystem.Data.Enums;

namespace QuizExamSystem.Data.Models
{
    public class Course : BaseEntity
    {
        private string _name;
        private CourseCategories _category;
        private TimeSpan _duration;
        private int _numberLessons;
        public string Name
        {
            get=>this._name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }
                this._name = value;
            }
        }
        public CourseCategories Category
        {
            get => this._category;
            set => this._category = value;
        }
        public TimeSpan Duration
        {
            get=>this._duration;
            set => this._duration = value;
        }
        public int NumberLessons
        {
            get=> this._numberLessons;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Number of lessons cannot be negative.");
                }
                this._numberLessons = value;
            }
        }
        private Admin _admin;
        private Teacher? _teacher;
        public Admin Admin
        {
            get => this._admin;
            set => this._admin = value;
        }
        public Teacher? Teacher
        {
            get => this._teacher;
            set => this._teacher = value;
        }
        private List<Enrollment> _enrollments;
        public List<Enrollment> Enrollments { get => this._enrollments; }
        private List<Quiz> _quizzes;
        public List<Quiz> Quizzes { get => this._quizzes; }
        public Course(string name, CourseCategories category, TimeSpan duration, int numberLessons, Admin admin) : base()
        {
            this.Name = name;
            this.Category = category;
            this.Duration = duration;
            this.NumberLessons = numberLessons;
            this.Admin = admin;
            this._enrollments = new List<Enrollment>();
            this._quizzes = new List<Quiz>();
        }
        public Course(string name, CourseCategories category, TimeSpan duration, int numberLessons, Admin admin, Teacher? teacher) : this(name, category, duration, numberLessons, admin)
        {
            this.Teacher = teacher;
        }
    }
}
