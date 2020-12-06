using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Threading;

namespace Main_projet
{
    class Program
    {
        // 23166 Victor CAZAUX, 23163 Théo UNDERWOOD, 23167 Nicolas GONCALVES, 23206 BENJAMIN TOUBIANA, 23178 FOUCAUD BONNEFONT, 23174 Thomas CULINO

        static int[] IsRegistered(int ID, List<Student> Students, List<FacultyMember> Teachers, List<Tutor> Tutors, List<Admin> Admins)
        {
            int[] result = { 0, 0 };
            for (int i = 0; i < Students.Count; i++)                  //In the students
            {
                if (Students[i].ID == ID)                  //If the ID entered is the same as one in the data base
                {
                    result[0] = 1;                        //The category is 1
                    result[1] = i;                       //We get the position of this student in the list
                    break;
                }
            }
            for (int i = 0; i < Teachers.Count; i++)             //In the teachers
            {
                if (Teachers[i].ID == ID)                       //If the ID entered is the same as one in the data base
                {
                    result[0] = 2;                              //The category is 2
                    result[1] = i;
                    break;
                }
            }
            for (int i = 0; i < Tutors.Count; i++)           //In the tutors
            {
                if (Tutors[i].ID == ID)                  //If the ID entered is the same as one in the database
                {
                    result[0] = 3;                            //The category is 3
                    result[1] = i;
                    break;
                }
            }
            for (int i = 0; i < Admins.Count; i++)                    //In the admins
            {
                if (Admins[i].ID == ID)
                {
                    result[0] = 4;                             //The category is 4
                    result[1] = i;
                    break;
                }
            }
            return result;
        }

        public static int CheckCourse(string name, List<Course> Courses)
        {
            int result = -1;
            for (int i = 0; i < Courses.Count; i++)                //Going through all the courses in the database
            {
                if (Courses[i].name == name)                   //Checking if the name entered correspond to the name of a course
                {
                    result = i;
                }
            }
            return result;
        }

        static int CheckPassword(string password, int category, int position, List<Student> Students, List<FacultyMember> Teachers, List<Tutor> Tutors, List<Admin> Admins)
        {
            int result = 0;
            if (category == 1)                                                
            {
                if (Students[position].password == password)            //Checking if the password correspond to a student
                {
                    result = 1;
                }
            }
            if (category == 2)
            {
                if (Teachers[position].password == password)          //Checking if the password correspond to a teacher
                {
                    result = 1;
                }
            }
            if (category == 3)
            {
                if (Tutors[position].password == password)              //Checking if the password correspond to a tutor
                {
                    result = 1;
                }
            }
            if (category == 4)
            {
                if (Admins[position].password == password)              //Checking if the password correspond to an admin
                {
                    result = 1;
                }
            }
            return result;
        }

    

        static int CheckStudent(string name, List<Student> Students)
        {
            int result = -1;
            for (int i = 0; i < Students.Count; i++)               //Going through all the students in the database
            {
                if (Students[i].name == name)                      //Checking if the name entered correspond to the name of a course
                {
                    result = i;
                }
            }
            return result;
        }

        static int CheckSTeacher(string name, List<FacultyMember> Teachers,List<Tutor> Tutors)         
        {
            int result = -1;
            for (int i = 0; i < Teachers.Count; i++)//Going through all the Teachers in the database
            {
                if (Teachers[i].name == name)//Checking if the name entered correspond to the name of a teacher
                {
                    result = i;
                }
            }
            for (int i = 0; i < Tutors.Count; i++)//Going through all the tutors in the database
            {
                if (Tutors[i].name == name)//Checking if the name entered correspond to the name of a tutor
                {
                    result = i;
                }
            }
            return result;
        }

        static string[][] FileToArray(string path)
        {

            string[] txtFileLines = File.ReadAllLines(path);                  //Getting the content of an entire .txt
            string[][] txtFileContent = new string[txtFileLines.Length][];   
            for (int i = 0; i < txtFileLines.Length; i++)
            {
                txtFileContent[i] = txtFileLines[i].Split(',');             //splitting
            }
            return txtFileContent;
        }

