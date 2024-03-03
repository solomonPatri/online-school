using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_school.Profesorii.service;
using online_school.Profesorii.model;
using online_school.Enrolments.Service;
using online_school.Courses.service;
using System.Diagnostics;
using online_school.Student.service;
using System.Security.Cryptography.X509Certificates;
using online_school.Enrolments.model;
using online_school.Student.model;
using online_school.Courses.model;

namespace online_school.View4
{
    internal class ViewProfesor
    {
        private ServiceEnrolment _serviceenrol;
        private Profesor _prof;
        private ServiceCourse _servicecurs;
        private ServiceStudent _servicestudenti;
        private ServiceProfesor _serviceprof;

        public ViewProfesor()
        {
            _serviceprof = new ServiceProfesor();
            _serviceenrol = new ServiceEnrolment();
            _servicecurs = new ServiceCourse();
            _prof = new Profesor(23, "Grigore", 4987, "Inginerie", "grigoretiple @gmail.com", " ");
            _servicestudenti = new ServiceStudent();
            play();
        }
        public void meniu()
        {

            Console.WriteLine("1-> Afisare Cursuri predate");
            Console.WriteLine("2-> Studentii care le preda:");
            Console.WriteLine("3->Cursul cu cei mai multi studenti inscris");
            Console.WriteLine("4->Media studentiilor din curs");
            Console.WriteLine("5->Stergerea Curs:");
            Console.WriteLine("6->Adaugare Curs:");
            Console.WriteLine("7->Modificare curs:");

            //todo: 10 functionalitati





        }
        public void play()
        {
            bool run = true;
            while (run)
            {
                meniu();
                int nrales = int.Parse(Console.ReadLine());
                switch (nrales)
                {

                    case 1:
                        afisareCursuriProf();
                        break;
                    case 2:
                        StudentiByProfesor();
                        break;
                    case 3:
                        CursProfesorMaxStudenti();
                        break;
                    case 4:
                       MediaStudentilor();
                        break;
                    case 5:
                        stergereCurs();
                        break;
                    case 6:
                        AdaugareCursByProf();
                        break;
                    case 7:
                        ModificareCurs();
                        break;


                }


            }




        }

        public void afisareCursuriProf()
        {
            Console.WriteLine("Cursuriile care preda " + _prof.Nume + " sunt: " + "\n");
            var list = _servicecurs.FindCourseByProf(_prof.IdProfesor);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].DescriereCurs());

            }


        }
        public void StudentiByProfesor()
        {
            Console.WriteLine("Studentii care ii are Profesorul " + _prof.Nume + " sunt: " + "\n");
            List<int> idiuri = _servicecurs.GetCourseByProfId(23);
            List<int> idStudent = _serviceenrol.GetAllStudentIdByCursId(idiuri);
            List<Students> courses = _servicestudenti.AfisareListaStudenti(idStudent);
            for (int z = 0; z < courses.Count; z++)
            {
                Console.WriteLine(courses[z].DescriereStudent());
            }
        }
        public void CursProfesorMaxStudenti()
        {
            List<Course> cursurile = _servicecurs.GetCursuri();
            Console.WriteLine("Cursurile care are profesorul sunt: " + "\n");
            List<int> idiuri = _servicecurs.GetCourseByProfId(23);
            for (int i = 0; i < idiuri.Count; i++)
            {
                if (cursurile[i].Id.Equals(idiuri[i]))
                {

                    Console.WriteLine(cursurile[i].DescriereCurs());
                }
            }
        }

        public void MediaStudentilor()
        { 
            List<int> idiuri = _servicecurs.GetCourseByProfId(_prof.IdProfesor);
            List<int> idStudent = _serviceenrol.GetAllStudentIdByCursId(idiuri);
            List<Students> courses = _servicestudenti.AfisareListaStudenti(idStudent);
            float suma = 0;
            for(int i=0;i<courses.Count;i++)
            { 
                suma += courses[i].Media;
            }
            Console.WriteLine("Studenti din curs au media: ");
            Console.WriteLine(suma / courses.Count);
          
        }

        public void AdaugareCursByProf()
        {
            Console.WriteLine("Introduceti datele cursului: " + "\n");
            Console.WriteLine("Numele: ");
            string nameCurs = Console.ReadLine();
            Console.WriteLine("Departament: ");
            string departament = Console.ReadLine();

            Course newcurs = new Course(_servicecurs.GenerateIdUniqueCurs(), nameCurs, departament, _prof.IdProfesor);
            _servicecurs.adaugareCurs(newcurs);
            Console.WriteLine("Acum cursuri disponibile sunt: " + "\n");
            _servicecurs.AfisareListaCourse();



        }
        public void stergereCurs()
        {
            Console.WriteLine("Introduceti numele Cursul  care doriti sa stergeti: ");
            string nume = Console.ReadLine();

            bool verf = _servicecurs.DeleteCursByIdProfesor(nume,_prof.IdProfesor);
            if (verf)
            {
                Console.WriteLine("Cursul a fost sters");
                _servicecurs.AfisareCursuriByProfId(_prof.IdProfesor);
            }
            else
            {
                Console.WriteLine("Nu exista acest Curs in lista.");
            }
        }

        public void ModificareCurs()
        {
            Console.WriteLine("Introduceti numele Cursului care doriti sa modificati:");
            string numecurs = Console.ReadLine();
            Console.WriteLine("Introduceti noul nume: ");
            string newnume = Console.ReadLine();
            Console.WriteLine("Introduceti noul nume departament:");
            string departament = Console.ReadLine() ;
            Course modfCurs = new Course(0,newnume,departament,_prof.IdProfesor);
            bool verificare = _servicecurs.ModificareCursByProfesorId(modfCurs,numecurs,_prof.IdProfesor);
             if (verificare)
            {
                Console.WriteLine("A fost modificat cu succes." + "\n");
                Console.WriteLine("Acum lista este ");
                _servicecurs.AfisareCursuriByProfId(_prof.IdProfesor);

            }
            else
            {
                Console.WriteLine("Cursul nu poate fi modificat");
            }


        }




    }

}
    

