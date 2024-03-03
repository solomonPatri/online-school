using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_school.Profesorii.model;

namespace online_school.Profesorii.service
{
    public class ServiceProfesor
    {
        private List<Profesor> _serviceprof;

        public ServiceProfesor()
        {
            _serviceprof = new List<Profesor>();
            this.load();
        }
        public void load()
        {
            Profesor p1 = new Profesor(67, "Mircea", 234, "Medicina", "svfdc@gmail.com"," ");
            Profesor p2 = new Profesor(24,"Maria",2531,"Mecanica","maria34@yahoo.com", "");
            Profesor p3 = new Profesor(22,"Raluca ",3554,"Mate-Info","ralnuv@gmail.com", "");
            Profesor p4 = new Profesor (3,"Silviu",2340,"Informatica","dancsilv@gmail.com", "");

            _serviceprof.Add(p1);
            _serviceprof.Add(p2);
            _serviceprof.Add(p3);
            _serviceprof.Add(p4);



        }

        public void afisare()
        {
            for(int i=0;i<_serviceprof.Count;i++)
            {
                Console.WriteLine(_serviceprof[i].DescriereProfesor());
            }
        }
        public Profesor GetProfesorById(int id)
        {
            List<Profesor> profesor = _serviceprof;
            for(int i = 0; i < profesor.Count; i++)
            {
                if (profesor[i].IdProfesor == id)
                {
                    return profesor[i];
                }
            }
            return null;

        }

        public int GenerateProfesorId()
        {
            Random random = new Random();
            int nrrandom = random.Next(10,10001);
            while(GetProfesorById(nrrandom) != null)
            {
                nrrandom = random.Next(10,10001);

            }
            return nrrandom;
        }
        public void adaugareProf(Profesor newprof)
        {
            newprof.IdProfesor = GenerateProfesorId();
            this._serviceprof.Add(newprof);
        }
        public bool DeleteProf(string nume)
        {
            List<Profesor> profesor = _serviceprof;
            for(int i=0;i< profesor.Count;i++)
            {
                if (profesor[i].Nume.Equals(nume))
                {
                    this._serviceprof.Remove(profesor[i]);
                    return true;

                }


            }
            return false;
        }

        










    }
}
