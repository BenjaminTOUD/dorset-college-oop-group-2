using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_projet
{
    class Project : Course
    {
        public Project(string name, double duration, string coursePlan, FacultyMember prof, string room) : base(name, duration, coursePlan, prof, room)
        {

        }


    }
}
