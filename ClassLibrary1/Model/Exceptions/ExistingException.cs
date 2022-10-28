using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model.Exceptions
{
    class ExistingException: Exception
    {
        /// <summary>
        /// Сущность уже существует
        /// </summary>
        /// <param name="message"></param>
        public ExistingException(string message = "Сущность уже существует") : base(message) { }
    }
}
