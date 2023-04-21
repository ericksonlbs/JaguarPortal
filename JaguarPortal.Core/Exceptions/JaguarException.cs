using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaguarPortal.Core.Exceptions
{
    public abstract class JaguarException : Exception
    {
        public JaguarException(string message) : base(message) { }
        public abstract ErrorTypeEnum ErrorType { get; }
    }
}
