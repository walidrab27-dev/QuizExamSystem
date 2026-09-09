using QuizExamSystem.Data.Data;
using QuizExamSystem.Data.Enums;
using QuizExamSystem.Data.Models;
using QuizExamSystem.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuizExamSystem.ConsoleUI.UI
{
    public class TeacherDashboard : Menu
    {
        private Teacher _teacher;
        private TeacherService _teacherService = new TeacherService();
        public TeacherDashboard(Teacher teacher)
        {
            this._teacher = teacher;
        }
        public override void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\tTeacher Dashboard\t\t");
                Console.ResetColor();

                Console.WriteLine();
                Console.WriteLine("1.\tView Unassigned Courses");
                Console.WriteLine("2.\tAssign to a Course");
                Console.WriteLine("3.\tView My Courses");
                Console.WriteLine("4.\tView My Quizzes");
                Console.WriteLine("5.\tRelease a Course");
                Console.WriteLine("6.\tCreate Quiz");
                Console.WriteLine("7.\tAdd Question to Quiz");
                Console.WriteLine("8.\tRemove Question from Quiz");
                Console.WriteLine("9.\tLogout");
                Console.WriteLine();

                Console.Write("Enter a number between 1 And 9: ");
                if (!TryGetChoice(out int choice))
                    continue;

                switch (choice)
                {
                    case 1:
                        ViewAllUnassinedCourses();
                        break;
                    case 2:
                        AssignToCourse();
                        break;
                    case 3:
                        ViewAllAssinedCourses();
                        break;
                    case 4:
                        ViewMyQuizzes();
                        break;
                    case 5:
                        ReleaseCourse();
                        break;
                    case 6:
                        CreateQuiz();
                        break;
                    case 7:
                        AddQuestionToQuiz();
                        break;
                    case 8:
                        RemoveQuestionFromQuiz();
                        break;
                    case 9:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Logged out");
                        Console.ResetColor();
                        WaitForKeyPress();
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid option between 1 and 9.");
                        Console.ResetColor();
                        WaitForKeyPress();
                        break;
                }

            }
        }
        private Course GetCourse(int courseId)
        {
            foreach (var course in DatabaseMock.Courses)
            {
                if (course.Id == courseId)
                {
                    return course;
                }
            }
            throw new ArgumentException("There is not course with this id in the system");
        }
        private Quiz GetQuiz(int quizId)
        {
            foreach (var quiz in _teacher.Quizzes)
            {
                if (quiz.Id == quizId)
                {
                    return quiz;
                }
            }
            throw new ArgumentException("there is not any quiz with this id in your quizes");
        }
        private Question GetQuestion(int questionId)
        {
            foreach (var quiz in _teacher.Quizzes)
            {
                foreach (var question in quiz.Questions)
                {
                    if (question.Id == questionId)
                        return question;
                }
            }
            throw new ArgumentException("there is not any question with this id in your questions");
        }
        private void AssignToCourse()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\tAssign to Course\t\t\n");
            Console.ResetColor();

            Console.Write("Enter Couerse Id: ");
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
                var targetCourse = GetCourse(courseId);
                _teacherService.AssignToCourse(targetCourse, this._teacher);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Course Assigned Successfully!");
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
        private void ViewAllUnassinedCourses()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\tALl Courses\t\t");
            Console.ResetColor();
            Console.WriteLine();

            if (_teacherService.GetUnAssignedCourses().Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t[i] there are not available Courses right now.");
                Console.ResetColor();
                WaitForKeyPress();
                return;
            }
            foreach (var course in _teacherService.GetUnAssignedCourses())
            {
                Console.WriteLine($"\t[{course.Id}]. {course.Name}");
                Console.WriteLine();
                Console.WriteLine($"Category          : {course.Category}");
                Console.WriteLine($"Duration          : {course.Duration}");
                Console.WriteLine();
            }
            WaitForKeyPress();
        }
        private void ViewAllAssinedCourses()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\tMy Courses\t\t");
            Console.ResetColor();
            Console.WriteLine();

            if (_teacherService.GetAllAssignedCourses(this._teacher).Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t[!] You didnt assign to any course yet.\n");
                Console.ResetColor();
                WaitForKeyPress();
                return;
            }

            for (var i = 0; i < _teacherService.GetAllAssignedCourses(this._teacher).Count; i++)
            {
                Console.WriteLine($"\t[{i + 1}]. {_teacherService.GetAllAssignedCourses(this._teacher)[i].Name} Course");
                Console.WriteLine($"Category          : {_teacherService.GetAllAssignedCourses(this._teacher)[i].Category}");
                Console.WriteLine($"Duration          : {_teacherService.GetAllAssignedCourses(this._teacher)[i].Duration}");
                Console.WriteLine($"Number of Lessons : {_teacherService.GetAllAssignedCourses(this._teacher)[i].NumberLessons}");
                Console.WriteLine($"Number of Quizzes : {_teacherService.GetAllAssignedCourses(this._teacher)[i].Quizzes.Count}");
                Console.WriteLine();
            }
            WaitForKeyPress();
        }
        private void ViewMyQuizzes()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t\tMy Quizzes\t\t");
                Console.ResetColor();
                Console.WriteLine();
                if (_teacherService.GetAllQuizzes(this._teacher).Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t[!] You didnt make any quiz yet.\n");
                    Console.ResetColor();
                    WaitForKeyPress();
                    return;
                }
                for (var i = 0; i < _teacherService.GetAllQuizzes(this._teacher).Count; i++)
                {
                    Console.WriteLine($"\t[{i + 1}]. {_teacherService.GetAllQuizzes(this._teacher)[i].Name} Quiz");
                    Console.WriteLine($"Duration          : {_teacherService.GetAllQuizzes(this._teacher)[i].Duration}");
                    Console.WriteLine($"Number of Students: {_teacherService.GetAllQuizzes(this._teacher)[i].StudentQuizzes.Count}");

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Quiz Questions    :");
                    Console.ResetColor();

                    for (var j = 0; j < _teacherService.GetAllQuizzes(this._teacher)[i].Questions.Count; j++)
                    {
                        Console.WriteLine($"[{i + 1}]. {_teacherService.GetAllQuizzes(this._teacher)[i].Questions[j].Text} ?");
                    }
                    Console.WriteLine();
                }
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
        private void ReleaseCourse()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\tRelease a course\t\t");
            Console.ResetColor();
            Console.WriteLine();

            Console.Write("Enter course Id you want to release: ");
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
                var targetCourse = GetCourse(courseId);
                _teacherService.ReleaseCourse(targetCourse, this._teacher);
                Console.Clear(); Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("your course is released succesfully.");
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
        private void CreateQuiz()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\tAdd New Quiz\t\t");
            Console.ResetColor();
            Console.WriteLine();

            Console.Write("\nEnter Couerse Id: ");
            if (!int.TryParse(Console.ReadLine(), out int courseId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Please enter a valid positive number.");
                Console.ResetColor();
                WaitForKeyPress();
                return;
            }
            Console.WriteLine();

            bool isFound = false;
            foreach (var course in this._teacher.Courses)
            {
                if (course.Id == courseId)
                    { isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You dont have this course");
                Console.ResetColor();
                WaitForKeyPress();
                return;
            }
            Console.WriteLine();

            Console.Write("Enter Name of the Quiz: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Quiz name cannot be empty.");
                Console.ResetColor();
                WaitForKeyPress();
                return;
            }
            Console.WriteLine();

            Console.Write("\nEnter duration (HH:mm:ss): ");
            if (!TimeSpan.TryParse(Console.ReadLine(), out TimeSpan duration))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid time format! Please use HH:mm:ss (e.g., 02:30:00).");
                Console.ResetColor();
                WaitForKeyPress();
                return;
            }
            Console.WriteLine();


            try
            {
                Console.Clear();
                var targetCourse = GetCourse(courseId);
                _teacherService.CreateQuiz(name, duration, targetCourse, this._teacher);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Quiz Created Successfully!");
                Console.ResetColor();
                WaitForKeyPress();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                WaitForKeyPress();
            }
        }
        private void AddQuestionToQuiz()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\tAdd New Question\t\t\n");
            Console.ResetColor();

            Console.Write("Enter The Question: ");
            string text = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(text))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! question cannot be empty.");
                Console.ResetColor();
                WaitForKeyPress();
                return;
            }
            Console.WriteLine();

            Console.Write("\nEnter Score: ");
            if (!double.TryParse(Console.ReadLine(), out double score))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Please enter a valid positive number.");
                Console.ResetColor();
                WaitForKeyPress();
                return;
            }
            Console.WriteLine();

            Console.Write("\nEnter Quiz Id: ");
            if (!int.TryParse(Console.ReadLine(), out int quizId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Please enter a valid positive number.");
                Console.ResetColor();
                WaitForKeyPress();
                return;
            }
            Console.WriteLine();

            Console.Write("\nEnter QuestionType: ");
            if (!Enum.TryParse<QuestionTypes>(Console.ReadLine(), true, out QuestionTypes type))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Type! Please enter a valid category name.");
                Console.ResetColor();
                WaitForKeyPress();
                return;
            }
            Console.WriteLine();

            try
            {
                Console.Clear();
                var targetQuiz = GetQuiz(quizId);
                var question = _teacherService.AddQuestion(text, score, targetQuiz, this._teacher, type);
                AddAnswer(question);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nQuestion Added Successfully!");
                Console.ResetColor();
                WaitForKeyPress();
            }
            catch (ArgumentException ex)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{ex.Message}");
                Console.ResetColor();
                WaitForKeyPress();
            }
        }
        private void RemoveQuestionFromQuiz()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\tRemove a Question\t\t\n");
            Console.ResetColor();

            Console.Write("Enter Quiz Id: ");
            if (!int.TryParse(Console.ReadLine(), out int quizId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Please enter a valid positive number.");
                Console.ResetColor();
                WaitForKeyPress();
                return;
            }
            Console.WriteLine();

            Console.Write("\nEnter Question Id: ");
            if (!int.TryParse(Console.ReadLine(), out int questionId))
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
                var targetQuestion = GetQuestion(questionId);
                _teacherService.RemoveQuestion(GetQuiz(quizId), GetQuestion(questionId), this._teacher);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Question Removed Successfully!");
                Console.ResetColor();
                WaitForKeyPress();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                WaitForKeyPress();
            }
        }
        public void AddAnswer(Question question)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\tAdd Answers\t\t\n");
            Console.ResetColor();

            Console.WriteLine($"Question: {question.Text} ?");

            Console.Write("Enter the CORRECT Answer: ");
            string text = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(text))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Answer cannot be empty.");
                Console.ResetColor();
                WaitForKeyPress();
                return;
            }

            try
            {
                Console.Clear();

                if (question is TrueFalse)
                {
                    string lowerText = text.ToLower();
                    if (lowerText != "true" && lowerText != "false")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input! True/False answer must be 'true' or 'false'.");
                        Console.ResetColor();
                        WaitForKeyPress();
                        return;
                    }

                    _teacherService.AddAnswerToQuestion(lowerText, true, question);

                    string wrongAnswer = lowerText == "true" ? "false" : "true";
                    _teacherService.AddAnswerToQuestion(wrongAnswer, false, question);
                }
                else if (question is MultipleChoice)
                {
                    _teacherService.AddAnswerToQuestion(text, true, question);

                    Console.WriteLine("\nNow, enter 3 WRONG answers:\n");
                    for (var i = 0; i < 3; i++)
                    {
                        Console.Write($"Enter wrong answer {i + 1}: ");
                        string wrongAnswerText = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(wrongAnswerText))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input! Answer cannot be empty.");
                            Console.ResetColor();
                            WaitForKeyPress();
                            return;
                        }

                        _teacherService.AddAnswerToQuestion(wrongAnswerText, false, question);
                        Console.WriteLine();
                    }
                }
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nAnswers Added Successfully!");
                Console.ResetColor();
                WaitForKeyPress();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                WaitForKeyPress();
            }
        }
    }
}
