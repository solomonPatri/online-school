using online_school.Books.model;
using System;
using System.Collections.Generic;
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

            _books = new List<Book>();
            this.load();


        }

        public void load()
        {
            Book b1 = new Book("Matematica", GenerateStudentId());
            Book b2 = new Book("Literatura", GenerateStudentId());
            Book b3 = new Book("Engleza", GenerateStudentId());
            Book b4 = new Book("Sport", GenerateStudentId());

            _books.Add(b1);
            _books.Add(b2);
            _books.Add(b3);
            _books.Add(b4);

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
        public int GenerateStudentId()
        {
            Random random = new Random();
            int randomnumber = random.Next(1, 100001);
            while (randomnumber != null)
            {
                randomnumber = random.Next(1, 100001);

            }

            return randomnumber;

        }
        public Book returnbook(Book book)
        {
            List<Book> books = _books;
            for(int i =0; i < _books.Count; i++)
            {
                if (book.Equals(books[i]))
                {
                    return books[i];
                }
            }
            return book;
        }
       



    }
   
}