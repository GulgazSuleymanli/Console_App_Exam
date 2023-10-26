using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_Exam.Models
{
    internal class User
    {
        static int _id;
        public int Id { get; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }

        public User()
        {
            Id = ++_id;
            Username = Name.ToLower() + '.' + Surname.ToLower();
        }

        public User(string name, string surname, string password)
        {
            Name = name;
            Surname = surname;
            Password = password;
            Id = ++_id;
            Username = Name.ToLower() + '.' + Surname.ToLower();
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Surname: {Surname}, Username: {Username}";
        }
    }
}
