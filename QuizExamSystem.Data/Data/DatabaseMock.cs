using QuizExamSystem.Data.Enums;
using QuizExamSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizExamSystem.Data.Data
{
    public static class DatabaseMock
    {
        public static List<Admin> Admins = new List<Admin>()
        {
            new Admin("walid","walidrab27@gmail.com","**********")
        };
        public static List<Student> Students = new List<Student>()
        {
            new Student("walid","walidrab27@gmail.com","**********")
        };
        //public static List<Student> Students = new List<Student>();
        public static List<Teacher> Teachers = new List<Teacher>()
        {
            new Teacher("walid","walidrab27@gmail.com","**********",TeacherTitles.Professor),
            new Teacher("Raghad","raghad@gmail.com","**********",TeacherTitles.Professor)
        };
        //public static List<Teacher> Teachers = new List<Teacher>();
        public static List<Course> Courses = new List<Course>()
        {
            new Course("C# Fundamentals",CourseCategories.ComputerScience,new TimeSpan(20,0,0),20,Admins[0],Teachers[0]),
            new Course("C++ Fundamentals",CourseCategories.ComputerScience,new TimeSpan(20,0,0),20,Admins[0])
        };
        //public static List<Course> Courses = new List<Course>();
        public static List<Quiz> Quizzes = new List<Quiz>
        {
            new Quiz("Midterm",new TimeSpan(2,0,0),Courses[0],Teachers[0])
        };
        public static List<Question> Questions = new List<Question>();
        public static List<Enrollment> Enrollments = new List<Enrollment>();
        public static List<StudentQuiz> StudentQuizzes = new List<StudentQuiz>();
        public static List<Answer> Answers = new List<Answer>();
    }
}
