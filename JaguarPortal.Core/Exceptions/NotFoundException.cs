using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaguarPortal.Core.Exceptions
{

    [Serializable]
    public class NotFoundObjectException : JaguarException
    {
        public NotFoundObjectException(string message) : base(message) { }
        public override ErrorTypeEnum ErrorType { get => ErrorTypeEnum.NotFoundException; }
    }
}
