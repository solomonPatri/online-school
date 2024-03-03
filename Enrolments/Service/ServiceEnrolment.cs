using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_school.Courses.model;
using online_school.Enrolments.model;
using online_school.Student.model;
using online_school.Utile;

namespace online_school.Enrolments.Service
{
    public class ServiceEnrolment
    {
        private List<Enrolment> _enrolment;

        public ServiceEnrolment() {

            _enrolment = new List<Enrolment>();
            load();




        }
        public void load()
        {
            Enrolment e1 = new Enrolment(GenerateIdUnique(), 1, 10);
            Enrolment e2 = new Enrolment(GenerateIdUnique(), 2, 10);
            Enrolment e3 = new Enrolment(GenerateIdUnique(), 4, 60);
            Enrolment e4 = new Enrolment(GenerateIdUnique(), 2, 60);
            Enrolment e5 = new Enrolment(GenerateIdUnique(), 4,40);
            Enrolment e6 = new Enrolment(GenerateIdUnique(), 4, 20);
            Enrolment e7 = new Enrolment(GenerateIdUnique(), 3, 20);
            Enrolment e8 = new Enrolment(GenerateIdUnique(), 4, 50);
            

            _enrolment.Add(e1);
            _enrolment.Add(e2);
            _enrolment.Add(e3);
            _enrolment.Add(e4);
            _enrolment.Add(e5);
            _enrolment.Add(e6);
            _enrolment.Add(e7);
            _enrolment.Add(e8);

        }
        public void afisareEnrol()
        {
            for (int i = 0; i < _enrolment.Count; i++)
            {
                Console.WriteLine(_enrolment[i].DescriereEnrolment());

            }
        }
        public Enrolment GetEnrolmentById(int id)
        {
            List<Enrolment> enrol = _enrolment;
            for (int i = 0; i < enrol.Count; i++)
            {
                if (enrol[i].Id == id)
                {
                    return enrol[i];

                }
            }
            return null;
        }
        public int GenerateIdUnique()
        {
            Random rand = new Random();
            int random = rand.Next(10, 10000);

            while (GetEnrolmentById(random) != null)
            {
                random = rand.Next(10, 10000);
            }
            return random;


        }
        public void adaugareEnrol(Enrolment enrolnew)
        {
            enrolnew.Id = this.GenerateIdUnique();
            this._enrolment.Add(enrolnew);

        }

        public bool DeleteEnrolById(int idEnr)
        {
            List<Enrolment> enrolment = _enrolment;
            for (int i = 0; i < enrolment.Count; i++)
            {
                if (idEnr.Equals(enrolment[i].Id))
                {
                    this._enrolment.Remove(enrolment[i]);
                    return true;
                }


            }
            return false;


        }
        //todo: functie ce returneaza toate enrolurile studentului byStundet
        public List<int> GetAllEnrolByStudentId(int studentId)
        {
            List<int> enrol = new List<int>();
            for (int i = 0; i < _enrolment.Count; i++)
            {
                if (studentId == _enrolment[i].StudentId)
                {
                    enrol.Add(_enrolment[i].CursId);

                }


            }
            return enrol;

        }
        public List<int> GetAllStudentIdByCursId(List <int> idCursuri) {
        
            List<int> idstudenti = new List<int>();
            for(int i = 0; i < _enrolment.Count; i++)
            {

                if (idCursuri.Contains(_enrolment[i].CursId) && !idstudenti.Contains(_enrolment[i].StudentId))//sa nu ii repetam acelasi idstudenti doar o singura data
                {

                    idstudenti.Add(_enrolment[i].StudentId);
                }

            }
          return idstudenti;
        }
        
        public bool GetEnrolByCursId(int studentId, int cursId)
        {
            for (int i = 0; i < _enrolment.Count; i++)
            {
                if (_enrolment[i].StudentId.Equals(studentId) && _enrolment[i].CursId.Equals(cursId)) {

                    return false;
                }
            }
            return true;

        }
        
        public void DeleteEnrolment(int studentid,int cursId)
        {
            for(int i =0;i<_enrolment.Count;i++)
            {
                if (_enrolment[i].StudentId.Equals(studentid) && _enrolment[i].CursId.Equals(cursId))
                {
                    _enrolment.Remove(_enrolment[i]);
                }
            }
        }
        private  int[] Frecventa()
        {
            int[] v = new int[1000];  // v[8]={10,30,30,30,20,20,40,40}

           for(int i = 0; i < _enrolment.Count; i++)   // i=0 la i=7
            {
                v[_enrolment[i].CursId]++;  // v[10]={1} , v[30] = {3}, v[20]={2},v[40]={2}
            }

           return v; // v [4] = {1,3,2,2}

        }
       
        private int FrecventaCursUnic(int idcurs)
        {
            int[] v = new int[100];
            for(int i = 0; i < _enrolment.Count; i++)
            {
                if (idcurs.Equals(_enrolment[i].CursId))
                {
                    v[_enrolment[i].CursId]++;
                    int nr = v[i];
                    return nr;
                }
                
            }
            return 0;

        }
         public List<FrecventaCurs> FrecventaCursuriSortate()
        {

            int[] freq = Frecventa();     //nr de frecvente v = {1,3,2,2}
            List<FrecventaCurs> frecventaCurs = new List<FrecventaCurs>();
            for(int i=1;i<freq.Length;i++)  //i=1 la i=4
            {
                if (freq[i] != 0)  //  sa se repete cel putin odata
                {
                    FrecventaCurs frecventa = new FrecventaCurs();  // cream si ii alocam datele
                    frecventa.corsId = i; //pozitia vector este id din freq v = {1,2,3,4}
                    frecventa.corsFreq = freq[i]; // elementul din vector v={1,3,2,2}
                    frecventaCurs.Add(frecventa); 

                }
                   
               
            }
            SortareFrecventa(frecventaCurs); //sorteaza de la mare la mic v = {1,2,2,3}
            return frecventaCurs; // imi da vectorul final

        }
        private  void SortareFrecventa(List<FrecventaCurs> frecventaCurs)
        {

            for(int i=0;i< frecventaCurs.Count - 1; i++)
            {
                for (int j = i + 1; j < frecventaCurs.Count; j++)
                {
                    if (frecventaCurs[i].corsFreq> frecventaCurs[j].corsFreq)
                    {
                        FrecventaCurs aux = frecventaCurs[i];
                        frecventaCurs[i] = frecventaCurs[j];
                        frecventaCurs[j] = aux;
                        
                    }
                }
            }
        }

        public int FindMosPopularCourse()
        {
            int max = 0;
            int pozitia = -1;
            int[] v = Frecventa();
            for(int i = 0; i < v.Length; i++)
            {
                if (v[i] > max)    
                {
                    max = v[i];     
                    pozitia = i;
                    
                }
            }
            return pozitia;  //  v[2] = 3   return 2
        }

      

      







        



    }
}
