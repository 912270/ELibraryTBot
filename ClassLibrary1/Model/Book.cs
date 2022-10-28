using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
{
    public class Book: Entity
    {
        static int id;
        public int BookId { get; private set; }
        public string Name { get; private set; }
        public List<Author> AuthorList = new List<Author>();
        public Genre Genre { get; private set; }

        public Book(string name, Genre genre, List<Author> authorList)
        {
            BookId = Interlocked.Increment(ref id);
            Name = String.Format("Книга{0}", BookId);
            AuthorList = authorList;
            authorList.ForEach(al => al.BookList.Add(this));
        }

        public Book(List<Author> authorList){
            BookId = Interlocked.Increment(ref id);
            Name = String.Format("Книга{0}", BookId);
            AuthorList = authorList;
            authorList.ForEach(al => al.BookList.Add(this));
        }

        public string PrintInfo(){
            var authors = String.Empty;
            if (AuthorList.Count > 1){
                foreach (Author author in AuthorList)
                    authors += String.Format("{0}, ", author.ShortName());
                authors = authors.Remove(authors.Length - 2);
            }else
                authors = AuthorList.FirstOrDefault().ShortName();
            return String.Format("\"{0}\".{1}Авторы: {2}", Name, Environment.NewLine, authors);
        }

        public override bool Equals(object? obj){
            if (obj is Book book)
                if (this.Name == book.Name && this.Genre == book.Genre)
                    return true;
            return false;
        }
    }
}
