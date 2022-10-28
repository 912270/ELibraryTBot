using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model.Exceptions
{
    class NotFoundEntityException: Exception
    {
        /// <summary>
        /// Сущность не найдена
        /// </summary>
        /// <param name="message"></param>
        public NotFoundEntityException(string message = "Сущность не существует") : base(message) { }
    }
}
