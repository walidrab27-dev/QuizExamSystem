using QuizExamSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizExamSystem.Data.Interfaces
{
    public interface IDatabaseManager
    {
        List<Student> Students();
        List<Admin> Admins();
        List<Teacher> Teachers();
        List<Course> Courses();
        List<Quiz> Quizzes();
        List<Question> Questions();
        List<Answer> Answers();
        List<Enrollment> Enrollments();
        List<StudentQuiz> StudentQuizzes();
    }
}
