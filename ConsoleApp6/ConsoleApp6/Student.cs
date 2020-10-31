using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    // 23166 Victor CAZAUX, 23163 Théo UNDERWOOD, 23167 Nicolas GONCALVES, 23206 BENJAMIN TOUBIANA, 23178 FOUCAUD BONNEFONT, 23174 Thomas CULINO
    class Student
    {
        List<Course> classes = new List<Course>();
        int year;
        List<int> payment = new List<int>();
        List<List<int>> notes = new List<List<int>>();
        List<bool> attendance = new List<bool>();

        public Student(List<Course> classes, int year, List<int> payment, List<List<int>> notes, List<bool> attendance)
        {
            this.classes = classes;
            this.year = year;
            this.payment = payment;
            this.notes = notes;
            this.attendance = attendance;
        }

        public void RegisterCourse(Course course)
        {
            return "The student " + User.Name + " is registered to the following courses : " + List < Course > classes();
        }
        public void ToStringAttendance()
        {

        }
        public void ToStringNotes()
        {

        }
        public void ToStringPayment()
        {

        }
        public void ToStringCourses()
        {

        }
    }
}
