using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace QuizExamSystem.Data.Models
{
    public class Enrollment : BaseEntity
    {
        private Student _student;
        private Course _course;
        public Student Student
        {
            get => _student;
            set => _student = value;
        }
        public Course Course
        {
            get => _course;
            set => _course = value;
        }
        public Enrollment(Student student, Course course) : base()
        {
            this.Student = student;
            this.Course = course;
        }
    }
}
