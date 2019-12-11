using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public enum ErrorType
    {
        OK, AuthenticationError, ActionError
    }
    public class Error
    {
        public ErrorType Type { get; set; }

        public string Message { get; set; }
    }
}
