using Console_App_Exam.Exceptions;
using Console_App_Exam.Models;
using Console_App_Exam.Utilities;

namespace Console_App_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("______ Welcome ______");
            bool check = true;
            string input;
            do
            {
                Console.WriteLine("======== Menu ========");
                Console.WriteLine("~1~ Register");
                Console.WriteLine("~2~ Login");
                Console.WriteLine("----------------------");
                Console.WriteLine("Please, choose operation");
                Console.WriteLine("");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        bool exp=true;
                        do
                        {
                            Console.WriteLine("Please, insert name:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Please, insert surname:");
                            string surname = Console.ReadLine();
                            Console.WriteLine("Please, insert password:");
                            string password = Console.ReadLine();
                            try
                            {
                                UserService.Register(name, surname, password);
                                exp = false;
                            }
                            catch (InvalidNameException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (InvalidSurNameException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (InvalidPasswordException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        while (exp);
                        break;

                    case "2":
                        Console.Clear();
                    START:
                        Console.WriteLine("Please, insert username:");
                        string username= Console.ReadLine();
                        Console.WriteLine("Please, insert password:");
                        string pass= Console.ReadLine();
                        try
                        {
                            if (UserService.Login(username, pass))
                            {
                                GetBlogMenyu();
                            }
                            else
                            {
                                Console.WriteLine("Username or password incorrect");
                                goto START;
                            }
                        }
                        catch(BlogNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }
            }
            while (check);
        }

        public static void GetBlogMenyu()
        {
            Console.WriteLine("______ Welcome Blog Menyu ______");
            bool check = true;
            string input;

            do
            {
                Console.WriteLine("======== Blog Menu ========");
                Console.WriteLine("~1~ Add new blog");
                Console.WriteLine("~2~ Remove blog by Id");
                Console.WriteLine("~3~ Show blog detail by Id");
                Console.WriteLine("~4~ Show all blogs");
                Console.WriteLine("~5~ Show blog detail by value");
                Console.WriteLine("~0~ Exit program");
                Console.WriteLine("----------------------");
                Console.WriteLine("Please, choose operation");
                Console.WriteLine("");
                input = Console.ReadLine();

                switch(input)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Please, insert blog title:");
                        string blogtitle = Console.ReadLine();
                        Console.WriteLine("Please, insert blog description:");
                        string description = Console.ReadLine();
                        Console.WriteLine("Please, insert blog type: Programming, Educational or Thriller");
                        string type = Console.ReadLine();

                        Blog blog = new Blog(blogtitle, description, type);
                        BlogService.AddBlog(blog);
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Please, insert Id:");
                        int id = int.Parse(Console.ReadLine());
                        try 
                        {
                            BlogService.RemoveBlog(id);
                        }
                        catch(BlogNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Please, insert Id:");
                        int blogId = int.Parse(Console.ReadLine());
                        try 
                        {
                            BlogService.GetBlogById(blogId);
                        }
                        catch(BlogNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "4":
                        Console.Clear();
                        try
                        {
                            BlogService.GetAllBlogs();

                        }
                        catch(BlogNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "5":
                        Console.Clear();
                        Console.WriteLine("Please, insert search value");
                        string value= Console.ReadLine();
                        try
                        {
                            BlogService.GetBlogsByValue(value);
                        }
                        catch(BlogNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "0":
                        Console.WriteLine("Bye Bye");
                        check = false;
                        break;
                }
            }
            while (check);
        }
    }
}