﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_Exam.Exceptions
{
    internal class InvalidSurNameException:Exception
    {
        public InvalidSurNameException(string message):base(message)
        {
        }
    }
}
