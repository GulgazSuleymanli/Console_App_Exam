using Console_App_Exam.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_Exam.Models
{
    internal class Blog
    {
        static int _id;
        public int Id { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string BlogType { get; set; }

        public Blog(string blogtype)
        {
            Id = ++_id;
            BlogType = blogtype;
        }

        public Blog(string title, string description, string blogType)
        {
            Title = title;
            Description = description;
            BlogType = blogType;
            Id = ++_id;
            BlogType = blogType;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}, Blog type: {BlogType}, Description: {Description}";
        }
    }
}
