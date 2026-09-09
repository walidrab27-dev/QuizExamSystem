using QuizExamSystem.Data.Data;
using QuizExamSystem.Data.Models;
using QuizExamSystem.Data.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuizExamSystem.ConsoleUI.UI
{
    public class StudentDashboard : Menu
    {
        private Student _student;
        private StudentService _studentService = new StudentService();
        public StudentDashboard(Student student)
        {
            this._student = student;
        }
        public override void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\tStudent Dashboard\t\t");
                Console.ResetColor();

                Console.WriteLine();
                Console.WriteLine("1.\tView Available Courses");
                Console.WriteLine("2.\tEnroll in a Course");
                Console.WriteLine("3.\tView My Courses");
                Console.WriteLine("4.\tView My Quizzes History");
                Console.WriteLine("5.\tTake a Quiz");
                Console.WriteLine("6.\tLogout");
                Console.WriteLine();

                Console.Write("Enter a number between 1 And 6: ");
                if (!TryGetChoice(out int choice))
                    continue;

                switch (choice)
                {
                    case 1:
                        ViewAllCourses();
                        break;
                    case 2:
                        EnrollInCourse();
                        break;
                    case 3:
                        ViewMyCourses();
                        break;
                    case 4:
                        ViewMyQuizzes();
                        break;
                    case 5:
                        SubmitQuiz();
                        break;
                    case 6:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Logged out");
                        Console.ResetColor();
                        WaitForKeyPress();
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid option between 1 and 6.");
                        Console.ResetColor();
                        WaitForKeyPress();
                        break;
                }

            }
        }
        private Course GetCourse(int courseId)
        {
            foreach (var enrollment in _student.Enrollments)
            {
                if (enrollment.Course.Id == courseId)
                {
                    return enrollment.Course;
                }
            }
            throw new ArgumentException("there is not any course with this id in your courses");
        }
        private Course GetCourseByID(int courseId)
        {
            foreach (var course in DatabaseMock.Courses)
            {
                if (course.Id == courseId)
                {
                    return course;
                }
            }
            throw new ArgumentException("there is not available courses in the system right now");
        }
        private Quiz GetQuiz(int quizId)
        {
            foreach (var enrollment in _student.Enrollments)
            {
                foreach (var quiz in enrollment.Course.Quizzes)
                {
                    if (quiz.Id == quizId)
                    {
                        return quiz;
                    }
                }
            }
            throw new ArgumentException("There is no quiz with this ID in your enrolled courses.");
        }
        private void ViewAllCourses()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\tAll COURSES\t\t");
            Console.ResetColor();
            Console.WriteLine();

            if (_studentService.GetAllAvailableCourses().Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\t[!] No courses available in the system yet.\n");
                Console.ResetColor();
                WaitForKeyPress();
                return;
            }

            foreach (var course in _studentService.GetAllAvailableCourses())
            {
                string teacherName = course.Teacher != null ? course.Teacher.Name : "Not Assigned Yet";
                Console.WriteLine($"\t\t{course.Id} {course.Name} Course\t\t");
                Console.WriteLine($"Teacher Name      : {teacherName}");
                Console.WriteLine($"Duration          : {course.Duration}");
                Console.WriteLine($"Number of Lessons : {course.NumberLessons}");
                Console.WriteLine($"Category          : {course.Category}");
                Console.WriteLine($"Number of Quizzes : {course.Quizzes.Count}");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Quiz Names:");
                Console.ResetColor();
                Console.WriteLine();

                if (course.Quizzes.Count==0)
                {
                    Console.ForegroundColor= ConsoleColor.Yellow;
                    Console.WriteLine($"\t[!]this Course dosen't have quizzes yet.");
                    Console.ResetColor();
                }

                foreach(var quiz in course.Quizzes)
                {
                    Console.WriteLine($"[{quiz.Id}]. {quiz.Name}");
                }

                Console.WriteLine();
            }
            WaitForKeyPress();

        }
        private void EnrollInCourse()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\tCourse Enrollment\t\t");
            Console.ResetColor();

            Console.WriteLine();
            Console.Write("Enter course Id you want to Enroll: ");
            if (!int.TryParse(Console.ReadLine(), out int courseId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Please enter a valid positive number.");
                Console.ResetColor();
                WaitForKeyPress();
                return;
            }
            Console.WriteLine();

            try
            {
                Console.Clear();
                var targetCourse = GetCourseByID(courseId);
                _studentService.EnrollInCourse(targetCourse, this._student);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You enrolled in {targetCourse.Name} course Successfully!");
                Console.ResetColor();
                WaitForKeyPress();
            }
            catch (ArgumentException ex)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                WaitForKeyPress();
            }
        }
        private void ViewMyCourses()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\tMy Courses\t\t");
            Console.ResetColor();

            if (_studentService.GetEnrolledCourses(this._student).Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\t[!] You dont have enrolled Courses right now.\n");
                Console.ResetColor();
                WaitForKeyPress();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\tMy COURSES\t\t");
            Console.ResetColor();

            foreach (var course in _studentService.GetEnrolledCourses(this._student))
            {
                Console.WriteLine($"\t\t{course.Id} {course.Name} Course\t\t");
                Console.WriteLine($"Teacher Name     : {course.Teacher.Name}");
                Console.WriteLine($"Duration         : {course.Duration}");
                Console.WriteLine($"Number of Lessons: {course.NumberLessons}");
                Console.WriteLine($"Category         : {course.Category}");
                Console.WriteLine($"Number of Quizzes : {course.Quizzes.Count}");

                Console.WriteLine("Quiz Names:");

                foreach (var quiz in course.Quizzes)
                {
                    Console.WriteLine($"\t• {quiz.Name}");
                }

                Console.WriteLine();
                Console.WriteLine();
            }
            WaitForKeyPress();
        }
        private void ViewMyQuizzes()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\tMy Quizzes History\t\t");
            Console.ResetColor();
            Console.WriteLine();

            if (_studentService.GetAllQuizzes(this._student).Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t[!] You dont have Any quizzes yet right now.\n");
                Console.ResetColor();
                WaitForKeyPress();
                return;
            }

            foreach (var studentQuiz in this._student.StudentQuizzes)
            {
                Console.WriteLine($"\t\t{studentQuiz.Quiz.Name}\t\t");
                Console.WriteLine($"Course Name      : {studentQuiz.Quiz.Course.Name}");
                Console.WriteLine($"Quiz Duration    : {studentQuiz.Quiz.Duration}");
                Console.WriteLine($"Final Score      : {studentQuiz.FinalScore} / {studentQuiz.Quiz.Questions.Sum(q => q.Score)}");
                Console.WriteLine("The Questions:");
                for (var i =0; i < studentQuiz.Quiz.Questions.Count;i++)
                {
                    Console.WriteLine($"Q[{i+1}]. {studentQuiz.Quiz.Questions[i].Text} ?");
                    Console.WriteLine($"\tyour answer was {studentQuiz.SubmittedAnswers[i]}");
                    Console.WriteLine();
                    for (var j = 0; j < studentQuiz.Quiz.Questions[i].Answers.Count;i++)
                    {
                        if (studentQuiz.Quiz.Questions[i].Answers[j].IsCorrect == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"the Correct answer was {studentQuiz.Quiz.Questions[i].Answers[j].Text}");
                            Console.ResetColor();
                            break;
                        }
                            
                    }
                }
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine();
            }
            WaitForKeyPress();


            WaitForKeyPress();
        }
        public void SubmitQuiz()
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\t\tSubmiting a qui\t\t");
            Console.ResetColor();
            Console.WriteLine();

            Console.Write("Enter Quiz Id you want to submit: ");
            if (!int.TryParse(Console.ReadLine(), out int quizId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Please enter a valid positive number.");
                Console.ResetColor();
                WaitForKeyPress();
                return;
            }
            Console.WriteLine();
            var targetQuiz = GetQuiz(quizId);

            var answers = new List<string>();
            for (var i = 0; i < targetQuiz.Questions.Count; i++)
            {
                Console.WriteLine($"\nQuestion {i + 1}: {targetQuiz.Questions[i].Text}");

                for(var j = 0; i < targetQuiz.Questions[i].Answers.Count;j++)
                {
                    Console.Write($"[{i+1}]. {targetQuiz.Questions[i].Answers[j]}\t");
                    if (i == targetQuiz.Questions[i].Answers.Count - 1)
                        Console.WriteLine();
                }

                Console.Write("Enter your answer: ");
                string answer = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(answer))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input! You didnt input an answer.");
                    Console.ResetColor();
                    WaitForKeyPress();
                    return;
                }
                answers.Add(answer);
            }

            try
            {
                Console.Clear();
                double finalScore = _studentService.SubmitQuiz(this._student, targetQuiz, answers);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Quiz Submitted Successfully!");
                Console.WriteLine($"Your Final Score is: {finalScore} / {targetQuiz.Questions.Sum(q => q.Score)}");
                Console.ResetColor();
                WaitForKeyPress();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                WaitForKeyPress();
            }
        }
    }
}
