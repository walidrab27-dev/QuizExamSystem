using QuizExamSystem.Data.Enums;
using QuizExamSystem.Data.Models;
using QuizExamSystem.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizExamSystem.ConsoleUI.UI
{
    public class StudentMenu : Menu
    {
        private StudentService _studentService = new StudentService();
        public void StudentRegister()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\tStudent Restiration\t\t");
            Console.WriteLine();
            Console.ResetColor();

            Console.Write("Enter your Name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Name cannot be empty.");
                Console.ResetColor();
                WaitForKeyPress();
                return;
            }
            Console.WriteLine();

            Console.Write("Enter your Email: ");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! email cannot be empty.");
                Console.ResetColor();
                WaitForKeyPress();
                return;
            }
            Console.WriteLine();

            Console.Write("Enter your Password: ");
            string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Password cannot be empty and Must be >= 8.");
                Console.ResetColor();
                WaitForKeyPress();
                return;
            }
            Console.WriteLine();

            try
            {
                _studentService.Register(name, email, password);
                var loggedInStudent = _studentService.Login(email, password);

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Registered Successfully! Logging you in...");
                Console.ResetColor();
                WaitForKeyPress();
                StudentDashboard dashboard = new StudentDashboard(loggedInStudent);
                dashboard.Show();
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
        public Student StudentLogin(out bool goBack)
        {
            goBack = false;
            Console.Clear();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\tStudent Login\t\t");
            Console.WriteLine();
            Console.ResetColor();

            Console.Write("Enter your email please (or type 'exit' to go back): ");
            string email = Console.ReadLine();

            if (email.ToLower() == "exit") { goBack = true; return null; }
            Console.WriteLine();

            Console.Write("Enter your Password please: ");
            string password = Console.ReadLine();
            try
            {
                var loggedInStudent = _studentService.Login(email, password);

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Login Successful!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Welcome back, {loggedInStudent.Name}!");
                Console.ResetColor();
                WaitForKeyPress();

                return loggedInStudent;
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                WaitForKeyPress();
                return null;
            }
        }
        public void CheckStudent()
        {
            Student student = StudentLogin(out bool goBack);
            if (goBack)
            {
                return;
            }
            if (student != null)
            {
                StudentDashboard studentDashboard = new StudentDashboard(student);
                studentDashboard.Show();
                return;
            }
        }
        public override void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\tStudent Menu\t\t");
                Console.WriteLine();
                Console.ResetColor();

                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Back to main menu");
                Console.WriteLine();

                Console.Write("Enter a number between 1 And 3: ");
                if (!TryGetChoice(out int choice))
                    continue;

                switch (choice)
                {
                    case 1:
                        StudentRegister();
                        break;
                    case 2:
                        CheckStudent();
                        break;
                    case 3:
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid option between 1 and 4.");
                        Console.ResetColor();
                        WaitForKeyPress();
                        break;
                }
            }
        }
    }
}
