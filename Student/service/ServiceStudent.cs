using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_school.Enrolments.model;
using online_school.Enrolments.Service;
using online_school.Student.model;

namespace online_school.Student.service
{
    public class ServiceStudent
    {
        private List<Students> _student;
        private ServiceEnrolment _serviceenrolment;

        public ServiceStudent()
        {
            _serviceenrolment = new ServiceEnrolment();
            _student = new List<Students>();
            this.load();
        }

        public void load()
        {
            Students s1 = new Students(1,"Mario","Solomon","Matematica","solomonmario@gmail.com",18," ",7);
            Students s2 = new Students(2, "Ana","Ardelean", "Inginerie", "MihaAna@yahoo.com", 23," ",3);
            Students s3 = new Students(3,"Silviu","Dancanet","Informatica","silviu32@gmail.com",22, " ",5);
            Students s4 = new Students(4, "Magda","Mustatean ","Literatura", "MMagdalena34@yahoo.com", 17, " ",9);

            _student.Add(s1);
            _student.Add(s2);
            _student.Add(s3);
            _student.Add(s4);
        }
        
        public void afisarestudent()
        {
            for(int i=0;i< _student.Count;i++)
            {
                Console.WriteLine(_student[i].DescriereStudent());
            }

        }
        public Students GetStudentsById(int idstudent)
        {
            List<Students> students = _student;
            for(int i=0;i< students.Count;i++)
            {
                if (students[i].Id == idstudent)
                {
                    return students[i];
                }

            }
            return null;
        }
        public int GenerateStudentId()
        {
            Random random = new Random();
            int randomnumber = random.Next(10, 10001);
            while(GetStudentsById(randomnumber) != null)
            {

                randomnumber = random.Next(10, 10001);

            }
            return randomnumber;

        }
        public void adaugareStudent(Students newstudent)
        {
            newstudent.Id = GenerateStudentId();
            this._student.Add(newstudent);

        }
        public bool DeleteStudent(int Idstudent,string Firstname)
        {
            List<Students> student = _student;
            for(int i=0;i< student.Count;i++)
            {
                if (student[i].Id == Idstudent && student[i].FirstnameStudent.Equals(Firstname))
                {

                    this._student.Remove(student[i]);
                    return true;
                }
            }
            return false;
        }


        public List<Students> AfisareListaStudenti(List<int> studentids)
        {
           
            List<Students> studenti = new List<Students>();
            for (int i = 0; i < _student.Count; i++)
            {
                if (studentids.Contains(_student[i].Id))
                {
                    studenti.Add(_student[i]);
                }
            }
            return studenti;
            
        }
        public int mediaStudentilor(List<int> idstudenti)
        {
            int suma = 0;
            int media = 0;
            List<int> v = idstudenti;
            for(int i=0;i<_student.Count;i++) {

                if (v[i].Equals(_student[i].Id))
                {
                    suma += _student[i].Media;
                    return suma / v[i];

                }
              
            }
            return 0;
        }
        












    }
}
