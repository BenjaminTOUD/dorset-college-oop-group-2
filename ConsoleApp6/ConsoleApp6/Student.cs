using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    // 23166 Victor CAZAUX, 23163 Théo UNDERWOOD, 23167 Nicolas GONCALVES, 23206 BENJAMIN TOUBIANA, 23178 FOUCAUD BONNEFONT, 23174 Thomas CULINO
    public class Student : User
    {
        List<Course> classes = new List<Course>();
        int year;
        List<int> payment = new List<int>();
        public List<List<int>> notes = new List<List<int>>();
        List<bool> attendance = new List<bool>();

        public List<bool> Attendance => attendance;

        public List<int> Payment
        {
            get { return payment; }
            set { this.payment = value; }
        }

        // constructor with all the student's information
        public Student(List<Course> classes, int year, List<int> payment, List<List<int>> notes, List<bool> attendance, int ID, string name, string password, string adress, string inscriptionDate, string phoneNumber) : base(ID, name, password, adress, inscriptionDate, phoneNumber)
        {
            this.classes = classes;
            this.year = year;
            this.payment = payment;
            this.notes = notes;
            this.attendance = attendance;
        }

        public void RegisterCourse(Course course) // allows a student to register for courses
        {
            classes.Add(course);
            Console.WriteLine("You just have registered for the following course : " + course);
        }
        public void ToStringAttendance() // displays the attendances of the student
        {
            for (int i = 0; i < attendance.Count; i++)
            {
                if(attendance[i]==false)
                {
                    Console.WriteLine("You were absent");
                }
                else if(attendance[i]==true)
                {
                    Console.WriteLine("You were present");
                }
            }
        }
        public void ToStringNotes() // displays his notes
        {
            Console.WriteLine("Here are your notes : " + notes);
        }
        public void ToStringPayment() // allows the student to pay the tuition fees
        {
            int paid = 0;
            for (int i = 0; i < payment.Count; i++)
            {
                paid += payment[i];
            }
            Console.WriteLine("You have paid £" + paid);
        }
        public void ToStringCourses() // displays the courses in which he is enrolled
        {
            Console.WriteLine("You are registered for the following courses : ");
            for (int i = 1; i < classes.Count; i++)
            {
                Console.WriteLine(classes[i].Name);
            }
        }
    }
}