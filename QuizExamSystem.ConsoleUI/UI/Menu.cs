using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizExamSystem.ConsoleUI.UI
{
    public abstract class Menu
    {
        public abstract void Show();
        protected void WaitForKeyPress()
        {
            Console.WriteLine("Press any key to try again...");
            Console.ReadKey();
        }
        protected bool TryGetChoice(out int choice)
        {
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Please enter numbers only.");
                Console.ResetColor();

                WaitForKeyPress();
                return false;
            }

            return true;
        }
    }
}
