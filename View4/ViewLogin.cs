using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_school.Student.service;
using online_school.Profesorii.service;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using online_school.Student.model;
using online_school.Profesorii.model;

namespace online_school.View4
{
    internal class ViewLogin
    {
       
        private ServiceProfesor _serviceProfesor;
        private ServiceStudent _serviceStudent;

        public ViewLogin()
        {
            _serviceProfesor = new ServiceProfesor();   
            _serviceStudent = new ServiceStudent();
            play();
        }

        public void meniu()
        {
            
            Console.WriteLine("1->Log in");
            Console.WriteLine("2->Sign in");

        }
        public void play()
        {
            bool run = true;
            while (run)
            {
                meniu();
                int nrales = int .Parse(Console.ReadLine());
                switch(nrales)
                {
                    case 1:
                        AfisareLogin();
                        break;
                    case 2:
                        Console.WriteLine("1-> Profesor?");
                        Console.WriteLine("2-> Student? ");
                        int ProfStu = int.Parse(Console.ReadLine());
                        switch (ProfStu)
                        {
                            case 1:
                                InscriereProfesor();
                                break;
                            case 2:

                                break;

                        }

                        break;


                }


            }
            
        }
        public void AfisareLogin()
        {
            Console.WriteLine("Email: " + "\n");
            string Email = Console.ReadLine();
            Console.WriteLine("Password: " + "\n");
            string Password = Console.ReadLine();
            Students student = _serviceStudent.GetStudentByLogin(Email, Password);
            Profesor profesor = _serviceProfesor.GetProfByLogin(Email, Password);


            if (student != null)
            {
                ViewStudent viewStudent = new ViewStudent(student);
                viewStudent.Play();
            }
            else if (profesor != null)
            {
                ViewProfesor viewProfesor = new ViewProfesor(profesor);
                viewProfesor.play();
            }
            else
            {
                Console.WriteLine("Credentialele sunt invalide");
            }

        }
        public void InscriereProfesor()
        {
            Console.WriteLine("Email: ");
            string Email = Console.ReadLine();
            Console.WriteLine("Passwod: ");
            string Passsword = Console.ReadLine();
            Console.WriteLine("Numele: ");
            string nume = Console.ReadLine();
            Console.WriteLine("Numarul de studenti: ");
            int nrstud = int.Parse(Console.ReadLine());
            Console.WriteLine("Facultate: ");
            string facultate = Console.ReadLine();
            Profesor newProf = new Profesor(_serviceProfesor.GenerateProfesorId(), nume, nrstud, facultate, Email, Passsword);
            bool ver = false;
            if (ver)
            {
                Console.WriteLine("Deja exista un profesor ,Incercati din nou");
            }
            else
            {
                _serviceProfesor.adaugareProf(newProf);
            }

        }




    }
}
