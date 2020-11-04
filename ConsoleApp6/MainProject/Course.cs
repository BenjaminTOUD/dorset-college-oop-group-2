using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Course         // 23166 Victor CAZAUX, 23163 Théo UNDERWOOD, 23167 Nicolas GONCALVES, 23206 BENJAMIN TOUBIANA, 23178 FOUCAUD BONNEFONT, 23174 Thomas CULINO

    {
        string name;
        double duration;
        string coursePlan;
        string room;
        private FacultyMember prof;

        public Course(string name, double duration, string courseplan, FacultyMember prof, string room)
        {
            this.name = name;
            this.duration = duration;
            // this.coursePlan = coursePlan;
            this.prof = prof;
            this.room = room;
        }





        public string toStringCoursePlan()
        {
            return "The course name is : " + name + ", the course duration is : " + duration + " minutes, the professor is :" + prof.Name + " and the course will be in room : " + room;
        }


    }
}