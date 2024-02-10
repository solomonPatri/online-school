using online_school.Courses.model;
using online_school.Student.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school.Courses.service
{
    public class ServiceCourse
    {
        private List<Course> _curs;

        public ServiceCourse()
        {
            _curs = new List<Course>();
            this.load();

        }
            
        public void load()
        {
            Course c1 = new Course(1,"Analiza matematica", "Matematica");
            Course c2 = new Course(2,"Mecanica", "Inginerie");
            Course c3 = new Course(3,"Literatura sec XI", "Romana");
            Course c4 = new Course(4,"Algebra", "Matematica");
            Course c5 = new Course(5,"Stefan cel mare ", "Istorie");
            Course c6 = new Course(6,"Electronica", "Inginerie");
            Course c7 = new Course(7,"Anatomie ", "Medicina");

            _curs.Add(c1);
            _curs.Add(c2);
            _curs.Add(c3);
            _curs.Add(c4);
            _curs.Add(c5);
            _curs.Add(c6);
            _curs.Add(c7);

        }
            
        public void afisare()
        {
            for(int i=0;i< _curs.Count;i++)
            {
                Console.WriteLine(_curs[i].DescriereCurs());
            }
        }
        public bool deleteCurs(string namecurs)
        {
            List<Course> cursuri = _curs;
            for(int i=0;i< cursuri.Count;i++)
            {
                if (cursuri[i].NameCurs.Equals(namecurs))
                {
                    this._curs.Remove(cursuri[i]);
                    return true;

                }

            }
            return false;
        }
        public Course GetCourseById(int idcurs)
        {
            List<Course> curs= _curs;
            for(int i=0;i< curs.Count; i++)
            {
                if (curs[i].Id==idcurs)
                {

                    return curs[i];
                }
            }
            return null;
        }
        public int GenerateIdUniqueCurs()
        {
            Random random = new Random();
            int randomNumber = random.Next(100, 10001);
            while(GetCourseById(randomNumber) != null)
            {
                randomNumber = random.Next(100, 10001);
            }
            return randomNumber;
        }
        public void adaugareCurs(Course course)
        {
            course.Id = this.GenerateIdUniqueCurs();
            this._curs.Add(course);
        }
        public void sortareAlfaCourse()
        {
            for(int i=0;i< _curs.Count-1 ;i++)
            {
                for(int j = i+1;j<_curs.Count;j++)
                {
                    if (_curs[i].Departament.CompareTo(_curs[j].Departament)>0) {
                         
                        Course aux = _curs[i];
                        _curs[i] = _curs[j];
                        _curs[j] = aux;
                    }
                }
            }
        }

        public List<Course> AfisareListaCourse()
        {
            List<Course> curs = _curs;
            sortareAlfaCourse();
            for(int i=0;i<curs.Count;i++)
            {
                Console.WriteLine(curs[i].DescriereCurs());
                

            }

            return curs;
        }

        public List<Course> FiltrarecursByProfesie(string studentFacultate)
        {
            List<Course> cursuri = new List<Course>();
            for(int i =0;i<_curs.Count;i++)
            {
                if (_curs[i].Departament.Equals(studentFacultate))
                {
                    cursuri.Add(_curs[i]);

                }
            }
            return cursuri;
        }
       public bool ModificareCurs( Course DeUpdate, String NumeMod,string studentFacult)
        {
            List<Course> cursmod = FiltrarecursByProfesie(studentFacult);
            for(int i = 0; i < cursmod.Count; i++)
            {
                if (NumeMod.Equals(cursmod[i])){


                    if(!DeUpdate.NameCurs.Equals(" "))
                    {
                        cursmod[i].NameCurs = DeUpdate.NameCurs;

                    }
                    if(!DeUpdate.Departament.Equals(" "))
                    {
                        cursmod[i].Departament = DeUpdate.Departament;


                    }
                    return true;
                }




            }
            return false;
        }
       





    }
}
