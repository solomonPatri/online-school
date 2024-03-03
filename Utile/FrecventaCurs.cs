using online_school.Courses.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school.Utile
{
    public class FrecventaCurs
    {
        public int corsId;   // id cursului ex:30
        public int corsFreq; // nr de ori care este inscris  ex:3
        public Course course; // cursul cu toate datele


        public string Info()
        {
            string text = "";
            text += "Cursul " + course.NameCurs + " are " + this.corsFreq + " participamti";
            return text;
        }
    }
}
