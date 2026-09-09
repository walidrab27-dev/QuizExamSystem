using QuizExamSystem.Data.Data;
using QuizExamSystem.Data.Enums;
using QuizExamSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace QuizExamSystem.Data.Services
{
    public class TeacherService
    {
        public void Register(string name, string email, string password, TeacherTitles title)
        {
            var teacher = new Teacher(name, email, password, title);
            DatabaseMock.Teachers.Add(teacher);
        }
        public Teacher Login(string email, string password)
        {
            foreach (var teacher in DatabaseMock.Teachers)
            {
                if (teacher.Email == email && teacher.Password == password)
                    return teacher;
            }
            throw new UnauthorizedAccessException("Invalid email or password!");
        }
        public void AssignToCourse(Course course, Teacher teacher)
        {
            if (DatabaseMock.Courses.Count == 0)
                throw new ArgumentException("there are not any courses yet.");
            if (course.Teacher == null)
            {
                course.Teacher = teacher;
                teacher.Courses.Add(course);
            }
            else if (course.Teacher == teacher)
            {
                throw new ArgumentException("You already teach this course.");
            }
            else
                throw new ArgumentException($"there is another one teach this course.");
        }
        public void ReleaseCourse(Course course, Teacher teacher)
        {
            if (course.Teacher != teacher)
            {
                throw new ArgumentException("You dont teach this course");
            }
            if (course.Enrollments.Count == 0)
            {
                course.Teacher = null;
                teacher.Courses.Remove(course);
            }
            else
                throw new ArgumentException("You cant rlease course is taken by some Students");
        }
        public List<Course> GetAllAssignedCourses(Teacher teacher)
        {
            return teacher.Courses;
        }
        public List<Course> GetUnAssignedCourses()
        {
            var unAssigned = new List<Course>();
            foreach (var course in DatabaseMock.Courses)
                if (course.Teacher == null)
                    unAssigned.Add(course);
            return unAssigned;
        }
        public void CreateQuiz(string name, TimeSpan duration, Course course, Teacher teacher)
        {
            var quiz = new Quiz(name, duration, course, teacher);
            DatabaseMock.Quizzes.Add(quiz);
            teacher.Quizzes.Add(quiz);
            course.Quizzes.Add(quiz);
        }
        public Question AddQuestion(string text, double score, Quiz quiz, Teacher teacher, QuestionTypes type)
        {
            Question question;
            if (quiz.StudentQuizzes.Count == 0)
            {
                switch (type)
                {
                    case QuestionTypes.ShortAnswer:
                        question = new ShortAnswer(text, score, quiz);
                        DatabaseMock.Questions.Add(question);
                        quiz.Questions.Add(question);
                        return question;
                        break;
                    case QuestionTypes.MultipleChoice:
                        question = new MultipleChoice(text, score, quiz);
                        DatabaseMock.Questions.Add(question);
                        quiz.Questions.Add(question);
                        return question;
                        break;
                    case QuestionTypes.TrueFalse:
                        question = new TrueFalse(text, score, quiz);
                        DatabaseMock.Questions.Add(question);
                        quiz.Questions.Add(question);
                        return question;
                        break;
                }
            }
            throw new ArgumentException("You can't add question to a quiz that already taken.");
        }
        public List<Quiz> GetAllQuizzes(Teacher teacher)
        {
            if (teacher.Courses.Count == 0)
                throw new ArgumentException("you don't have any courses to have quizzes");
            var myQuizzes = new List<Quiz>();
            foreach(var course in teacher.Courses)
            {
                foreach(var quiz in course.Quizzes)
                {
                    myQuizzes.Add(quiz);
                }
            }
            return myQuizzes;
        }
        public void RemoveQuestion(Quiz quiz, Question question, Teacher teacher)
        {
            if (question.Quiz.StudentQuizzes.Count == 0 && question.Quiz.Teacher == teacher)
            {
                DatabaseMock.Questions.Remove(question);
                quiz.Questions.Remove(question);
            }
        }
        public void AddAnswerToQuestion(string text, bool isCorrect, Question question)
        {
            var answer = new Answer(text, isCorrect);
            DatabaseMock.Answers.Add(answer);
            question.Answers.Add(answer);
            question.AddAnswer(answer);
        }
    }
}
