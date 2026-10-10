using Microsoft.Data.SqlClient;
using QuizExamSystem.ConsoleUI.UI;
using QuizExamSystem.Data.Interfaces;
using QuizExamSystem.Data.Models;
using QuizExamSystem.Data.Repositories;

namespace QuizExamSystem.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            //try
            //{


            //    IDatabaseManager dbManager = new SqlDatabaseManager(@"Server=walidrab27\SQLEXPRESS;Database=QuizExamSystemDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");
            //    var list = dbManager.Teachers();
            //    foreach (var member in list)
            //    {
            //        Console.WriteLine($"ID: {member.Id}, Name: {member.Name}, Email: {member.Email}");
            //    }
            //}
            //catch(SqlException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

        }
    }
}
