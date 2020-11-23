using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    // 23166 Victor CAZAUX, 23163 Théo UNDERWOOD, 23167 Nicolas GONCALVES, 23206 BENJAMIN TOUBIANA, 23178 FOUCAUD BONNEFONT, 23174 Thomas CULINO
    public class FacultyMember : User  //This class inherit user
        {
            public List<Course> courses = new List<Course>();
            


            public FacultyMember(List<Course> courses, int ID, string name, string password, string adress, string inscriptionDate, string phoneNumber) : base(ID, name, password, adress, inscriptionDate, phoneNumber)
            {
                this.courses = courses;
            }


            public void GradeAStudent(Student student) // method used to Grade a student and to save it in a text file
            {
                double grade = 0;
                Console.WriteLine("Which grade would you assign to" + student);
                grade = Convert.ToInt32(Console.ReadLine());
                student.notes[0].Add(grade);         // writing the note in the Student Grade List    
                Console.WriteLine("The grade " + grade + " Has been succesfully added to " + student); // Confirmation Sentence 
                Console.ReadKey();
            }

            public void AttendThere(Student student)   // method used to Attend Present a student 
            {
                bool attendance = true;
                student.Attendance.Add(attendance);    // writing in the Student attendance List that he is Present         
                Console.WriteLine(student + " was well written present at your course ");  // confirmation sentence
                Console.ReadKey();
            }
            public void AttendAbsent(Student student)   // method used to Attend Absent a student 
            {
                bool attendance = false;
                student.Attendance.Add(attendance);  // writing in the Student attendance List that he is absent
                Console.WriteLine(student + " was well written present at your course ");  // confirmation sentence
                Console.ReadKey();
            }

            public void CreateExam(string name, double duration, FacultyMember prof, string room, List<Student> clas)  // method used to Create an Exam
            {
                Exam exam = new Exam(name, duration, prof, room, clas);  // here is the new Object Exam
                Console.WriteLine("This Exam as been created with succes"); // confirmation sentence
                Console.ReadKey();
            }

            public void EditCoursePlan(Course course)  // method used to Edit a Course Plan of a specific course
            {
                Console.WriteLine("There is the actual courseplan :");
                Console.WriteLine(course.CoursePlan);
                Console.WriteLine();
                Console.WriteLine("Type the new courseplan : ");
                course.CoursePlan = Console.ReadLine();
                Console.WriteLine("There is the new courseplan");
                Console.WriteLine(course.CoursePlan);
                Console.ReadKey();
            }

        }

    }
}
