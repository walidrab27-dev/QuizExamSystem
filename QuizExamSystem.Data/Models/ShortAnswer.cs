using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizExamSystem.Data.Models
{
    public class ShortAnswer : Question
    {
        public ShortAnswer(string text, double score, Quiz quiz) : base(text, score, quiz)
        {
        }

        public override double Evaluate(string answer)
        {
            if (Answers.Count == 0)
            {
                throw new InvalidOperationException("This question has no configured answers.");
            }

            if (Answers[0].Text.Equals(answer, StringComparison.OrdinalIgnoreCase))
            {
                return Score;
            }
            return 0;
        }
    }
}
