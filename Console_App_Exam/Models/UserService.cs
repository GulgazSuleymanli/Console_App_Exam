using Console_App_Exam.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_Exam.Models
{
    internal static class UserService
    {
        public static void Register(string name, string surname, string password)
        {
    
            if (name == null && name.Any(char.IsDigit))
            {
                throw new InvalidNameException("Invalid name");
            }
       

            if (surname == null && surname.Any(char.IsDigit))
            {
                throw new InvalidNameException("Invalid name");
            }
            
            if(!(password.Length>=8 && char.IsUpper(password[0]) && password.Any(char.IsDigit)))
            {
                throw new InvalidPasswordException("Invalid password");
            }

            User user = new User(name, surname, password);
            BlogDatabase.Users.Add(user);

        }

        public static bool Login(string username, string password)
        {
            if(GetUser(username, password) != null) 
            { 
                return true;
            }
            return false;
        }

        static List<User> GetUser(string username, string password)
        {
            if(BlogDatabase.Users.Count > 0)
            {
                List<User> users = BlogDatabase.Users.FindAll(user => user.Username == username && user.Password == password);
                return users;
            }
            else
            {
                throw new BlogNotFoundException("Blogs is empty");
            }
        }
    }
}
