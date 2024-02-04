using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school.Enrolment.model
{
    public  class Enrolment
    {
        private int _studentid;
        private int _CursId;




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



    }
}
