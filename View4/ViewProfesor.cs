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
        private Profesor _prof2;
        private ServiceCourse _servicecurs;
        private ServiceStudent _servicestudenti;
        private ServiceProfesor _serviceprof;

        public ViewProfesor()
        {
            _serviceprof = new ServiceProfesor();
            _serviceenrol = new ServiceEnrolment();
            _servicecurs = new ServiceCourse();
            _prof = new Profesor(23, "Grigore", 4987, "Inginerie", "grigoretiple @gmail.com"," ");
            _prof2 = new Profesor(24, "Eduard", 3456, "Inginerie", "eduardtdr@gmail.es", " ");
            _servicestudenti = new ServiceStudent();
            play();
        }
        public void  meniu()
        {
   
            Console.WriteLine("1-> Afisare Cursuri predate");
            Console.WriteLine("2-> Studentii care le preda:");
            Console.WriteLine("3->Cursul Profesorului Cu cei mai multi studenti");
            Console.WriteLine("4->Cea mai mare medie a studentilor a cei doi profesori");
            Console.WriteLine("5->Stergerea profesor:");
            Console.WriteLine("6->Adaugare profesor:");

            //todo: 10 functionalitati

            



        }
        public void play()
        {
            bool run = true;
            while (run)
            {
                meniu();
                int nrales = int.Parse(Console.ReadLine());
                switch(nrales)
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
                        MediaCelorDoiProfesori();
                        break;
                    case 5:
                        stergereProfesor();
                        break;
                    case 6:
                        AdaugareProfesor();
                        break;
                    case 7:
                       
                        break;


                }


            }




        }
        
        public void afisareCursuriProf()
        {
            Console.WriteLine("Cursuriile care preda " + _prof.Nume + " sunt: " + "\n");
            var list = _servicecurs.FindCourseByProf(_prof.IdProfesor);
            for(int i =0;i< list.Count; i++)
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
            Console.WriteLine("Cursurile care are profesorul sunt: "+"\n");
              List<int> idiuri = _servicecurs.GetCourseByProfId(23);
            for(int i = 0; i < idiuri.Count; i++)
            {   
                if (cursurile[i].Id.Equals(idiuri[i]))
                {
                    
                    Console.WriteLine(cursurile[i].DescriereCurs());
                }

            }




        }

        public void MediaCelorDoiProfesori()
        {
            List<int> idprof1 = _servicecurs.GetCourseByProfId(_prof.IdProfesor);
            List<int> idprof2 = _servicecurs.GetCourseByProfId(_prof2.IdProfesor);
            List<int> idstud1 = _serviceenrol.GetAllStudentIdByCursId(idprof1);
            List<int> idstud2 = _serviceenrol.GetAllStudentIdByCursId(idprof2);
            int mediastudprof1 = _servicestudenti.mediaStudentilor(idstud1);
            int mediastudprof2 = _servicestudenti.mediaStudentilor(idstud2);
            int maxmedia = 0;
            if(mediastudprof1> mediastudprof2)
            {
                maxmedia = mediastudprof1;
            }
            else
            {
                maxmedia = mediastudprof2;
            }

            Console.WriteLine("Profesorul cu media cea mai mare la studenti este: " + maxmedia);




        }













        public void AdaugareProfesor()
        {
            Console.WriteLine("Adaugati datele nului profesor" + "\n");
            Console.WriteLine("Nume:" + "\n");
            string nume = Console.ReadLine();
            Console.WriteLine("nr de studenti :"+"\n");
            int nrstud = int.Parse(Console.ReadLine());
            Console.WriteLine("Facultate: "+"\n");
            string fac = Console.ReadLine();
            Console.WriteLine("email: " + "\n");
            string email = Console.ReadLine();
            Console.WriteLine("Parola: ");
            string parola = Console.ReadLine();
            
            Profesor newprof = new Profesor(_serviceprof.GenerateProfesorId(),nume,nrstud,fac,email,parola);
            _serviceprof.adaugareProf(newprof);
            _serviceprof.afisare();

        }
        public void stergereProfesor()
        {
            Console.WriteLine("Introduceti numele profesorului care doriti sa stergeti: " + "\n");
            string nume = Console.ReadLine();

            bool verf = _serviceprof.DeleteProf(nume);
            if(verf = true)
            {
                Console.WriteLine("Profesorul a fost sters");
                _serviceprof.afisare();
            }
            else
            {
                Console.WriteLine("Nu exista acest profesor in lista.");
            }

        }

        





    }
}
