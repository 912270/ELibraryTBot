using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ELibraryBot bot = new ELibraryBot(ClassLibrary1.Model.Constants.TOKEN);
            Repo<Author> authors = new Repo<Author>();
            Repo<Book> books = new Repo<Book>();

            books.Add(new Book("Ведьмак. Последнее желание", Genre.Fantasy, authors.list.Where(a => a.SecondName == "Сапковский" && a.FirstName == "Анджей").ToList()));

            //authors.Add(new Author("Анджей", "Сапковский"));

            Console.WriteLine(books.Read(1));

            Console.ReadLine();

            /*Author author1 = new Author();
            Author author2 = new Author();

            List<Author> authorList = new List<Author>();
            authorList.Add(author1);
            authorList.Add(author2);

            Book book = new Book(authorList);

            Console.WriteLine(String.Format("{0}", book.PrintInfo()));*/
        }
    }
}
