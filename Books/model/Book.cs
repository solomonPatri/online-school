using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school.Books.model
{
    public class Book
    {
        private int _studentId;
        private string _nameBook;







        public int StudentId
        {
            get { return _studentId; }
            set { _studentId = value; }

        }
        public string NameBook
        {
            get { return _nameBook; }
            set { _nameBook = value; }

        }


        public string DescriereBook()
        {
            string desc = " ";
            desc += "Carte: " + this._nameBook + "\n";

            return desc; 

        }


        public Book (string nume,int studentId)
        {
            _nameBook = nume;
            _studentId = studentId;

        }






    }
}
