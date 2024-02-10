using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_school.Books.model;
using online_school.Books.Services;
using online_school.Courses.model;
using online_school.Courses.service;
using online_school.Enrolment.Service;
using online_school.Student.model;
using online_school.Student.service;


namespace online_school.View
{
     public class View
    {
        private ServiceStudent _servicesStudent;
        private ServiceBook _serviceBook;
        private ServiceCourse _serviceCourse;
        private ServiceEnrolment _serviceEnrolment;
        private Students _studentul= new  Students(9, "Maria","Matematica","MarOrd42@yahoo.com",14," ");
        public View()
        {
            _serviceBook = new ServiceBook();
            _servicesStudent = new ServiceStudent();
            _serviceCourse = new ServiceCourse();
            _serviceEnrolment = new ServiceEnrolment();
            play();
        }

        public void meniu()
        {
            Console.WriteLine("1->Cursuri disponibile: ");
            Console.WriteLine("2->Studentii logati in Curs (Profesie): ");
            Console.WriteLine("3->Modificare curs:");
            Console.WriteLine("4->Cartiile a Studentului: ");
            Console.WriteLine("5-> Eliminare carte din curs: ");
            Console.WriteLine("6-> Adaugare student.");


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
                        AfisareCursDisp(); //Merge
                        break;
                    case 2:
                        NrStudentiInCurs();
                        break;

                    case 3:
                        ModificareCurs();
                        break;
                        case 4:
                        CartiiStudent(); // Merge
                        break;
                        case 5:
                        DeleteBook();
                        break;
                        case 6:
                        adaugareStudent();// merge
                        break;


                }




            }
        }
    
        public void AfisareCursDisp()
        {
            Console.WriteLine("Cursurile disponibile sunt: " + "\n");
            _serviceCourse.sortareAlfaCourse();
            Console.WriteLine(_serviceCourse.AfisareListaCourse());

        }
        public void NrStudentiInCurs()
        {
            Console.WriteLine("Introduceti departamentul cursului: ");
            string profesie = Console.ReadLine();
            int im = 0;
            List<Course> curs = _serviceCourse.AfisareListaCourse();
            List<Students> studentii = _servicesStudent.AfisareListaStudenti();
            for(int i = 0; i < curs.Count; i++)
            {
                if (curs[i].Departament.Equals(profesie))
                {
                    Console.WriteLine(curs[i].DescriereCurs());
                    
                   
                }
            }
            Console.WriteLine("In total sunt logati " + im + " Studenti." + "\n");
            
        }//studenti  logati in curs
        
        public void CartiiStudent()
        {
            Console.WriteLine("Studentul: "+"\n"+_studentul.DescriereStudent());
            Console.WriteLine("Are urmatoarele Carti: ");
            List<Book> books = _serviceBook.BooksLista(this._studentul.Id);

        }
        public void adaugareStudent()
        {
            Console.WriteLine("Introduceti numele:");
            string name = Console.ReadLine();
            Console.WriteLine("Introduceti Facultatea: ");
            string Fac = Console.ReadLine();
            Console.WriteLine("Introduceti gmail: ");
            string email= Console.ReadLine();
            Console.WriteLine("Introduceti varsta: ");
            int age= int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti parola: ");
            string passw = Console.ReadLine();
            
            Students newstudent = new Students(_servicesStudent.GenerateStudentId(),name,Fac,email,age,passw);
            newstudent.FirstnameStudent = name;
            newstudent.Facultate = Fac;
            newstudent.Email = email;
            newstudent.Age = age;
            newstudent.Password = passw;
            _servicesStudent.adaugareStudent(newstudent);
            

            Console.WriteLine("S-a adaugat cu succes.");
            Console.WriteLine("Acuma lista este: ");
            _servicesStudent.afisarestudent();
        }
       
       public void ModificareCurs()//imi da eroare Posibill sa fii pus gresit functia
        {
            Console.WriteLine("Introducetii Numele Cursului care doriti sa modificatii: ");
            string namecurs = Console.ReadLine();
            Console.WriteLine("Introduceti noul nume de curs:");
             string newnamecurs = Console.ReadLine();
            Console.WriteLine("Introduceti Departamentul a cursului: ");
            string newDep = Console.ReadLine();

            Course editedCurs = new Course(newnamecurs, newDep);
            bool response = _serviceCourse.ModificareCurs(editedCurs, namecurs,this._studentul.Facultate);
            if(response == true)
            {
                Console.WriteLine("Cursul a fost modificat");

            }
            else
            {
                Console.WriteLine("Eroare date invalide.");
            }




        }

        public void DeleteBook()
        {
            Console.WriteLine("Introduceti Cartea care doriti sa stergeti:");
            string titlul = Console.ReadLine();
            _serviceBook.deleteBook(titlul, this._studentul.Id);
            bool response = true;
            if(response == true)
            {
                Console.WriteLine("Cartea a fost stearsa cu succes."+"\n");
                Console.WriteLine("Acuma lista de carti este: ");
                _serviceBook.afisareBook();
            }
            else
            {
                Console.WriteLine("A aparut o eroare");
            }
        }







    }
}
