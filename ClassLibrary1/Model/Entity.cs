using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
{
    public abstract class Entity
    {
        static int id;
        public int EntityId { get; private set; }
    }
}
