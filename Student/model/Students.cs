using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace online_school.Student.model
{
    public class Students
    {
        private int _id;
        private string _firstnameStudent;
        private string _facultate;
        private string _email;
        private int _age;
        private string _password;


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string FirstnameStudent
        {
            get { return _firstnameStudent; }
            set { _firstnameStudent = value; }
        }
        public string Facultate
        {
            get { return _facultate; }
            set { _facultate = value; }

        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }

        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }

        }
        public string Password
        {
            get { return _password ; }
            set { _password = value; }

        }


        public string DescriereStudent()
        {
            string desc = " ";
            desc += "Prenume: " + this._firstnameStudent + "\n";
            desc += "Facultate: " + this._facultate + "\n";
            desc += "Email: " + this._email + "\n";
            desc += "Varsta: " + this._age + "\n";
            return desc;

        }

        public Students(int id,string FirstName,string Facultate,string Email,int Age,string pass)
        {
            _id = id;
            _firstnameStudent= FirstName;
            _facultate= Facultate;
            _email = Email;
            _age = Age;
            _password = pass;
        }
        public Students(int id,string Firstname)
        {
            _id = id;
            _firstnameStudent = Firstname;
        }





    }
}
