using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    // 23166 Victor CAZAUX, 23163 Théo UNDERWOOD, 23167 Nicolas GONCALVES, 23206 BENJAMIN TOUBIANA, 23178 FOUCAUD BONNEFONT, 23174 Thomas CULINO
   
    
 class Tutor:FacultyMember         //This class inherit from FacultyMember, which is already inherited from user
        {
            public List<Course> courseList;        //Represent the list of courses that the Faculty member can teach

            public Tutor(List<Course> courseList, int ID, string name, string password, string adress, string inscriptionDate, string phoneNumber) : base(ID, name, password, adress, inscriptionDate, phoneNumber)     //Constructor
            {
                this.courseList = courseList;
            }
            
            public int[] IsStudent(Student student)   //Check if the student is a class of the tutor
            {
                int[] result = new int[2];
                result[0] = -1;
                result[1] = -1;                                   // A vector is initialized at -1;-1 . It will be the result if the student is not in the tutor's list
                for (int i = 0; i < this.courseList.Count; i++)
                {
                    for (int j = 0; j < courseList[i].clas.Count; j++)     //Going all the way through the students of the tutor
                    {
                        if (courseList[i].clas[j] == student)             //If the student appears in a class
                        {
                            result[0] = i;
                            result[1] = j;                   //We get the coordinate of him in the files
                            break;
                        }
                    }

                }
                return result;
            }

            public void StudentDetail(Student student)           //To get personal details of a student
            {
                if (IsStudent(student)[0] == -1)                //Checking if the student is in a class of the tutor
                {
                    Console.WriteLine("This student is not in any of your courses");
                }
                
                else
                {
                    int i = IsStudent(student)[0];
                    int j = IsStudent(student)[1];                      //If we find him in a class
                    Console.WriteLine("ID : " + courseList[i].clas[j].ID + ", Name: " + courseList[i].clas[j].Name + ", Adress : " + courseList[i].clas[j].Adress + ", Phone : " + courseList[i].clas[j].PhoneNumber);        //Printing the personal details of the student
                }

            }
        }
}
