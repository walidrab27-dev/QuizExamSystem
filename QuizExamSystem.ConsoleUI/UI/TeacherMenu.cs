using QuizExamSystem.Data.Enums;
using QuizExamSystem.Data.Models;
using QuizExamSystem.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuizExamSystem.ConsoleUI.UI
{
    public class TeacherMenu : Menu
    {
        private TeacherService _teacherService = new TeacherService();
        public override void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\tTeacher Menu\t\t\n");
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
                        TeacherRegister();
                        break;
                    case 2:
                        CheckTeacher();
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
        private void TeacherRegister()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\tTeacher Registeration\t\t\n");
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
            if (string.IsNullOrWhiteSpace(password) || password.Length<8)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Password cannot be empty and Must be >= 8.");
                Console.ResetColor();
                WaitForKeyPress();
                return;
            }
            Console.WriteLine();

            Console.Write("Enter your title please: ");
            if (!Enum.TryParse<TeacherTitles>(Console.ReadLine(),true,out TeacherTitles title))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Title! Please enter a valid title.");
                Console.ResetColor();
                WaitForKeyPress();
                return;
            }
            Console.WriteLine();

            try
            {
                _teacherService.Register(name, email, password, title);
                var loggedInTeacher = _teacherService.Login(email, password);

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Registered Successfully! Logging you in...");
                Console.ResetColor();
                WaitForKeyPress();
                TeacherDashboard dashboard = new TeacherDashboard(loggedInTeacher);
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
        private Teacher TeacherLogin(out bool goBack)
        {
            goBack = false;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\tTeacher Login\t\t\n");
            Console.ResetColor();

            Console.Write("Enter your email please (or type 'exit' to go back): ");
            string email = Console.ReadLine();

            if (email.ToLower() == "exit") { goBack = true; return null; }
            Console.WriteLine();

            Console.Write("Enter your Password please: ");
            string password = Console.ReadLine();
            try
            {
                var loggedInTeacher = _teacherService.Login(email, password);

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Login Successful!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Welcome back, {loggedInTeacher.Name}!");
                Console.ResetColor();
                WaitForKeyPress();

                return loggedInTeacher;
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
        private void CheckTeacher()
        {
            Teacher teacher = TeacherLogin(out bool goBack);
            if (goBack)
            {
                return;
            }
            if (teacher != null)
            {
                TeacherDashboard teacherDashboard = new TeacherDashboard(teacher);
                teacherDashboard.Show();
                return;
            }
        }
    }
}