        static void ListToStudent(string[][] tabstud,List<Student> Students)       //Creates a new student with informations collected in the .txt file
        {
            
            for (int i = 0; i < tabstud.Length; i++)                            //Getting a tab filled with the informations of all the students
            {
                for (int j = -11; j < tabstud[i].Length - 11; j = j + 11)//Going all the way through the tab
                {
                    string[] fees = tabstud[i][j + 13].Split('/');           //Getting a list of fees paid
                    List<int> fee = new List<int>();
                    for(int k=0; k<fees.Length-1;k++)
                    {
                        fee.Add(Convert.ToInt32(fees[k]));
                    }
                    string[] notes = tabstud[i][j + 14].Split('/');
                    List<double> note = new List<double>();                   //Getting a list of notes
                    for (int k = 0; k < notes.Length - 1; k++)
                    {
                        note.Add(Convert.ToInt32(notes[k]));
                    }
                    string [] courses = tabstud[i][j + 11].Split('/');
                    string[] presences = tabstud[i][j + 15].Split('/');          //Getting a list of bool representing the attendance
                    List<bool> presence = new List<bool>();
                    for (int k = 0; k < presences.Length - 1; k++)
                    {
                        presence.Add(Convert.ToBoolean(presences[k]));
                    }
                    int ide = Convert.ToInt32(tabstud[i][j + 16]);
                    string name = tabstud[i][j + 17];
                    string password = tabstud[i][j + 18];          //Getting easy access informations
                    string adress = tabstud[i][j + 19];
                    string date = tabstud[i][j + 20];
                    string number = tabstud[i][j + 21];
                    List<List<double>> list = new List<List<double>>();
                    list.Add(note);
                    Students.Add(new Student(new List<Course>(), 2, fee, list, presence, ide, name, password, adress, date, number));   //Creating new student
                }
            }
      
        }

        static void ListToAdmin(string[][] tabadmin, List<Admin> Admins)         //Creates a new Admin with informations collected in the .txt file
        {
            for (int i = 0; i < tabadmin.Length; i++)
            {
                for (int j = -6; j < tabadmin[i].Length - 6; j = j + 6)    //Going all the way through the tab
                {
                    int ide = Convert.ToInt32(tabadmin[i][j + 6]);

                    string name = tabadmin[i][j + 7];
                    string password = tabadmin[i][j + 8];
                    string adress = tabadmin[i][j + 9];                          //Gettting all the easy access information
                    string date = tabadmin[i][j + 10];
                    string number = tabadmin[i][j + 11];
                    Admins.Add(new Admin(ide, name, password, adress, date, number));  //Creates a new Admin
                }
            }
        }

        static void ListToteach(string[][] tabteach, List<FacultyMember> Teachers)
        {
            for (int i = 0; i < tabteach.Length; i++)
            {
                for (int j = -6; j < tabteach[i].Length - 8; j = j + 8)  //Going all the way through the tab
                {
                    int ide = Convert.ToInt32(tabteach[i][j + 8]);

                    string name = tabteach[i][j + 9];         //Getting all the easy access informations
                    string password = tabteach[i][j + 10];
                    string adress = tabteach[i][j + 11];
                    string date = tabteach[i][j + 12];
                    string number = tabteach[i][j + 13];
                    Teachers.Add(new FacultyMember(new List<Course>(), ide, name, password, adress, date, number));     //Creating a new teacher
                }
            }
        }

        static void ListToTut(string[][] tabtu, List<Tutor> Tutors)
        {
            for (int i = 0; i < tabtu.Length; i++)
            {
                for (int j = -6; j < tabtu[i].Length - 8; j = j + 8)//Going all the way through the tab
                {
                    int ide = Convert.ToInt32(tabtu[i][j + 8]);

                    string name = tabtu[i][j + 9];
                    string password = tabtu[i][j + 10];
                    string adress = tabtu[i][j + 11];          //Getting all the easy access informations
                    string date = tabtu[i][j + 12];
                    string number = tabtu[i][j + 13];
                    Tutors.Add(new Tutor(new List<Course>(), ide, name, password, adress, date, number));     //Creating a new tutor
                }
            }
        }

        static List<Course> ListToCourse(string[][] tabcourse, List<Course> Courses,List<FacultyMember> Teachers,List<Tutor> Tutors)
        {
            for (int i = 0; i < tabcourse.Length; i++)
            {
                for (int j = -5; j < tabcourse[i].Length - 5; j = j + 5)       //Going all the way through the tab
                {
                    string name = tabcourse[i][j + 5];
                    double duration = Convert.ToInt32(tabcourse[i][j + 6]);
                    string coursePlan = tabcourse[i][j + 7];
                    string tname = tabcourse[i][j + 8];                //Getting all the easy access information
                    string room = tabcourse[i][j + 9];

                    Courses.Add(new Course(name, duration, coursePlan, Teachers[CheckSTeacher(tname, Teachers,Tutors)], room, new List<Student>()));      //Creating a new course
                }
            }
            return Courses;
        }

