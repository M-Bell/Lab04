using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02.Exceptions
{
    internal class PastBirthdayException : Exception
    {
        public PastBirthdayException(string message) : base(message) { }
        public PastBirthdayException(string message, Exception inner) : base(message, inner) { }
    }
}
