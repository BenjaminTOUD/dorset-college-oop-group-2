using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Admin : User
    {
        // 23166 Victor CAZAUX, 23163 Théo UNDERWOOD, 23167 Nicolas GONCALVES, 23206 BENJAMIN TOUBIANA, 23178 FOUCAUD BONNEFONT, 23174 Thomas CULINO
        public Admin()
        {
            #region test
            List<Course> a = new List<Course>();
            FacultyMember b = new FacultyMember(a);
            Course az = new Course("maths", 1.5, "blabla", b, "L309");
            Course aze = new Course("english", 1.5, "blabla", b, "L309");
            Course azer = new Course("french", 1.5, "blabla", b, "L309");
            Course azert = new Course("physics", 1.5, "blabla", b, "L309");
            a.Add(az);
            a.Add(aze);
            a.Add(azer);
            a.Add(azert);
            CreateTT(a);
            //CreateCourse("maths", 1.5, "blabla", b, "L309");
            #endregion
        }

        public void CreateCourse(string name, double duration, string coursePlan, FacultyMember prof, string room)
        {
            new Course(name, duration, coursePlan, prof, room);
            Console.WriteLine($"the course {name} has been created");
        }
        public void CreateTT(List<Course> course)   //Work In Progress
        {
            List<List<string>> newTT = new List<List<string>>();
            for (int i = 0; i < 5; i++)
            {
                List<string> alist = new List<string>();
                newTT.Add(alist);
                newTT[i].Add($"day {i + 1} ");
            }
            Random generate = new Random();
            int day = -1;
            foreach (Course aCourse in course)
            {
                do
                {
                    day = generate.Next(5);
                    if (newTT[day].Count() < 3)
                    {
                        newTT[day].Add(aCourse.Name);
                    }
                } while (day == -1);
            }
            for (int i = 0; i < newTT.Count(); i++)
            {
                for (int j = 0; j < newTT[i].Count(); j++)
                {
                    Console.Write($" {newTT[i][j]} ");
                }
                Console.WriteLine();
            }
        }
        public void TrackPayment(Student student)
        {
            int totalPayment = 0;
            foreach (int item in student.Payment)
            {
                Console.WriteLine(item);
                totalPayment += item;
            }
            Console.WriteLine(totalPayment);
        }
        public void AddStudent(List<Course> classes, int year, List<int> payment, List<List<int>> notes, List<bool> attendance)
        {
            new Student(classes, year, payment, notes, attendance);
            Console.WriteLine($"the student : {Name} has been added");
        }
    }
}
