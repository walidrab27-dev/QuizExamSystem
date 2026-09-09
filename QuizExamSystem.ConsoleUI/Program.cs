using QuizExamSystem.ConsoleUI.UI;
using QuizExamSystem.Data.Models;

namespace QuizExamSystem.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    MainMenu mainMenu = new MainMenu();
            //    mainMenu.Show();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }
    }
}
