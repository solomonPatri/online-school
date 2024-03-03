using online_school.Courses.model;
using online_school.Student.model;
using online_school.Utile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
            Course c1 = new Course(10, "Analiza matematica", "Matematica",23);
            Course c2 = new Course(20, "Mecanica", "Inginerie",23);
            Course c3 = new Course(30, "Literatura sec XI", "Romana",18);
            Course c4 = new Course(40, "Algebra", "Matematica",24);
            Course c5 = new Course(50, "Stefan cel mare ", "Istorie",27);
            Course c6 = new Course(60, "Electronica", "Inginerie",24);
            Course c7 = new Course(70, "Anatomie ", "Medicina",27);

            _curs.Add(c1);
            _curs.Add(c2);
            _curs.Add(c3);
            _curs.Add(c4);
            _curs.Add(c5);
            _curs.Add(c6);
            _curs.Add(c7);

        }

        public void afisareCurs()
        {
            for (int i = 0; i < _curs.Count; i++)
            {
                Console.WriteLine(_curs[i].DescriereCurs());
            }
        }
        public List<Course> GetCursuri()
        {
            List<Course> cursuri = new List<Course>();
            for(int i =0; i < _curs.Count;i++)
            {
                cursuri.Add(_curs[i]);

            }
          return cursuri;

        }
        public bool deleteCurs(string namecurs)
        {
            List<Course> cursuri = _curs;
            for (int i = 0; i < cursuri.Count; i++)
            {
                if (cursuri[i].NameCurs.Equals(namecurs))
                {
                    this._curs.Remove(cursuri[i]);
                    return true;

                }

            }
            return false;
        }
        public bool DeleteCursByIdProfesor(string numecurs,int Idprof)
        {
            List<Course> cursuri = _curs;
            for(int i = 0; i < cursuri.Count; i++)
            {
                if (cursuri[i].Profesorid.Equals(Idprof))
                {
                    if (cursuri[i].NameCurs.Equals(numecurs))
                    {
                        _curs.Remove(cursuri[i]);
                        return true;
                    }
                }
            }
            return false;

        }
        public Course GetCourseById(int idcurs)
        {
            List<Course> curs = _curs;
            for (int i = 0; i < curs.Count; i++)
            {
                if (curs[i].Id == idcurs)
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
            while (GetCourseById(randomNumber) != null)
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
            for (int i = 0; i < _curs.Count - 1; i++)
            {
                for (int j = i + 1; j < _curs.Count; j++)
                {
                    if (_curs[i].Departament.CompareTo(_curs[j].Departament) > 0)
                    {

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
            for (int i = 0; i < curs.Count; i++)
            {
                Console.WriteLine(curs[i].DescriereCurs());


            }

            return curs;
        }

        public List<Course> FiltrarecursByProfesie(string studentFacultate)
        {
            List<Course> cursuri = new List<Course>();
            for (int i = 0; i < _curs.Count; i++)
            {
                if (_curs[i].Departament.Equals(studentFacultate))
                {
                    cursuri.Add(_curs[i]);

                }
            }
            return cursuri;
        }
        public bool ModificareCurs(Course DeUpdate, String NumeMod, string studentFacult)
        {
            List<Course> cursmod = FiltrarecursByProfesie(studentFacult);
            for (int i = 0; i < cursmod.Count; i++)
            {
                if (NumeMod.Equals(cursmod[i]))
                {


                    if (!DeUpdate.NameCurs.Equals(" "))
                    {
                        cursmod[i].NameCurs = DeUpdate.NameCurs;

                    }
                    if (!DeUpdate.Departament.Equals(" "))
                    {
                        cursmod[i].Departament = DeUpdate.Departament;


                    }
                    return true;
                }




            }
            return false;
        }
      







        //functie ce primeste ca parametru o lista id si returneaza toate cursurile cu id respectiv
        public List<Course> GetAllCourseByStudentCurs(List<int> Idcursuri)
        {
            List<Course> cursuri = new List<Course>();
            for (int i = 0; i < _curs.Count; i++)
            {

                if (Idcursuri.Contains(_curs[i].Id))
                {

                    cursuri.Add(_curs[i]);

                }

            }

            return cursuri;
        }
        public int FindCourseByName(string name)
        {
            for (int i = 0; i < _curs.Count; i++)
            {
                if (_curs[i].NameCurs.Equals(name))
                {
                    return _curs[i].Id;

                }

            }

            return 0;
        }

        public int GetCourseById()
        { 
            for(int i=0;i< _curs.Count; i++)
            {
                return _curs[i].Id;

            }
            return 0;



        }


        public void PopupateFreqWithCourse(List<FrecventaCurs> frecventaCurs)
        {

            foreach(var freqCourse in frecventaCurs)  // imi ia fiecare frecventa din lista
            {
               
                freqCourse.course = GetCourseById(freqCourse.corsId)  //imi da id-ul cursului in functia de ordine a frecventei
               //v = {30,20,40,10} // imi da direct cursurile afisate
;
            }
        }
        public List<int> GetCourseByProfId(int idprof)
        {
            List<int> cursuri = new List<int>();
            for(int i = 0; i < _curs.Count; i++)
            {
                if (_curs[i].Profesorid.Equals(idprof))
                {
                    cursuri.Add(_curs[i].Id);
                    
                }


            }
            return cursuri;
        }
        public List<Course> FindCourseByProf(int idprof)
        {
            List<Course> cursuri = new List<Course> ();
            for(int i = 0; i < _curs.Count; i++)
            {
                if (_curs[i].Profesorid.Equals(idprof))
                {
                    cursuri.Add(_curs[i]);
                }


            }
            return cursuri;

        }
        public void AfisareCursuriByProfId(int idProf)
        {
            List<Course> cursuri = new List<Course>();
            for(int i=0;i<_curs.Count;i++)
            {
                if (_curs[i].Profesorid.Equals(idProf))
                {
                    cursuri.Add(_curs[i]);
                    Console.WriteLine(cursuri[i].DescriereCurs());
                }
            }

        }
        public List<Course> GetCourseAllByProfId(int idprof)
        {
            List<Course> cursuri = new List<Course>();
            for (int i = 0; i < _curs.Count; i++)
            {
                if (_curs[i].Profesorid.Equals(idprof))
                {
                    cursuri.Add(_curs[i]);

                }


            }
            return cursuri;
        }
        public bool ModificareCursByProfesorId(Course modfCurs,String Nume,int Idprof)
        {
            List<Course> cursuri = GetCourseAllByProfId(Idprof);
            for(int i = 0; i < cursuri.Count; i++)
            {
                if (Nume.Equals(cursuri[i].NameCurs))
                {
                    if (!modfCurs.NameCurs.Equals(cursuri[i].NameCurs))
                    {
                        cursuri[i].NameCurs = modfCurs.NameCurs;
                    }
                    if (!modfCurs.Departament.Equals(cursuri[i].Departament))
                    {
                        cursuri[i].Departament = modfCurs.Departament;
                    }
                    return true;

                }
            }
            return false;
        }



    }
}
