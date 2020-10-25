using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{    
    // 23166 Victor CAZAUX, 23163 Théo UNDERWOOD, 23167 Nicolas GONCALVES, 23206 BENJAMIN TOUBIANA, 23178 FOUCAUD BONNEFONT, 23174 Thomas CULINO
    class FacultyMember
    {
        List<Course> courses = new List<Course>();

        public FacultyMember(List<Course> courses)
        {
            this.courses = courses;
        }

        public void GradeAStudent(Student student)
        {

        }
        public void AttendAStudent(Student student)
        {

        }
        public void CreateExam()
        {

        }
        public void EditCoursePlan()
        {

        }
    }
}
