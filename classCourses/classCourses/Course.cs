using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Course         //Victor CAZAUX , Théo UNDERWOOD , Nicolas GONCALVES , BENJAMIN TOUBIANA , FOUCAUD BONNEFONT , Thomas CULINO
    {
        string name;
        double duration;
        string coursePlan;
        // FacultyMember prof; //need to create FacultyMember class
        string room;

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
