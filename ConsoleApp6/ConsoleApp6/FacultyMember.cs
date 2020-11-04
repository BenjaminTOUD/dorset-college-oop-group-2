using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project

{
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
            student.attendance.add(attendance);
        }
        public void AttendAbsent(Student student)
        {
            bool attendance = false;
            student.attendance.add(attendance);
        }

        public void CreateExam()
        {
            /// ? 
        }

        public void EditCoursePlan(Course course)
        {
            Console.WriteLine("There is the actual courseplan :");
            Console.WriteLine(course.courseplan);
            Console.WriteLine();
            Console.WriteLine("Type the new courseplan : ");
            course.courseplan = Console.ReadLine();
            Console.WriteLine("There is the new courseplan");
            Console.WriteLine(course.courseplan);
            Console.ReadKey();
        }

    }
}
