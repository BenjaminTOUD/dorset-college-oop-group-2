using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    // 23166 Victor CAZAUX, 23163 Théo UNDERWOOD, 23167 Nicolas GONCALVES, 23206 BENJAMIN TOUBIANA, 23178 FOUCAUD BONNEFONT, 23174 Thomas CULINO
    class Tutor : FacultyMember
    {
        public Tutor(List<Course> courseList) : base(courseList)
        {

        }

        public void StudentDetail(Student student)
        {
            Console.WriteLine("ID : " + User.ID + ", Name : " + User.Name + ", Adress : " + User.Adress + ", Phone : " + User.PhoneNumber);
        }
    }
}
