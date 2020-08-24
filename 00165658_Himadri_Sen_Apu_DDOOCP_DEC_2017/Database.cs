using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00165658_Himadri_Sen_Apu_DDOOCP_DEC_2017
{
    class Database
    {
        public static int count;
        
        public static ArrayList Userslist = new ArrayList();
       
        public void Adduser(User u)
        {
            Userslist.Add(u);

            Console.WriteLine("Data save");
            Console.ReadLine();

        }
       

        public static ArrayList Recent = new ArrayList();

        public void Addrecent(User r)
        {
            Recent.Add(r);
           
            Console.WriteLine("Data save");
            Console.ReadLine();
            count = Recent.Count;

        }

        public Form1 Form1
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Form2 Form2
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Form3 Form3
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        internal Database Database1
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
    }
}
