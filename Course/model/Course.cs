using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school.Course.model
{
    public  class Course
    {
        private string _nameCurs;
        private string _departament;




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


        public string DescriereCurs()
        {
            string desc = "  ";
            desc += "Titlul: " + this._nameCurs+"\n";
            desc += "Departament: " + this._departament + "\n";
            return desc;



        }





    }
}
