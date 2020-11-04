using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    // 23166 Victor CAZAUX, 23163 Théo UNDERWOOD, 23167 Nicolas GONCALVES, 23206 BENJAMIN TOUBIANA, 23178 FOUCAUD BONNEFONT, 23174 Thomas CULINO
    class FacultyMember : User
    {
        List<Course> courses = new List<Course>();

        public FacultyMember(List<Course> courses)
        {
            this.courses = courses;
        }


        public double GradeAStudent(Student student)
        {
            double grade = 0;
            Console.WriteLine("Which grade would you assign to" + student);
            grade = Convert.ToInt32(Console.ReadLine());
            return grade;
        }

        public void AttendThere(Student student)
        {
            bool attendance = true;
            student.Attendance.Add(attendance);
        }
        public void AttendAbsent(Student student)
        {
            bool attendance = false;
            student.Attendance.Add(attendance);
        }

        public void CreateExam()
        {
            /// ? 
        }

        public void EditCoursePlan(Course course)
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
