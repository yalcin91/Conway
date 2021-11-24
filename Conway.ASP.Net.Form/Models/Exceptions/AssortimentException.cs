using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway.ASP.Net.Form.Models.Exceptions
{
    public class AssortimentException : Exception
    {
        public AssortimentException(string message) : base(message)
        {
        }

        public AssortimentException(string message, SystemException innerException) : base(message, innerException)
        {
        }
    }
}
