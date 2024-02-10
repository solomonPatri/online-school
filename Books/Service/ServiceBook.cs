using online_school.Books.model;
using online_school.Student.model;
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
                new Book(1, "Matematica ", 9),
                new Book(2, "Inginerie", 2),
                new Book(3, "Medicina", 3),
                new Book(4, "Literatura", 4),
                new Book(5, "Istorie", 9),
                new Book(6, "Geografie", 6),
                new Book(7, "Informatica", 7),
                new Book(8, "Matematica", 9),
                new Book(9, "Inginerie", 9),
                new Book(10, "Spaniola", 10),

            };


        }
        public void afisareBook()   
        {
            for (int i = 0; i < _books.Count; i++)
            {
                Console.WriteLine(_books[i].DescriereBook());
            }

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

        
        public List<Book> FiltrareByStudentId(int studentid)
        {
            List<Book> book = new List<Book> ();
            for(int i =0;i< _books.Count;i++)
            {
                if (_books[i].StudentId == studentid)
                {
                    book.Add(_books[i]);
                }

            }
            return book;

        }
        public void SortaredupaNume()
        {
            List<Book> books = _books;

            for (int i = 0; i < books.Count - 1; i++)
            {
                for (int j = i + 1; j < books.Count; j++)
                {
                    if (books[i].NameBook.Equals(books[j].NameBook))
                    {
                        Book aux = books[i];
                        books[i] = books[j];
                        books[j] = aux;

                    }
                }
            }

        }
        public List<Book> BooksLista(int StudentId)
        {
            List<Book> books = FiltrareByStudentId(StudentId);
 
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine(books[i].DescriereBook());
                
            }
            return books;
        }
        public bool deleteBook(string numeales, int studentid)
        {
            List<Book> book = BooksLista(studentid);

            for (int i = 0; i < book.Count; i++)
            {
                if (book[i].NameBook.Equals(numeales))
                {
                    book.Remove(book[i]);
                    return true;
                }

            }
            return false;


        } // trebuie correctat







    }
   
}