using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace online_school.Profesorii.model
{
    public class Profesor
    {
        private int _idProf;
        private string _nume;
        private int _nrStudenti;
        private string _facultate;
        private string _email;
        private string _Password;


        public int IdProfesor
        {
            get { return _idProf; }
            set { _idProf = value; }
        }

        public string Nume
        {
            get { return _nume; }
            set { _nume = value; }
        }

        public int NrStudenti
        {
            get { return _nrStudenti; }
            set { _nrStudenti = value; }
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
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }

        }

        public string DescriereProfesor()
        {
            string desc = " ";
            desc += "Nume: " + this._nume + "\n";
            desc += "Nr de studenti: " + this._nrStudenti + "\n";
            desc += "Facultate: " + this._facultate + "\n";
            desc += "Email: " + this._email + "\n";
            return desc;
        }

        public Profesor(int Id, string nume,int nrStud,string Facultate,string Email,string Password)
        {
            _idProf = Id;
            _nume = nume;
            _nrStudenti= nrStud;
            _facultate = Facultate;
            _email = Email;
            _Password = Password;

        }


    }
}
