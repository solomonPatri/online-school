using online_school.Books.model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;


namespace online_school.Books.Services
{
    public class ServiceBook
    {
        private List<Book> _books;
        public ServiceBook()
        {
          
            this.load();
         

        }

        public void load()
        {
            _books = new List<Book>()
            {
                new Book(1, "Book 1", 101),
                new Book(2, "Book 2", 102),
                new Book(3, "Book 3", 103),
                new Book(4, "Book 4", 104),
                new Book(5, "Book 5", 105),
                new Book(6, "Book 6", 106),
                new Book(7, "Book 7", 107),
                new Book(8, "Book 8", 108),
                new Book(9, "Book 9", 109),
                new Book(10, "Book 10", 110)

            };


        }
        public void afisareBook()   
        {
            for (int i = 0; i < _books.Count; i++)
            {
                Console.WriteLine(_books[i].DescriereBook());
            }

        }
        public bool deleteBook(string nume, int studentid)
        {
            List<Book> book = _books;

            for (int i = 0; i < book.Count; i++)
            {
                if (nume.Equals(book[i].NameBook) && studentid.Equals(book[i].StudentId))
                {
                    this._books.Remove(book[i]);
                    return true;
                }

            }
            return false;


        }
        public Book GetBookById(int id)
        {
            List<Book> books = _books;
            for(int i=0; i<books.Count; i++)
            {
                if (books[i].Id == id)
                {
                    return books[i];


                }

            }
            return null;

        }
        public void adaugareBook(Book newcarte)
        {
            newcarte.Id = this.GenerateIdUnique();
            this._books.Add(newcarte);

        }
        public int GenerateIdUnique()
        {
            Random random = new Random();
            int nrrandom = random.Next(100, 10000);

            while(GetBookById(nrrandom) != null)
            {
                nrrandom = random.Next(100, 10000);
            }

            return nrrandom;


        }


    }
   
}