        static void ListToExam(string[][] tabex, List<Exam> Exams , List<FacultyMember> Teachers,List<Tutor> Tutors)
        {
            for (int i = 0; i < tabex.Length; i++)
            {
                for (int j = -5; j < tabex[i].Length - 5; j = j + 5)    //Going all the way through the tab
                {
                    string name = tabex[i][j + 5];
                    double duration = Convert.ToInt32(tabex[i][j + 6]);
                    string coursePlan = tabex[i][j + 7];                     //Getting all the easy informations
                    string tname = tabex[i][j + 8];
                    string room = tabex[i][j + 9];
                    Exams.Add(new Exam(name, duration, coursePlan,Teachers[CheckSTeacher(tname,Teachers,Tutors)] , room, new List<Student>()));    //Creating a new exam
                }
            }
        }

            static void SaveEverything(List<Student> Students,List<FacultyMember> Teachers,List<Tutor> Tutors,List<Admin> Admins,List<Course> Courses,List<Exam> Exams)   //Save all the informations in the txt file
            {
            StreamWriter writer = new StreamWriter("./Student.txt", false);            //Erasing all the files
            writer.Close();
            StreamWriter writer2 = new StreamWriter("./FacultyMember.txt", false);
            writer2.Close();
            StreamWriter writer3 = new StreamWriter("./Tutor.txt", false);
            writer3.Close();
            StreamWriter writer4 = new StreamWriter("./Admin.txt", false);
            writer4.Close();
            StreamWriter writer5 = new StreamWriter("./Course.txt", false);
            writer5.Close();
            StreamWriter writer6 = new StreamWriter("./Exam.txt", false);
            writer6.Close();
            for (int i = 0; i < Students.Count(); i++)                            //For each student
            {
                using (StreamWriter sw = File.AppendText("./Student.txt"))      //We write in the Student file
                {
                    foreach (Course aCourse in Students[i].classes)
                    {
                        sw.Write(aCourse.name + "/");                   //Writting all the courses
                    }
                    sw.Write($",{Students[i].year},");               //Writting the year
                    foreach(double payments in Students[i].payment)
                    {
                        sw.Write(payments + "/");                         //Payment
                    }
                    sw.Write($",");
                    foreach (double aNote in Students[i].notes[0])
                    {
                        sw.Write(aNote + "/");                              //Note
                    }
                    sw.Write($",");
                    foreach (bool theAttendance in Students[i].attendance)
                    {
                        sw.Write(theAttendance + "/");                          //Attendance
                    }
                    sw.WriteLine($",{Students[i].ID},{Students[i].name},{Students[i].password},{Students[i].adress},{Students[i].inscriptionDate},{Students[i].phoneNumber}");    //And all easy informations
                }
            }
            for (int i = 0; i < Teachers.Count(); i++)        //For each Teachers
            {
                using (StreamWriter sw = File.AppendText("./FacultyMember.txt"))   //We write in the FacultyMember file
                {
                    foreach (Course aCourse in Teachers[i].courses)
                    {
                        sw.Write(aCourse.name + " ");                        //name
                    }
                    sw.Write($",");
                    sw.WriteLine($",{Teachers[i].ID},{Teachers[i].name},{Teachers[i].password},{Teachers[i].adress},{Teachers[i].inscriptionDate},{Teachers[i].phoneNumber}");   //And all easy informations
                }
            }
            for (int i = 0; i < Tutors.Count(); i++)
            {
                using (StreamWriter sw = File.AppendText("./Tutor.txt"))
                {
                    foreach (Course aCourse in Tutors[i].courses)
                    {
                        sw.Write(aCourse.name + " ");
                    }

                    sw.Write($",");

                    sw.WriteLine($",{Tutors[i].ID},{Tutors[i].name},{Tutors[i].password},{Tutors[i].adress},{Tutors[i].inscriptionDate},{Tutors[i].phoneNumber}");
                }
            }
            for (int i = 0; i < Admins.Count(); i++)
            {
                using (StreamWriter sw = File.AppendText("./Admin.txt"))
                {
                    sw.WriteLine($"{Admins[i].ID},{Admins[i].name},{Admins[i].password},{Admins[i].adress},{Admins[i].inscriptionDate},{Admins[i].phoneNumber}");
                }
            }
            for (int i = 0; i < Courses.Count(); i++)
            {
                using (StreamWriter sw = File.AppendText("./Course.txt"))
                {
                    //string name, double duration, string coursePlan, FacultyMember prof, string room, List<Student> clas
                    sw.WriteLine($"{Courses[i].name},{Courses[i].duration},{Courses[i].coursePlan},{Courses[i].prof.name},{Courses[i].room}");
                }
            }
            for (int i = 0; i <Exams.Count(); i++)
            {
                using (StreamWriter sw = File.AppendText("./Exam.txt"))
                {
                    //string name, double duration, string coursePlan, FacultyMember prof, string room, List<Student> clas
                    sw.WriteLine($"{Exams[i].name},{Exams[i].duration},{Exams[i].coursePlan},{Exams[i].prof.name},{Exams[i].room}");
                }
            }
        }

