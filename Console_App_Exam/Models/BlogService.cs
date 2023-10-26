using Console_App_Exam.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_Exam.Models
{
    internal static class BlogService
    {
        public static void AddBlog(Blog blog)
        {
            BlogDatabase.Blogs.Add(blog);
        }

        public static Blog GetBlogById(int id)
        {
            Blog blog = BlogDatabase.Blogs.Find(blog => blog.Id == id);
            if (blog != null)
            {
                return blog;
            }
            else
            {
                throw new BlogNotFoundException("Blog not found");
            }
        }

        public static void RemoveBlog(int id)
        {
           Blog blog= GetBlogById(id);
           BlogDatabase.Blogs.Remove(blog);
        }

        public static void GetAllBlogs()
        {
            if (BlogDatabase.Blogs != null)
            {
                BlogDatabase.Blogs.ForEach(blog => Console.WriteLine(blog));
            }
            else
            {
                throw new BlogNotFoundException("Blog not found");
            }
        }

        public static List<Blog> GetBlogsByValue(string value)
        {
            if(BlogDatabase.Blogs != null)
            {
                return BlogDatabase.Blogs.FindAll(blog => blog.Description.Contains(value) || blog.Title.Contains(value));
            }
            else
            {
                throw new BlogNotFoundException("Blog not found");
            }
        }
    }
}
