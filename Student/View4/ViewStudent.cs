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

namespace online_school.Student.View4
{
    internal class ViewStudent
    {


        private Students _student;
        private ServiceCourse _servicecourse;
        // books
        //
        // cursuri
        //--> sa se afiseze cursurile disponibile   //1
        //-->sa se inscrie la un curs // 3
        //-->sa se sterga de un curs // 4
        //--> sa verifice cursurile la care este inscris //2

        public ViewStudent()
        {
           _servicecourse = new ServiceCourse();
            _student= new Students(19,"Florin","Dancanet","Mecatronica","dhfgr@33.yahoo",25,"RED");
        }
        public void meniu()
        {
            Console.WriteLine("1-> Afisarea cursuri: ");
            Console.WriteLine("2-> Afisarea Cursurile studentului:");
            Console.WriteLine("3->Inscrierea unui curs: ");
            Console.WriteLine("4-> Introduceti cursul care doriti sa-l stergeti: ");

        }
        public void Play()
        {
            bool run = true;
            while (run)
            {
                meniu();
                int nrales = int.Parse(Console.ReadLine());
                switch(nrales)
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


                }



            }


        }
         public void afisareCursuri()
        { 
            Console.WriteLine("Cursurile Disponibile sunt: "+"\n");
             _servicecourse.afisareCurs();
            

        }
       public void AfisareCursInscris()
        {
            Console.WriteLine("Cursurile Studentului " + _student.FirstnameStudent + " sunt: " + "\n");
            ServiceEnrolment e = new ServiceEnrolment();
            ServiceCourse c = new ServiceCourse();

            var list = e.GetAllEnrolByStudentId(this._student.Id);
            var listc = c.GetAllCourseByStudentCurs(list);

            for (var x = 0; x < listc.Count; x++)
            {
                Console.WriteLine(listc[x].DescriereCurs());
            }
        }

        public void InscriereStudentCurs()
        {
            Console.WriteLine("Introduceti cursul care doriti sa va inscrieti:");
            string newcourse = Console.ReadLine();
            ServiceCourse cursuri = new ServiceCourse();
            int idCurs = cursuri.FiltrareCursIdByName(newcourse);

            ServiceEnrolment enrolment = new ServiceEnrolment();

            
            bool verificarea = enrolment.GetEnrolByCursId(this._student.Id, idCurs);
            
            if( verificarea == true) {
                 
               Enrolment newEnrol = new Enrolment(enrolment.GenerateIdUnique(), this._student.Id, idCurs);
               enrolment.adaugareEnrol(newEnrol);
               var list = enrolment.GetAllEnrolByStudentId(this._student.Id);

                var listcurs = cursuri.GetAllCourseByStudentCurs(list);

              Console.WriteLine("Cursuriile care studentul este inscris:");

                for(int i=0;i< listcurs.Count; i++)
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

            ServiceCourse curs = new ServiceCourse();
            int idCurs = curs.FiltrareCursIdByName(numecurs);

            ServiceEnrolment enrol = new ServiceEnrolment();

            bool verificare = enrol.GetEnrolByCursId(this._student.Id,idCurs);

            if (verificare = false)
            {
                Console.WriteLine("Nu exista acest curs.");
            }
            else
            {   enrol.DeleteEnrolment(this._student.Id, idCurs);
                var list = enrol.GetAllEnrolByStudentId(this._student.Id);
                var listcurs = curs.GetAllCourseByStudentCurs(list);
                
                Console.WriteLine("Lista de cursuri a studentului dupa stergere este: " + "\n");
                for(int i=0;i<listcurs.Count;i++)
                {
                    Console.WriteLine(listcurs[i].DescriereCurs());
                } 
            }          
        






        }

    }
}