        static void VGC()
        {
            Console.Clear();
            for (int i = 0; i < 45; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("Virtual Global College Platform 2020");            //Printing a proper Console image for VGC Platform
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine();
            }

            for (int i = 0; i < 55; i++)
            {
                Console.Write(" ");
            }
        }

        static void NotRegistered(int ID,List<Student> Students,List<FacultyMember> Teachers,List<Tutor> Tutors,List<Admin> Admins)
        {
            if (IsRegistered(ID, Students, Teachers, Tutors, Admins)[0] == 0)                   //If the id is not recognized
            {
                for (int i = 0; i < 55; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("You are not registered.");                       //You are not registered
                for (int i = 0; i < 55; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }

        }

        static void InvalidPassword()
        {
            for (int i = 0; i < 55; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("Invalid password");                      //If the password is not matching the ID's one, you have the wrong password
            for (int i = 0; i < 55; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Console.Title = "Virtual Global College Platform";                //Setting the name of the console to VGC Platform
            
            string[][] tabstud = FileToArray("./Student.txt");
            string[][] tabcourse = FileToArray("./Course.txt");
            string[][] tabadmin = FileToArray("./Admin.txt");
            string[][] tabteach = FileToArray("./FacultyMember.txt");                  ///Getting all the files
            string[][] tabtu = FileToArray("./Tutor.txt");
            string[][] tabex = FileToArray("./Exam.txt");
            List<Admin> Admins = new List<Admin>();
            List<Student> Students = new List<Student>();
            List<FacultyMember> Teachers = new List<FacultyMember>();                      //Transfering my database in Lists
            List<Tutor> Tutors = new List<Tutor>();
            List<Course> Courses = new List<Course>();
            List<Exam> Exams = new List<Exam>();
            
            
            ListToAdmin(tabadmin, Admins);
            ListToStudent(tabstud, Students);
            ListToteach(tabteach, Teachers);
            ListToTut(tabtu, Tutors);
            ListToCourse(tabcourse, Courses, Teachers,Tutors);                        //Creating my objects
            ListToExam(tabex, Exams, Teachers, Tutors);
            while (true)
            {
            Start:
                Console.Clear();
                SaveEverything(Students, Teachers, Tutors, Admins, Courses, Exams);            //Save the changes
                for(int i=0;i<15; i++)
                {
                    Console.WriteLine();
                }
                for(int i=0;i<55;i++)
                { Console.Write(" "); }
                Console.WriteLine("Saving ...");                       //Printing stuff to make it look good
                int milliseconds = 2000;
                Thread.Sleep(milliseconds);
                Console.Clear();
                VGC();
                Console.WriteLine("Type in your ID :");
                for (int i = 0; i < 55; i++)
                {
                    Console.Write(" ");
                }
                int ID = Convert.ToInt32(Console.ReadLine());
                Console.Beep();
                int category = IsRegistered(ID, Students, Teachers, Tutors, Admins)[0];          //Getting category and position of the user 
                int position = IsRegistered(ID, Students, Teachers, Tutors, Admins)[1];
                if (IsRegistered(ID,Students,Teachers,Tutors,Admins)[0]!=0)                      //If ID is recognized
                {
                    VGC();
                    Console.WriteLine("ID : " + ID + " is registered !");
                    while (true)
                    {
                        for (int i = 0; i < 55; i++)
                        {
                            Console.Write(" ");
                        }
                        Console.WriteLine("Type in your password : ");                 //Type your password
                        for (int i = 0; i < 55; i++)
                        {
                            Console.Write(" ");
                        }
                        string password = Console.ReadLine();
                        if(CheckPassword(password,category,position, Students, Teachers, Tutors, Admins)==1)   //If password is recognized
                        {
                            for (int i = 0; i < 55; i++)
                            {
                                Console.Write(" ");
                            }
                            Console.WriteLine("Password is correct");               //Password is correct
                            Console.Beep();
                            Console.Clear();
                            while(true)
                            {
                                for (int i = 0; i < 45; i++)
                                {
                                    Console.Write(" ");
                                }
                                Console.WriteLine("Virtual Global College Platform 2020");
                                for (int i = 0; i < 5; i++)
                                {
                                    Console.WriteLine();
                                }
                                switch (category)                                         //Big switch, with four cases for four categories
                                {
                                    case 1:
                                        { 
                                            Console.WriteLine("1-Register for a course");
                                            Console.WriteLine("2-Display attendance");
                                            Console.WriteLine("3-Display notes");
                                            Console.WriteLine("4-Display fees paid");
                                            Console.WriteLine("5-Display courses you are in");
                                            Console.WriteLine("6-Display your personal informations");      //Student options
                                            Console.WriteLine("7-Change your adress");
                                            Console.WriteLine("8-Change your password");
                                            Console.WriteLine("9-Pay a part of your fees");
                                            Console.WriteLine("10-Exit");
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine("In any case, please exit properly from this menu to save your modifications.");
                                            int action = Convert.ToInt32(Console.ReadLine());
                                            Console.Beep();
                                            switch (action)
                                            {
                                                case 1:
                                                    Console.Clear();
                                                    Console.WriteLine("You already are in these courses :");
                                                    Students[position].ToStringCourses();
                                                    Console.WriteLine("For which course do you want to register ?");
                                                    string course = Console.ReadLine();
                                                    Console.Beep();
                                                    if (CheckCourse(course, Courses) != -1)                //If the course exists in the database
                                                    {
                                                        Students[position].RegisterCourse(Courses[CheckCourse(course, Courses)]);   //Student is registered
                                                        Console.WriteLine("Type any key to continue");
                                                    }
                                                    if (CheckCourse(course, Courses) == -1)    //If the course doesn't exists
                                                    {
                                                        Console.WriteLine("This course doesn't exist");    //nothing happens
                                                        Console.WriteLine("Type any key to continue");
                                                    }
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                case 2:
                                                    Console.Clear();
                                                    Students[position].ToStringAttendance();
                                                    Console.WriteLine("Type any key to continue");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                case 3:
                                                    Console.Clear();
                                                    Students[position].ToStringNotes();
                                                    Console.WriteLine("Type any key to continue");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                case 4:
                                                    Console.Clear();
                                                    Students[position].ToStringPayment();
                                                    Console.WriteLine("Type any key to continue");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                case 5:
                                                    Console.Clear();
                                                    Students[position].ToStringCourses();
                                                    Console.WriteLine("Type any key to continue");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                case 6:
                                                    Console.Clear();
                                                    Students[position].ToString();
                                                    Console.WriteLine("Type any key to continue");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                case 7:
                                                    Console.Clear();
                                                    Console.WriteLine("Type in your new adress");
                                                    string nadress = Console.ReadLine();
                                                    Console.Beep();
                                                    Students[position].ChangeAdress(nadress);
                                                    Console.WriteLine("Type any key to continue");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                case 8:
                                                    Console.Clear();
                                                    Console.WriteLine("Type in your new password");
                                                    string npass = Console.ReadLine();
                                                    Students[position].ChangePassword(npass);
                                                    Console.WriteLine("Type any key to continue");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                case 9:
                                                    Console.Clear();
                                                    Console.WriteLine("How much do you want to pay ?");
                                                    int pay = Convert.ToInt32(Console.ReadLine());
                                                    Students[position].Pay(pay);
                                                    Console.WriteLine("Type any key to continue");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                case 10:
                                                    goto Start;
                                            }
                                        }
                                        break;
                                    case 2:
                                        {
                                            Console.WriteLine("1-Grade a student");
                                            Console.WriteLine("2-Manage attendance");
                                            Console.WriteLine("3-Create an exam");
                                            Console.WriteLine("4-Edit your course plan");
                                            Console.WriteLine("5-Display your personal informations");
                                            Console.WriteLine("6-Change your adress");                           //Case of a Faculty Member
                                            Console.WriteLine("7-Change your password");
                                            Console.WriteLine("8-Exit");
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine("In any case, please exit properly from this menu to save your modifications.");
                                            int action = Convert.ToInt32(Console.ReadLine());
                                            Console.Beep();
                                            switch (action)
                                            {
                                                case 1:
                                                    Console.Clear();
                                                    Console.WriteLine("Which student ?");
                                                    string name = Console.ReadLine();
                                                    Console.Beep();
                                                    if (CheckStudent(name, Students) != -1)    //If the students exists
                                                    {
                                                        Teachers[position].GradeAStudent(Students[CheckStudent(name,Students)]);     //He is graded
                                                        Console.WriteLine("Type any key to continue");
                                                    }
                                                    if(CheckStudent(name,Students)==-1)
                                                    {
                                                        Console.WriteLine("This student doesn't exist");
                                                        Console.WriteLine("Type any key to continue");              //Else nothing happens
                                                    }
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                case 2:
                                                    Console.Clear();
                                                    Console.WriteLine("Which student ?");
                                                    string attname = Console.ReadLine();
                                                    Console.Beep();
                                                    if (CheckStudent(attname, Students) != -1)       //If the student exists
                                                    {
                                                        Console.WriteLine("1-Present");
                                                        Console.WriteLine("2-Absent");
                                                        int choice = Convert.ToInt32(Console.ReadLine());
                                                        Console.Beep();
                                                        if(choice==1)
                                                        {
                                                            Teachers[position].AttendThere(Students[CheckStudent(attname, Students)]);  //He is there
                                                        }
                                                        else if (choice == 2)
                                                        {
                                                            Teachers[position].AttendAbsent(Students[CheckStudent(attname, Students)]);  //He is absent
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Please choose 1 or 2. Press any key to continue.");
                                                            Console.ReadKey();
                                                            Console.Beep();
                                                            Console.Clear();
                                                        }
                                                    }
                                                    if (CheckStudent(attname, Students) == -1)
                                                    {
                                                        Console.WriteLine("This student doesn't exist");
                                                        Console.WriteLine("Type any key to continue");         //If the student doesn't exists, nothing happens
                                                    }
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                case 3:
                                                    Console.Clear();
                                                    Console.WriteLine("What is the name of the exam ?");
                                                    string nameEx = Console.ReadLine();
                                                    Console.Beep();
                                                    Console.WriteLine("How long will it be ?");
                                                    double duration = Convert.ToInt32(Console.ReadLine());
                                                    Console.Beep();
                                                    Console.WriteLine("What will be evaluated ?");     //Getting informations to create the exam
                                                    string prog = Console.ReadLine();
                                                    Console.Beep();
                                                    Console.WriteLine("In which room will it be ?");
                                                    string room = Console.ReadLine();
                                                    Console.Beep();
                                                    Exams.Add(Teachers[position].CreateExam(nameEx, duration, prog, Teachers[position], room));  //Creating the exam
                                                    Console.WriteLine("Type any key to continue");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                case 4:
                                                    Console.Clear();
                                                    Console.WriteLine("Which course plan do you want to edit?");
                                                    string namecourse = Console.ReadLine();
                                                    Console.Beep();
                                                    Course course = Courses[CheckCourse(namecourse, Courses)];
                                                    Teachers[position].EditCoursePlan(course);
                                                    Console.WriteLine("Type any key to continue");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                case 5:
                                                    Console.Clear();
                                                    Teachers[position].ToString();
                                                    Console.WriteLine("Type any key to continue");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                case 6:
                                                    Console.Clear();
                                                    Console.WriteLine("Type in your new adress");
                                                    string nadress = Console.ReadLine();
                                                    Console.Beep();
                                                    Teachers[position].ChangeAdress(nadress);
                                                    Console.WriteLine("Type any key to continue");
                                                    Console.Clear();
                                                    break;
                                                case 7:
                                                    Console.Clear();
                                                    Console.WriteLine("Type in your new password");
                                                    string npass = Console.ReadLine();
                                                    Teachers[position].ChangePassword(npass);
                                                    Console.WriteLine("Type any key to continue");
                                                    Console.Clear();
                                                    break;
                                                case 8:
                                                    goto Start;
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.WriteLine("1-Grade a student");
                                            Console.WriteLine("2-Manage attendance");
                                            Console.WriteLine("3-Edit your course plan");
                                            Console.WriteLine("4-Display your personal informations");
                                            Console.WriteLine("5-Teach a new course");
                                            Console.WriteLine("6-Display personal informations of a student");            //Case of a tutor
                                            Console.WriteLine("7-Change your adress");
                                            Console.WriteLine("8-Change your password");
                                            Console.WriteLine("9-Exit");
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine("In any case, please exit properly from this menu to save your modifications.");
                                            int action = Convert.ToInt32(Console.ReadLine());
                                            Console.Beep();
                                            switch (action)
                                            {
                                                case 1:
                                                    Console.Clear();
                                                    Console.WriteLine("Which student ?");
                                                    string name = Console.ReadLine();
                                                    Console.Beep();
                                                    if (CheckStudent(name, Students) != -1)
                                                    {
                                                        Tutors[position].GradeAStudent(Students[CheckStudent(name, Students)]);    //See case 2
                                                        Students[CheckStudent(name, Students)].ToStringNotes();
                                                    }
                                                    if (CheckStudent(name, Students) == -1)
                                                    {
                                                        Console.WriteLine("This student doesn't exist");
                                                        Console.WriteLine("Type any key to continue");
                                                    }
                                                    break;
                                                case 2:
                                                    Console.Clear();
                                                    Console.WriteLine("Which student ?");
                                                    string attname = Console.ReadLine();
                                                    Console.Beep();
                                                    if (CheckStudent(attname, Students) != -1)
                                                    {
                                                        Console.WriteLine("1-Present");
                                                        Console.WriteLine("2-Absent");
                                                        int choice = Convert.ToInt32(Console.ReadLine());
                                                        Console.Beep();
                                                        if (choice == 1)
                                                        {
                                                            Tutors[position].AttendThere(Students[CheckStudent(attname, Students)]);
                                                        }
                                                        else if (choice == 2)
                                                        {
                                                            Teachers[position].AttendAbsent(Students[CheckStudent(attname, Students)]);    //See case 2
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Please choose 1 or 2. Press any key to continue.");
                                                            Console.ReadKey();
                                                            Console.Beep();
                                                            Console.Clear();
                                                        }
                                                    }
                                                    if (CheckStudent(attname, Students) == -1)
                                                    {
                                                        Console.WriteLine("This student doesn't exist");
                                                        Console.WriteLine("Type any key to continue");
                                                    }
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                case 3:
                                                    Console.Clear();
                                                    Console.WriteLine("Which course plan do you want to edit?");
                                                    string namecourse = Console.ReadLine();
                                                    Console.Beep();
                                                    Course course = Courses[CheckCourse(namecourse, Courses)];
                                                    Tutors[position].EditCoursePlan(course);
                                                    Console.WriteLine("Type any key to continue");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                case 4:
                                                    Console.Clear();
                                                    Tutors[position].ToString();
                                                    Console.WriteLine("Type any key to continue");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                case 5:
                                                    Console.Clear();
                                                    Console.WriteLine("Which course do you want to teach ?");
                                                    string namec = Console.ReadLine();
                                                    Tutors[position].TeachACourse(namec, Courses);
                                                    Console.WriteLine("Type any key to continue");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                case 6:
                                                    Console.Clear();
                                                    Console.WriteLine("Which student ? ");
                                                    string sname = Console.ReadLine();
                                                    if (CheckStudent(sname, Students) != -1)         //If the student exists
                                                    {
                                                        Tutors[position].StudentDetail(Students[CheckStudent(sname,Students)]);     //We get the personal informations if the student is in the courses of the tutor (See method)
                                                        Console.WriteLine("Type any key to continue");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("This student doesn't exists");     //If the student doesn't exists, nothing happens
                                                        Console.WriteLine("Type any key to continue");
                                                    }
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                case 7:
                                                    Console.Clear();
                                                    Console.WriteLine("Type in your new adress");
                                                    string nadress = Console.ReadLine();
                                                    Console.Beep();
                                                    Tutors[position].ChangeAdress(nadress);
                                                    Console.WriteLine("Type any key to continue");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                case 8:
                                                    Console.Clear();
                                                    Console.WriteLine("Type in your new password");
                                                    string npass = Console.ReadLine();
                                                    Tutors[position].ChangePassword(npass);
                                                    Console.WriteLine("Type any key to continue");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                case 9:
                                                    goto Start;
                                            }
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.WriteLine("1-Create a course");
                                            Console.WriteLine("2-Create a timetable");
                                            Console.WriteLine("3-Track payment of a student");
                                            Console.WriteLine("4-Add a student");
                                            Console.WriteLine("5-Display your personal informations");           //Case of an admin
                                            Console.WriteLine("6-Change your adress");
                                            Console.WriteLine("7-Change your password");
                                            Console.WriteLine("8-Exit");
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine("In any case, please exit properly from this menu to save your modifications.");
                                            int action = Convert.ToInt32(Console.ReadLine());
                                            Console.Beep();
                                            switch (action)
                                            {
                                                case 1:
                                                    Console.Clear();   //string name, double duration, string coursePlan, FacultyMember prof, string room, List<Student> clas
                                                    Console.WriteLine("Give a name to your course :");
                                                    string name = Console.ReadLine();
                                                    Console.Beep();
                                                    Console.WriteLine("What will be the duration of the course (in hours)? :");
                                                    double duration = Convert.ToDouble(Console.ReadLine());
                                                    Console.Beep();
                                                    Console.WriteLine("Type in your course plan :");
                                                    string courseplan = Console.ReadLine();                                   //Getting all the informations for a ne courses
                                                    Console.Beep();
                                                    Console.WriteLine("In which classroom will the course take place? :");
                                                    string room = Console.ReadLine();
                                                    Console.Beep();
                                                    List<Student> clas = new List<Student>();
                                                    Console.WriteLine("Name a teacher in charge of the course :");
                                                    string tname = Console.ReadLine();
                                                    Console.Beep();
                                                    FacultyMember faculty;
                                                    if (CheckSTeacher(tname, Teachers,Tutors) != -1)                   //If the teachers exists
                                                    {
                                                        faculty = Teachers[CheckSTeacher(tname, Teachers,Tutors)];
                                                        Courses.Add(Admins[position].CreateCourse(name, duration, courseplan, faculty, room, new List<Student>()));      //We create the new course
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("This teacher doesn't exist");              //Else, nothing happens
                                                        Console.WriteLine("Type any key to continue");
                                                        Console.Clear();
                                                    }
                                                    break;
                                                case 2:
                                                    Console.Clear();
                                                    Console.WriteLine("Which student ?");
                                                    string attname = Console.ReadLine();
                                                    Console.Beep();
                                                    if (CheckStudent(attname, Students) != -1)               //If the student exists
                                                    {
                                                        Admins[position].CreateTT(Students[position]);    //A timetable is displayed
                                                    }
                                                    if (CheckStudent(attname, Students) == -1)    //Else
                                                    {
                                                        Console.WriteLine("This student doesn't exist");    //Nothing happens
                                                        Console.WriteLine("Type any key to continue");
                                                    }
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                case 3:
                                                    Console.Clear();
                                                    Console.WriteLine("Which student's payment do you want to track? :");
                                                    string sname = Console.ReadLine();
                                                    Console.Beep();
                                                    if(CheckStudent(sname,Students)!=-1)                                  //If the student exists
                                                    {
                                                        Admins[position].TrackPayment(Students[CheckStudent(sname, Students)]);      //Payments are displayed
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("This student doesn't exist");
                                                        Console.WriteLine("Type any key to continue");             //Else, nothing happens
                                                    }
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                case 4:
                                                    Console.Clear();
                                                    Console.WriteLine("Type in an ID");
                                                    int id = Convert.ToInt32(Console.ReadLine());
                                                    Console.Beep();
                                                    Console.WriteLine("Type in a name");
                                                    string Name = Console.ReadLine();
                                                    Console.Beep();
                                                    Console.WriteLine("Type in a password");             //Getting all the informations to create a new student
                                                    string pasword = Console.ReadLine();
                                                    Console.Beep();
                                                    Console.WriteLine("Type in an adress");
                                                    string adress = Console.ReadLine();
                                                    Console.Beep();
                                                    Console.WriteLine("Type in a phone number");
                                                    string phone = Console.ReadLine();
                                                    Console.Beep();
                                                    Students.Add(Admins[position].AddStudent(Courses, 2, new List<int>(), new List<List<double>>(), new List<bool>(), id, Name, pasword, adress, "26/11/2020",phone));  //Creating a new student
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                case 5:
                                                    Console.Clear();
                                                    Admins[position].ToString();
                                                    Console.WriteLine("Type any key to continue");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                case 6:
                                                    Console.Clear();
                                                    Console.WriteLine("Type in your new adress");
                                                    string nadress = Console.ReadLine();
                                                    Console.Beep();
                                                    Admins[position].ChangeAdress(nadress);
                                                    Console.WriteLine("Type any key to continue");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                case 7:
                                                    Console.Clear();
                                                    Console.WriteLine("Type in your new password");
                                                    string npass = Console.ReadLine();
                                                    Admins[position].ChangePassword(npass);
                                                    Console.WriteLine("Type any key to continue");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                case 8:
                                                    goto Start;
                                            }
                                            break;

                                        }
                                }
                                
                            }
                        }
                        else             //If password is wrong
                        {
                            InvalidPassword();     //Printing 
                            goto Start;               //Log in again
                        }
                    }
                }
                NotRegistered(ID, Students, Teachers, Tutors, Admins);    //If ID is not recognized, printing and go back to Start
            }
        }
    }
}
