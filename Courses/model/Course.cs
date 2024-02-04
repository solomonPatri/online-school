using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school.Courses.model
{
    public  class Course
    {
        private int _id;
        private string _nameCurs;
        private string _departament;



        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        public string NameCurs
        {
            get { return _nameCurs; }
            set { _nameCurs = value; }

        }
        public string Departament
        {
            get { return _departament; }
            set { _departament = value; }

        }
        public Course (int Id,string NameCurs, string Departament)
        {
            _id = Id;
            _nameCurs = NameCurs;   
            _departament = Departament;
        }

        public Course (string nameCurs, string departament)
        {
            _nameCurs = nameCurs;
            _departament = departament;

        }


        public string DescriereCurs()
        {
            string desc = "  ";
            desc += "Titlul: " + this._nameCurs+"\n";
            desc += "Departament: " + this._departament + "\n";
            return desc;



        }

        



    }
}
