using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
{
    public class Author: Entity
    {
        static int id;
        public int AuthorId { get; private set; }
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public List<Book> BookList = new List<Book>();

        public Author(string firstName, string secondName)
        {
            AuthorId = Interlocked.Increment(ref id);
            FirstName = firstName;
            SecondName = secondName;
        }

        public string ShortName()
        {
            return String.Format("{0} {1}.", SecondName, FirstName[0].ToString().ToUpper());
        }

        public override bool Equals(object? obj)
        {
            if (obj is Author author)
                if (this.FirstName == author.FirstName && this.SecondName == author.SecondName)
                    return true;
            return false;
        }
    }
}
