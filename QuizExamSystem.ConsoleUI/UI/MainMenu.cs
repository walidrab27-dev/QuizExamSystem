using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace QuizExamSystem.ConsoleUI.UI
{
    public class MainMenu : Menu
    {
        public override void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\tQuiz Exam System\t\t");
                Console.ResetColor();

                Console.WriteLine();
                Console.WriteLine("1.\tLogin as Admin");
                Console.WriteLine("2.\tLogin as Teacher / Register as Teacher");
                Console.WriteLine("3.\tLogin as Student / Register as Student");
                Console.WriteLine("4.\tExit");
                Console.WriteLine();

                Console.Write("Enter a number between 1 And 4: ");
                if (!TryGetChoice(out int choice))
                    continue;

                switch (choice)
                {
                    case 1:
                        AdminMenu adminMenu = new AdminMenu();
                        adminMenu.Show();
                        break;
                    case 2:
                        TeacherMenu teacherMenu = new TeacherMenu();
                        teacherMenu.Show();
                        break;
                    case 3:
                        StudentMenu studentMenu = new StudentMenu();
                        studentMenu.Show();
                        break;
                    case 4:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Good Bye");
                        Console.ResetColor();
                        Environment.Exit(0);
                        break;
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
