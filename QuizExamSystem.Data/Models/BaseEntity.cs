using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizExamSystem.Data.Models
{
    public class BaseEntity
    {
        private static readonly Dictionary<Type, int> _counters = new();
        public int Id { get; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        protected BaseEntity()
        {
            var type = GetType();

            if (!_counters.ContainsKey(type))
                _counters[type] = 1;
            Id = _counters[type]++;

            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
        public void UpdateDate()
        {
            this.UpdatedAt = DateTime.Now;
        }
    }
}
