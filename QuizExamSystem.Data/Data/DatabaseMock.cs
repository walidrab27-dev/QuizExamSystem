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
        public static List<Admin> Admins = new List<Admin>();
        public static List<Student> Students = new List<Student>();
        public static List<Teacher> Teachers = new List<Teacher>();
        public static List<Course> Courses = new List<Course>();
        public static List<Quiz> Quizzes = new List<Quiz>();
        public static List<Question> Questions = new List<Question>();
        public static List<Enrollment> Enrollments = new List<Enrollment>();
        public static List<StudentQuiz> StudentQuizzes = new List<StudentQuiz>();
        public static List<Answer> Answers = new List<Answer>();
        static DatabaseMock()
        {
            var admin = new Admin("walid rabei","walidrab27@gmail.com","**********");
            Admins.Add(admin);

            var teacher = new Teacher("walid rabei","walidrab27@gmail.com","**********",TeacherTitles.Professor);
            Teachers.Add(teacher);

            var student = new Student("walid rabei","walidrab27@gmail.com","**********");
            Students.Add(student);

            var course1 = new Course("C# Fundamentals", CourseCategories.Programming, new TimeSpan(20, 0, 0), 10, admin, teacher);
            Courses.Add(course1);
            admin.Courses.Add(course1);
            teacher.Courses.Add(course1);
            var course2 = new Course("C++ Fundamentals", CourseCategories.Programming, new TimeSpan(20, 0, 0), 10, admin, teacher);
            Courses.Add(course2);
            admin.Courses.Add(course2);
            teacher.Courses.Add(course2);
            var course3 = new Course("Python Fundamentals", CourseCategories.Programming, new TimeSpan(20, 0, 0), 10, admin, teacher);
            Courses.Add(course3);
            admin.Courses.Add(course3);
            teacher.Courses.Add(course3);

            var quiz1 = new Quiz("midterm", new TimeSpan(2, 0, 0), course1, teacher);
            Quizzes.Add(quiz1);
            teacher.AddQuiz(quiz1);
            course1.Quizzes.Add(quiz1);

            var question1 = new TrueFalse("Main is the entry point of C# Application",5,quiz1);
            quiz1.AddQuestion(question1);
            Questions.Add(question1);
            var question2 = new ShortAnswer("What is the entry point of C# Application",5,quiz1);
            quiz1.AddQuestion(question2);
            Questions.Add(question2);
            var question3 = new MultipleChoice("it is a porgramming language We study it",5,quiz1);
            quiz1.AddQuestion(question3);
            Questions.Add(question3);

            var answer1 = new Answer("True",true,question1);
            question1.AddAnswer(answer1);
            Answers.Add(answer1);
            var answer2 = new Answer("Main",true,question2);
            question2.AddAnswer(answer2);
            Answers.Add(answer2);
            var answer3 = new Answer("C#",true,question3);
            question3.AddAnswer(answer3);
            Answers.Add(answer3);
            var answer4 = new Answer("Python",true,question3);
            question3.AddAnswer(answer4);
            Answers.Add(answer4);
            var answer5 = new Answer("C++",true,question3);
            question3.AddAnswer(answer5);
            Answers.Add(answer5);
            var answer6 = new Answer("F#",true,question3);
            question3.AddAnswer(answer6);
            Answers.Add(answer6);
        }
    }
}
