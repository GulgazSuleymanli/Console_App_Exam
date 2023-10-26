using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_Exam.Exceptions
{
    internal class BlogNotFoundException:Exception
    {
        public BlogNotFoundException(string message):base(message)
        {
        }
    }
}
