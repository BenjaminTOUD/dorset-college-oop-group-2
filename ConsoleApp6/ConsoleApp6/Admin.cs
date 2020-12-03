using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Admin : User
    {
        // 23166 Victor CAZAUX, 23163 Théo UNDERWOOD, 23167 Nicolas GONCALVES, 23206 BENJAMIN TOUBIANA, 23178 FOUCAUD BONNEFONT, 23174 Thomas CULINO
        public Admin(int ID, string name, string password, string adress, string inscriptionDate, string phoneNumber) : base(ID, name, password, adress, inscriptionDate, phoneNumber)
        {


        }
        //creating a course and saving the course in a text file
        public Course CreateCourse(string name, double duration, string coursePlan, FacultyMember prof, string room, List<Student> clas)
        {
            Course a = new Course(name, duration, coursePlan, prof, room, clas);
            Console.WriteLine($"the course {a.Name} has been created");   //confirmation that the course has been created
            string path = "./Course.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.Write($"{name},{duration},{coursePlan},{prof.Name},{room},");
                foreach (Student studentTest in clas)
                {
                    sw.Write(studentTest.Name + " ");
                }
                sw.WriteLine();
            }
            return a;

        }
        //Creating and displaying a timetable
        public void CreateTT(Student aStudent)
        {
            string[,] newTT = new string[6, 6];
            //filling the first line
            newTT[0, 0] = "     ";
            newTT[0, 1] = "Monday";
            newTT[0, 2] = "Tuesday";
            newTT[0, 3] = "Wednesday";
            newTT[0, 4] = "Thursday";
            newTT[0, 5] = "Friday";
            //filling the first column
            for (int i = 1; i < 6; i++)
            {
                newTT[i, 0] = $"{8 + 2 * (i - 1)}h";
                //Adding spaces to have a beautiful timetable on the console
                while (newTT[i, 0].Length != 5)
                {
                    newTT[i, 0] += " ";
                }
                while (newTT[0, i].Length != 10)
                {
                    newTT[0, i] += " ";
                }
            }
            Random generator = new Random();
            int day = -1;
            int hour = -1;
            //Placing the courses using random generators
            foreach (Course aCourse in aStudent.classes)
            {
                day = generator.Next(1, 6);  //generating the day
                int count = 0;
                for (int i = 1; i < 6; i++)
                {
                    if (newTT[i, day] != null) count++; //counting the number of courses a day to have at most 3 classes everyday 
                }
                if (count < 3)
                {
                    do
                    {
                        hour = generator.Next(1, 6);    //generating the hour
                    } while (newTT[hour, day] != null);
                    newTT[hour, day] = aCourse.name;    //adding the name of the course in the timetable
                                                        //adding spaces
                    while (newTT[hour, day].Length != 10)
                    {
                        newTT[hour, day] += " ";
                    }
                }
            }
            //Writing on the console
            for (int i = 0; i < newTT.GetLength(0); i++)
            {
                for (int j = 0; j < newTT.GetLength(1); j++)
                {
                    if (newTT[i, j] != null) Console.Write($"{newTT[i, j]}");
                    else
                    {
                        Console.Write(new string(' ', newTT[0, j].Length)); //Filling blanks with spaces in order not to shift the timetable
                    }
                }
                Console.WriteLine();
            }
        }
        //function that shows every payment a student made
        public void TrackPayment(Student student)
        {
            int totalPayment = 0;
            foreach (int item in student.Payment)   //display a list of every payment
            {
                Console.WriteLine(item);
                totalPayment += item;
            }
            Console.WriteLine($"-----------------------------\nThe total amount is  : {totalPayment}"); //display the total amount spent
        }
        //create a student 
        public Student AddStudent(List<Course> classes, int year, List<int> payment, List<List<double>> notes, List<bool> attendance, int ID, string name, string password, string adress, string inscriptionDate, string phoneNumber)
        {

            Student a = new Student(classes, year, payment, notes, attendance, ID, name, password, adress, inscriptionDate, phoneNumber);
            a.name = name;
            List<double> list = new List<double>();
            notes.Add(list);
            Console.WriteLine($"the student : {name} has been added");  //confirmation that the student has been created
            string path = "./Student.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                foreach (Course aCourse in classes)
                {
                    sw.Write(aCourse.Name + " ");
                }
                sw.Write($",{year},");
                foreach (int aPayment in payment)
                {
                    sw.Write(aPayment + " ");
                }
                sw.Write($",");
                //foreach (int aNote in notes[0])
                //{
                //    sw.Write(aNote + " ");
                //}
                sw.Write($",");
                foreach (bool theAttendance in attendance)
                {
                    sw.Write(theAttendance + " ");
                }
                sw.WriteLine($",{ID},{name},{password},{adress},{inscriptionDate},{phoneNumber}");
            }
            return a;
        }

        public void ToString()
        {
            Console.WriteLine($"ID : {ID}, name : {name}, adress : {adress}, phone number : {phoneNumber}");
        }

    }

}
