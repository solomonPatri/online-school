using online_school;
using online_school.Books.model;
using online_school.Books.Services;
using online_school.Courses.model;
using online_school.Courses.service;
using online_school.Student.model;
using online_school.Student.service;
internal class Program
{
    private static void Main(string[] args)
    {
        ServiceStudent servicestudent = new ServiceStudent();

        servicestudent.afisarestudent();
        //Students newstudent = new Students(servicestudent.GenerateStudentId(),"Adrian","Iancu","342bfg@gmail.com",45);
        //servicestudent.adaugareStudent(newstudent);
        servicestudent.DeleteStudent(2, "Ana");
        servicestudent.afisarestudent();

        



    }




}