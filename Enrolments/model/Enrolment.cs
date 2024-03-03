using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school.Enrolments.model
{
    public  class Enrolment
    {
        private int _id;
        private int _studentid;
        private int _CursId;
        


        public int Id
        {
            get { return _id; }
            set { _id = value; }

        }

        public int StudentId
        {
            get { return _studentid; }
            set { _studentid = value; }


        }
        public int CursId
        {
            get { return _CursId; }
            set { _CursId = value; }

        }
        
        public Enrolment(int IdEnr,int IdStudent,int CursId)
        {
            _id = IdEnr;
            _studentid = IdStudent;
            _CursId = CursId;
           

        }
        
        public Enrolment(int IdStudent,int CursId)
        {
            _studentid=IdStudent;
            _CursId = CursId;
           
        }
        public string DescriereEnrolment()
        {
            string desc = " ";
            desc += "IdEnrolment: " + this._id + "\n";
            desc += "IdStudent: " + this._studentid + "\n";
            desc += "IdCurs: " + this._CursId + "\n";
            
            return desc;
        }
        public string DescriereEnrolmentProf()
        {
            string desc = " ";
            desc += "IdEnrolment: " + this._id + "\n";
            desc += "IdCurs: " + this._CursId + "\n";

            return desc;
        }






    }
}
