using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02.Exceptions
{
    internal class FutureBirthdayException : Exception
    {
        public FutureBirthdayException(string message) : base(message) { }
        public FutureBirthdayException(string message, Exception inner) : base(message, inner) { }
    }
}
