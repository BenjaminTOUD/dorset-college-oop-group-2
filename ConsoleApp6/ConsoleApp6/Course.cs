using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_projet
{
    public class Course

    {
        public string name;
        public double duration;
        public string coursePlan;
        public FacultyMember prof;
        public string room;
        public List<Student> clas;

        public Course(string name, double duration, string coursePlan, FacultyMember prof, string room, List<Student> clas)
        {
            this.name = name;
            this.duration = duration;
            this.coursePlan = coursePlan;
            this.prof = prof;
            this.room = room;
            this.clas = clas;
        }

        public string Name { get; set; }
        public double Duration => duration;
        public string CoursePlan { get; set; }
        public string Room => room;

        public string toStringCoursePlan()
        {
            return "The course name  is : " + name + ", the course duration is : " + duration + " minutes, the professor is :" + prof.Name + " and the course will be in room : " + room;
        }
    }
}
