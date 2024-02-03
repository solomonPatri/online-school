using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school.Student.model
{
    public class Student
    {
        private string _firstnameStudent;
        private string _lastnameStudent;
        private string _email;
        private int _age;




        public string FirstnameStudent
        {
            get { return _firstnameStudent; }
            set { _firstnameStudent = value; }
        }
        public string LastnameStudent
        {
            get { return _lastnameStudent; }
            set { _lastnameStudent = value; }

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

        public string DescriereStudent()
        {
            string desc = " ";
            desc += "Prenume: " + this._firstnameStudent + "\n";
            desc += "Nume: " + this._lastnameStudent + "\n";
            desc += "Email: " + this._email + "\n";
            desc += "Varsta: " + this._age + "\n";
            return desc;

        }







    }
}
