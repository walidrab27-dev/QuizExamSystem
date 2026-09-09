using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizExamSystem.Data.Models
{
    public class Admin : User
    {
        private List<Course> _courses;
        public List<Course> Courses { get => this._courses; }
        public void AddCourse(Course course)
        {
            this._courses.Add(course);
        }
        public Admin(string name, string email, string password) : base(name, email, password)
        {
            this._courses = new List<Course>();
        }
    }
}
