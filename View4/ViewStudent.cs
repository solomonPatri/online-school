using online_school.Student.model;
using online_school.Student.service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_school.Enrolments.Service;
using online_school.Courses.service;
using online_school.Courses.model;
using online_school.Enrolments.model;
using online_school.Utile;

namespace online_school.View4
{
    internal class ViewStudent
    {

        private ServiceEnrolment _serviceenrol;
        private Students _student;
        private ServiceCourse _servicecourse;


        // books
        //
        // cursuri
        //--> sa se afiseze cursurile disponibile   //1
        //-->sa se inscrie la un curs // 3
        //-->sa se sterga de un curs // 4
        //--> sa verifice cursurile la care este inscris //2
        //-->Afisarea cursul cel mai popular //5
        //Afisare cursuru in functie de popular//6

        public ViewStudent()
        {
            _serviceenrol = new ServiceEnrolment();
            _servicecourse = new ServiceCourse();
            _student = new Students(19, "Florin", "Dancanet", "Mecatronica", "dhfgr@33.yahoo", 25, "RED");
        }
        public void meniu()
        {
            Console.WriteLine("1-> Afisarea cursuri: ");
            Console.WriteLine("2-> Afisarea Cursurile studentului:");
            Console.WriteLine("3->Inscrierea unui curs: ");
            Console.WriteLine("4-> Introduceti cursul care doriti sa-l stergeti: ");
            Console.WriteLine("5->Afisare Curs popular: ");
            Console.WriteLine("6->Afisare toate cursuriile in functie de popular:");


        }
        public void Play()
        {
            bool run = true;
            while (run)
            {
                meniu();
                int nrales = int.Parse(Console.ReadLine());
                switch (nrales)
                {
                    case 1:
                        afisareCursuri();
                        break;
                    case 2:
                        AfisareCursInscris();
                        break;
                    case 3:
                        InscriereStudentCurs();
                        break;
                    case 4:
                        StergereaCursInscris();
                        break;
                    case 5:
                        AfisareCursPopular();
                        break;
                    case 6:
                        AfisareToateCursuriId();
                        break;

                }



            }


        }
        public void afisareCursuri()
        {
            Console.WriteLine("Cursurile Disponibile sunt: " + "\n");
            _servicecourse.afisareCurs();


        }
        public void AfisareCursInscris()
        {
            Console.WriteLine("Cursurile Studentului " + _student.FirstnameStudent + " sunt: " + "\n");

            var list = _serviceenrol.GetAllEnrolByStudentId(_student.Id);
            var listc = _servicecourse.GetAllCourseByStudentCurs(list);

            for (var x = 0; x < listc.Count; x++)
            {
                Console.WriteLine(listc[x].DescriereCurs());
            }
        }

        public void InscriereStudentCurs()
        {
            Console.WriteLine("Introduceti cursul care doriti sa va inscrieti:");
            string newcourse = Console.ReadLine();

            int idCurs = _servicecourse.FindCourseByName(newcourse);
            //todo


            bool verificarea = _serviceenrol.GetEnrolByCursId(_student.Id, idCurs);

            if (verificarea == true)
            {

                Enrolment newEnrol = new Enrolment(_serviceenrol.GenerateIdUnique(), _student.Id, idCurs);
                _serviceenrol.adaugareEnrol(newEnrol);
                var list = _serviceenrol.GetAllEnrolByStudentId(_student.Id);

                var listcurs = _servicecourse.GetAllCourseByStudentCurs(list);

                Console.WriteLine("Cursuriile care studentul este inscris:");

                for (int i = 0; i < listcurs.Count; i++)
                {
                    Console.WriteLine(listcurs[i].DescriereCurs());

                }

            }
            else
            {

                Console.WriteLine("Deja este inscris studentul la acest curs.");
            }

        }
        public void StergereaCursInscris()
        {
            Console.WriteLine("Introduceti cursul care doriti sa va stergeti: ");
            string numecurs = Console.ReadLine();


            int idCurs = _servicecourse.FindCourseByName(numecurs);



            bool verificare = _serviceenrol.GetEnrolByCursId(_student.Id, idCurs);

            if (verificare = false)
            {
                Console.WriteLine("Nu exista acest curs.");
            }
            else
            {
                _serviceenrol.DeleteEnrolment(_student.Id, idCurs);
                var list = _serviceenrol.GetAllEnrolByStudentId(_student.Id);
                var listcurs = _servicecourse.GetAllCourseByStudentCurs(list);

                Console.WriteLine("Lista de cursuri a studentului dupa stergere este: " + "\n");
                for (int i = 0; i < listcurs.Count; i++)
                {
                    Console.WriteLine(listcurs[i].DescriereCurs());
                }
            }
        }

        public void AfisareCursPopular()
        {
            Console.WriteLine("Cursul cel mai popular este: " + "\n");
            int idCourse = _serviceenrol.FindMosPopularCourse();
            Course curspop = _servicecourse.GetCourseById(idCourse);
            Console.WriteLine(curspop.DescriereCurs());

        }
        public void AfisareToateCursuriId()
        {
            List<FrecventaCurs> frecventaCurs = _serviceenrol.FrecventaCursuriSortate();
            _servicecourse.PopupateFreqWithCourse(frecventaCurs);
            foreach(var freq in frecventaCurs)
            {
                Console.WriteLine(freq.Info());
            }
        }


    }
}
