using QuizExamSystem.Data.Interfaces;
using QuizExamSystem.Data.Models;
using QuizExamSystem.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace QuizExamSystem.Data.Repositories
{
    public class SqlDatabaseManager : IDatabaseManager
    {
        private readonly string _connectionString;
        public SqlDatabaseManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Admin> Admins()
        {
            List<Admin> admins;
            using SqlConnection connection = new SqlConnection(_connectionString);
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Admin", connection);
                SqlDataReader reader = command.ExecuteReader();
                admins = new List<Admin>();
                while (reader.Read())
                {
                    var admin = new Admin();
                    admin.Id = (int)reader["Id"];
                    admin.Name = (string)reader["Name"];
                    admin.Email = (string)reader["Email"];
                    admin.Password = (string)reader["Password"];
                    admin.CreatedAt = (DateTime)reader["CreatedAt"];
                    admin.UpdatedAt = (DateTime)reader["UpdatedAt"];
                    admins.Add(admin);
                }
            }
            return admins;
        }
        public List<Student> Students()
        {
            List<Student> students;
            using SqlConnection connection = new SqlConnection(_connectionString);
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Student", connection);
                SqlDataReader reader = command.ExecuteReader();
                students = new List<Student>();
                while (reader.Read())
                {
                    var student = new Student();
                    student.Id = (int)reader["Id"];
                    student.Name = (string)reader["Name"];
                    student.Email = (string)reader["Email"];
                    student.Password = (string)reader["Password"];
                    student.CreatedAt = (DateTime)reader["CreatedAt"];
                    student.UpdatedAt = (DateTime)reader["UpdatedAt"];
                    students.Add(student);
                }
            }
            return students;
        }
        public List<Teacher> Teachers()
        {
            List<Teacher> teachers;
            using SqlConnection connection = new SqlConnection(_connectionString);
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Teacher", connection);
                SqlDataReader reader = command.ExecuteReader();
                teachers = new List<Teacher>();
                while (reader.Read())
                {
                    var teacher = new Teacher();
                    teacher.Id = (int)reader["Id"];
                    teacher.Name = (string)reader["Name"];
                    teacher.Email = (string)reader["Email"];
                    teacher.Password = (string)reader["Password"];
                    teacher.CreatedAt = (DateTime)reader["CreatedAt"];
                    teacher.UpdatedAt = (DateTime)reader["UpdatedAt"];
                    teachers.Add(teacher);
                }
            }
            return teachers;
        }
        public List<Answer> Answers()
        {
            List<Answer> answers;
            using SqlConnection connection = new SqlConnection(_connectionString);
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Answer", connection);
                SqlDataReader reader = command.ExecuteReader();
                answers = new List<Answer>();
                while (reader.Read())
                {
                    var answer = new Answer();
                    answer.Id = (int)reader["Id"];
                    answer.Text = (string)reader["Text"];
                    answer.IsCorrect = (bool)reader["IsCorrect"];
                    answer.QuestionId = (int)reader["QuestionId"];
                    answer.CreatedAt = (DateTime)reader["CreatedAt"];
                    answer.UpdatedAt = (DateTime)reader["UpdatedAt"];
                    answers.Add(answer);
                }
            }
            return answers;
        }
        public List<Course> Courses()
        {
            List<Course> courses;
            using SqlConnection connection = new SqlConnection(_connectionString);
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Course", connection);
                SqlDataReader reader = command.ExecuteReader();
                courses = new List<Course>();
                while (reader.Read())
                {
                    var course = new Course();
                    course.Id = (int)reader["Id"];
                    course.Name = (string)reader["Name"];
                    course.Category = (CourseCategories)reader["Category"];
                    course.Duration = (TimeSpan)reader["Duration"];
                    course.NumberLessons = (int)reader["NumberLessons"];
                    course.AdminId = (int)reader["AdminId"];
                    course.TeacherId = reader["TeacherId"] as int?;
                    course.CreatedAt = (DateTime)reader["CreatedAt"];
                    course.UpdatedAt = (DateTime)reader["UpdatedAt"];
                    courses.Add(course);
                }
            }
            return courses;
        }

        public List<Enrollment> Enrollments()
        {
            List<Enrollment> enrollments;
            using SqlConnection connection = new SqlConnection(_connectionString);
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Enrollment", connection);
                SqlDataReader reader = command.ExecuteReader();
                enrollments = new List<Enrollment>();
                while (reader.Read())
                {
                    var enrollment = new Enrollment();
                    enrollment.Id = (int)reader["Id"];
                    enrollment.StudentId = (int)reader["StudentId"];
                    enrollment.CourseId = (int)reader["CourseId"];
                    enrollment.CreatedAt = (DateTime)reader["CreatedAt"];
                    enrollment.UpdatedAt = (DateTime)reader["UpdatedAt"];
                    enrollments.Add(enrollment);
                }
            }
            return enrollments;
        }

        public List<Question> Questions()
        {
            throw new NotImplementedException();
        }

        public List<Quiz> Quizzes()
        {
            List<Quiz> quizzes;
            using SqlConnection connection = new SqlConnection(_connectionString);
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Quiz", connection);
                SqlDataReader reader = command.ExecuteReader();
                quizzes = new List<Quiz>();
                while (reader.Read())
                {
                    var quiz = new Quiz();
                    quiz.Id = (int)reader["Id"];
                    quiz.Name = (string)reader["Name"];
                    quiz.Duration = (TimeSpan)reader["Duration"];
                    quiz.CourseId = (int)reader["CourseId"];
                    quiz.CreatedAt = (DateTime)reader["CreatedAt"];
                    quiz.UpdatedAt = (DateTime)reader["UpdatedAt"];
                    quizzes.Add(quiz);
                }
            }
            return quizzes;
        }

        public List<StudentQuiz> StudentQuizzes()
        {

            List<StudentQuiz> studentQuizzes;
            using SqlConnection connection = new SqlConnection(_connectionString);
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM StudentQuiz", connection);
                SqlDataReader reader = command.ExecuteReader();
                studentQuizzes = new List<StudentQuiz>();
                while (reader.Read())
                {
                    var studentQuiz = new StudentQuiz();
                    studentQuiz.Id = (int)reader["Id"];
                    studentQuiz.StudentId = (int)reader["StudentId"];
                    studentQuiz.QuizId = (int)reader["QuizId"];
                    studentQuiz.FinalScore = (double)reader["FinalScore"];
                    studentQuiz.CreatedAt = (DateTime)reader["CreatedAt"];
                    studentQuiz.UpdatedAt = (DateTime)reader["UpdatedAt"];
                    studentQuizzes.Add(studentQuiz);
                }

                return studentQuizzes;
            }
        }
    }
}
