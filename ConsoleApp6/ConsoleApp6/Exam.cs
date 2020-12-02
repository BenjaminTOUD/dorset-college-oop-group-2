using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_projet
{
    public class Exam : Course
    {
        public Exam(string name, double duration, string coursePlan, FacultyMember prof, string room, List<Student> clas) : base(name, duration, coursePlan, prof, room, clas)
        {

        }


    }
}
