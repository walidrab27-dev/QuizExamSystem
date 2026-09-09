using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizExamSystem.Data.Models
{
    public class MultipleChoice : Question
    {
        public MultipleChoice(string text, double score, Quiz quiz) : base(text, score, quiz)
        {
        }

        public override double Evaluate(string answer)
        {
            foreach (var item in Answers)
            {
                if (item.Text.Equals(answer, StringComparison.OrdinalIgnoreCase) && item.IsCorrect)
                {
                    return Score;
                }
            }
            return 0;
        }
    }
}
