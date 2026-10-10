using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizExamSystem.Data.Models
{
    public class BaseEntity
    {
        public int Id { get; set;  }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        protected BaseEntity()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
        public void UpdateDate()
        {
            this.UpdatedAt = DateTime.Now;
        }
    }
}
