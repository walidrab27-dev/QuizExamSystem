using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizExamSystem.Data.Data;
using QuizExamSystem.Data.Enums;
using QuizExamSystem.Data.Models;

namespace QuizExamSystem.Data.Services
{
    public class AdminService
    {
        public Admin Login(string email, string password)
        {
            foreach (var admin in DatabaseMock.Admins)
            {
                if (admin.Email == email && admin.Password == password)
                    return admin;
            }
            throw new UnauthorizedAccessException("Invalid email or password!");
        }
        public void CreateCourse(string name, CourseCategories category, TimeSpan duration, int numberLessons, Admin admin, Teacher? teacher)
        {
            Course course;
            if (teacher == null)
            {
                course = new Course(name, category, duration, numberLessons, admin);
            }
            else
            {
                course = new Course(name, category, duration, numberLessons, admin, teacher);
            }
            DatabaseMock.Courses.Add(course);
            admin.AddCourse(course);
        }
        public List<Course> GetAllCourses()
        {
            //if (DatabaseMock.Courses.Count() == 0)
            //    throw new ArgumentException("No courses available.");
            return DatabaseMock.Courses;
        }
        public List<Teacher> GetAllTeachers()
        {
            //if (DatabaseMock.Teachers.Count() == 0)
            //    throw new ArgumentException("No teachers available.");
            return DatabaseMock.Teachers;
        }
        public List<Student> GetAllStudents()
        {
            //if (DatabaseMock.Students.Count() == 0)
            //    throw new ArgumentException("No students available.");
            return DatabaseMock.Students;
        }

        public void CreateCourse(string v, CourseCategories computerScience, TimeSpan timeSpan, Admin admin)
        {
            throw new NotImplementedException();
        }
    }
}
