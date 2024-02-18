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
        public int corsId;
        public int corsFreq;
        public Course course;


        public string Info()
        {
            string text = "";
            text += "Cursul " + course.NameCurs + " are " + this.corsFreq + " participamti";
            return text;
        }
    }
}
