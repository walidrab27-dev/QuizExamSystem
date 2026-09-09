using QuizExamSystem.Data.Models;
using QuizExamSystem.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizExamSystem.ConsoleUI.UI
{
    public class AdminMenu : Menu
    {
        private AdminService _adminService = new AdminService();
        public override void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\tAdmin Menu\t\t");
                Console.ResetColor();

                Admin admin = AdminLogin(out bool goBack);

                if (goBack)
                {
                    return;
                }
                if (admin != null)
                {
                    AdminDashboard dashboard = new AdminDashboard(admin);
                    dashboard.Show();
                    return;
                }
            }
        }
        private Admin AdminLogin(out bool goBack)
        {
            goBack = false;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\tAdmin Login\t\t");
            Console.WriteLine();
            Console.ResetColor();

            Console.Write("Enter your email please (or type 'exit' to go back): ");
            string email = Console.ReadLine();
            if (email.ToLower() == "exit" ) { goBack = true;  return null; }
            Console.WriteLine();

            Console.Write("Enter your Password please: ");
            string password = Console.ReadLine();
            try
            {
                var loggedInAdmin = _adminService.Login(email, password);

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Login Successful!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Welcome back, {loggedInAdmin.Name}!");
                Console.ResetColor();
                WaitForKeyPress();

                return loggedInAdmin;
            }
            catch(UnauthorizedAccessException ex)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                WaitForKeyPress();
                return null;
            }
        }
    }
}
