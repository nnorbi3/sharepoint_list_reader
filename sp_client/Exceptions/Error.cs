using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public enum ErrorType
    {
        AuthenticationError, ActionError, ConnectionError,
    }
    public class Error : Exception
    {
        public ErrorType Type { get; }

        public new string Message { get; }

        public Error(ErrorType type, string message)
        {
            Type = type;
            Message = message;
        }
    }
}
