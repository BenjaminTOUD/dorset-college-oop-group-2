using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Tutor
    {
        public Tutor()
        {

        }

        public void StudentDetail(Student student)
        {
            Console.WriteLine("ID : " + User.ID + ", Name : " + User.Name + ", Adress : " + User.Adress + ", Phone : " + User.PhoneNumber);
        }
    }
}
