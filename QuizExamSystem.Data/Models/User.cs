using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizExamSystem.Data.Models
{
    public class User : BaseEntity
    {
        private string _name;
        private string _email;
        private string _password;
        public string Name
        {
            get => this._name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }
                this._name = value;
            }
        }
        public string Email
        {
            get => this._email;
            set
            {
                if(IsEmailCorrect(value))
                {
                    this._email = value;
                }
                else
                {
                    throw new ArgumentException("Invalid email format.");
                }
            }
        }
        public string Password
        {
            get=>this._password;
            set
            {
                if(IsPasswordCorrect(value))
                {
                    this._password = value;
                }
                else
                {
                    throw new ArgumentException("Invalid password format.");
                }
            }
        }
        private bool IsEmailCorrect(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or empty.");
            }
            var isGood = email.Contains("@") && email.Contains(".com");
            return isGood;
        }
        private bool IsPasswordCorrect(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be null or empty.");
            }
            var isGood = password.Length >= 8;
            return isGood;
        }
        public User(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }
    }
}
