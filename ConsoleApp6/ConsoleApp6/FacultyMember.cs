using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_projet
{
    public class FacultyMember : User
    {
        public List<Course> courses = new List<Course>();



        public FacultyMember(List<Course> courses, int ID, string name, string password, string adress, string inscriptionDate, string phoneNumber) : base(ID, name, password, adress, inscriptionDate, phoneNumber)
        {
            this.courses = courses;
        }


        public double GradeAStudent(Student student)  // method used to grade a specific student
        {
            double grade = 0;
            Console.WriteLine("Which grade would you assign to" + student);  // asking the grade 
            grade = Convert.ToInt32(Console.ReadLine());    // teacher writing the grade
            student.notes[0].Add(grade);        // adding the grade to the student note list
            return grade;
        }

    public void AttendThere(Student student)    // Method used to write "present" a specific student
        {
            bool attendance = true;
            student.Attendance.Add(attendance); // adding "present" to the attendance list of the student
            Console.WriteLine(student.name + " is present.");  // confirmation sentence
        }
        public void AttendAbsent(Student student) // Method used to write "absent" a specific student
        {
            bool attendance = false;
            student.Attendance.Add(attendance);  // adding "absent" to the attendance list of the student
            Console.WriteLine(student.name + " is absent.");  // confirmation sentence
        }

        public Exam CreateExam(string name, double duration, string coursePlan, FacultyMember prof, string room)  // method used to Create an Exam
        {
            Exam exam = new Exam(name, duration, coursePlan, prof, room, new List<Student>());  // here is the new Object Exam
            Console.WriteLine("This Exam as been created with succes"); // confirmation sentence
            return exam;
        }

        public void EditCoursePlan(Course course)  // method used to edit a courseplan into a specific course 
        {
            Console.WriteLine("There is the actual courseplan :"); // writing the existing courseplan
            Console.WriteLine(course.CoursePlan);
            Console.WriteLine();
            Console.WriteLine("Type the new courseplan : ");   // asking to type the nex courseplan 
            course.CoursePlan = Console.ReadLine();
            Console.WriteLine("There is the new courseplan");   // Writing the new courseplan 
            Console.WriteLine(course.CoursePlan);
            Console.ReadKey();
        }



        public void ToString()  // method used write facultyMember parameter 
        {
            Console.WriteLine("Name : " + name + ", ID : " + ID + ", Inscription Date : " + inscriptionDate);
        }

    }
}
