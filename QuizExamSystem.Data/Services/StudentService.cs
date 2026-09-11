using QuizExamSystem.Data.Data;
using QuizExamSystem.Data.Enums;
using QuizExamSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizExamSystem.Data.Services
{
    public class StudentService
    {
        public void Register(string name, string email, string password)
        {
            var student = new Student(name, email, password);
            DatabaseMock.Students.Add(student);
        }
        public Student Login(string email, string password)
        {
            foreach (var student in DatabaseMock.Students)
            {
                if (student.Email == email && student.Password == password)
                    return student;
            }
            throw new UnauthorizedAccessException("Invalid email or password!");
        }
        public List<Course> GetAllAvailableCourses()
        {
            var availableCourses = new List<Course>();
            foreach (var course in DatabaseMock.Courses)
            {
                if (course.Teacher != null)
                    availableCourses.Add(course);
            }
            return availableCourses;
        }
        public void EnrollInCourse(Course course, Student student)
        {
            if (course.Teacher != null)
            {
                var isAlreadyEnrolled = false;
                foreach (var enrollment in course.Enrollments)
                {
                    if (enrollment.Student == student)
                    { throw new ArgumentException("You are already enrolled in this course."); }
                }
                var newEnrollment = new Enrollment(student, course);
                DatabaseMock.Enrollments.Add(newEnrollment);
                student.Enrollments.Add(newEnrollment);
                course.Enrollments.Add(newEnrollment);
            }
            else
            {
                throw new ArgumentException("Course not found or currently unavailable (no teacher).");
            }
        }
        public List<Course> GetEnrolledCourses(Student student)
        {
            var enrolledCourseList = new List<Course>();
            foreach (var enrollment in student.Enrollments)
                enrolledCourseList.Add(enrollment.Course);
            return enrolledCourseList;
        }
        public double SubmitQuiz(Student student, Quiz quiz, List<string> answer)
        {
            double totalScore = 0;
            foreach (var studentQuiz in quiz.StudentQuizzes)
            {
                if (studentQuiz.Student == student)
                { throw new ArgumentException("You have taken this quiz before."); }
            }
            for (int i = 0; i < quiz.Questions.Count; i++)
            {
                totalScore += quiz.Questions[i].Evaluate(answer[i]);
            }
            var newStudentQuiz = new StudentQuiz
            {
                Student = student,
                Quiz = quiz,
                FinalScore = totalScore,
                SubmittedAnswers = answer
            };
            DatabaseMock.StudentQuizzes.Add(newStudentQuiz);
            student.StudentQuizzes.Add(newStudentQuiz);
            quiz.StudentQuizzes.Add(newStudentQuiz);
            return totalScore;
        }
        public List<string> GetAnswers(string answer)
        {
            var answerList = new List<string>();
            return answerList;
        }
        public List<Quiz> GetAllQuizzes(Student student)
        {
            var quizList = new List<Quiz>();
            foreach (var quiz in student.StudentQuizzes)
                quizList.Add(quiz.Quiz);
            return quizList;
        }
    }
}
