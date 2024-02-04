using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_school.Student.model;

namespace online_school.Student.service
{
    public class ServiceStudent
    {
        private List<Students> _student;

        public ServiceStudent()
        {

            _student = new List<Students>();
            this.load();
        }

        public void load()
        {
            Students s1 = new Students(GenerateStudentId(),"Mario","Solomon","solomonmario@gmail.com",18);
            Students s2 = new Students(GenerateStudentId(), "Ana", "Mihaciu", "MihaAna@yahoo.com", 23);
            Students s3 = new Students(GenerateStudentId(),"Silviu","Dancanet","silviu32@gmail.com",22);
            Students s4 = new Students(GenerateStudentId(), "Magda", "Mustantean", "MMagdalena34@yahoo.com", 17);

            _student.Add(s1);
            _student.Add(s2);
            _student.Add(s3);
            _student.Add(s4);
        }
        public int GenerateStudentId()
        {
            Random random = new Random();
            int randomnumber = random.Next(1, 100001);
            while (randomnumber != null)
            {
                randomnumber = random.Next(1, 100001);

            }

            return randomnumber;

        }
        public void afisarestudent()
        {
            for(int i=0;i< _student.Count;i++)
            {
                Console.WriteLine(_student[i].DescriereStudent());


            }


        }
        public bool adaugarestudent(Students student)
        {
            List<Students> students = _student;

            for(int i=0;i< students.Count;i++)
            {
                if (students[i] != student)
                {
                    students.Add(student);
                    return true;
                }

            }
            return false;

        }
        public bool deleteStudent(string name)
        {
            List<Students> students = _student;
            for(int i=0;i< students.Count; i++)
            {
                if (name.Equals(students[i].FirstnameStudent))
                {
                    this._student.Remove(students[i]);
                    return true;
                }
            }
            return false;

        }










    }
}
