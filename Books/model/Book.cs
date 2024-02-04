using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school.Books.model
{
    public class Book
    {
        private int _id;
        private int _studentId;
        private string _nameBook;

        public Book(int idbook, string nume, int studentId)
        {

            _id = idbook;
            _nameBook = nume;
            _studentId = studentId;

        }
        public Book( string nume, int studentId)
        {

            _nameBook = nume;
            _studentId = studentId;
        }


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

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


      






    }
}
