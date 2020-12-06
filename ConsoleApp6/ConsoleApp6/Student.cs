using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_projet
{
    public class Student : User
    {
        public List<Course> classes = new List<Course>();
        public int year;
        public List<int> payment = new List<int>();
        public List<List<double>> notes = new List<List<double>>();
        public List<bool> attendance = new List<bool>();
        public List<bool> Attendance => attendance;

        public List<int> Payment
        {
            get { return payment; }
            set { this.payment = value; }
        }

        // constructor with all the student's information
        public Student(List<Course> classes, int year, List<int> payment, List<List<double>> notes, List<bool> attendance, int ID, string name, string password, string adress, string inscriptionDate, string phoneNumber) : base(ID, name, password, adress, inscriptionDate, phoneNumber)
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
            course.clas.Add(this);
            Console.WriteLine("You just have registered for the following course : " + course.name);
        }
        public void ToStringAttendance() // displays the attendances of the student
        {
            int absent = 0;
            int present = 0;
            for (int i = 0; i < attendance.Count; i++)
            {
                if (attendance[i] == false)
                {
                    Console.WriteLine(i + " : You were absent");
                    absent++;
                }
                else if (attendance[i] == true)
                {
                    Console.WriteLine(i + " : You were present");
                    present++;
                }
            }
            Console.WriteLine("You have been absent for " + absent + " courses out of " + attendance.Count + ".");
        }

        public void Pay(int pay)
        {
            payment.Add(pay);                     //Add the new payment to the list of his payment
            this.ToStringPayment();
        }

        public void ToStringNotes() // displays his notes
        {
            Console.WriteLine("Here are your notes : ");
            for (int i = 0; i < notes[0].Count; i++)
            {
                Console.WriteLine(notes[0][i]);
            }
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
            for (int i = 0; i < classes.Count; i++)
            {
                Console.WriteLine(classes[i].name);
            }
        }

        public void ToString()
        {
            Console.WriteLine("Name : " + name + ", ID : " + ID + ", Inscription Date : " + inscriptionDate);
        }
    }
}
