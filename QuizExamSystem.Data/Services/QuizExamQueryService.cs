using QuizExamSystem.Data.Models;
using QuizExamSystem.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizExamSystem.Data.Services
{
    public class QuizExamQueryService
    {
        private List<Admin> _admins;
        private List<Student> _students;
        private List<Teacher> _teachers;
        private List<Course> _courses;
        private List<Quiz> _quizzes;  
        private List<Question> _questions;
        private List<Answer> _answers;
        private List<StudentQuiz> _studentQuizzes;
        public QuizExamQueryService(IDatabaseManager databaseManager)
        {
            _admins = databaseManager.Admins();
            _students = databaseManager.Students();
            _teachers = databaseManager.Teachers();
            _courses = databaseManager.Courses();
            _quizzes = databaseManager.Quizzes();
            _questions = databaseManager.Questions();
            _answers = databaseManager.Answers();
            _studentQuizzes = databaseManager.StudentQuizzes();
        }
    }
}
