using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    // 23166 Victor CAZAUX, 23163 Théo UNDERWOOD, 23167 Nicolas GONCALVES, 23206 BENJAMIN TOUBIANA, 23178 FOUCAUD BONNEFONT, 23174 Thomas CULINO
    class Tutor : FacultyMember
    {
        public List<Course> courseList;
        public Tutor(List<Course> courseList) : base(courseList)
        {
            this.courseList = courseList;
        }
        public int[] IsStudent(Student student)
        {
            int[] result = new int[2];
            result[0] = -1;
            result[1] = -1;
            for (int i = 0; i < this.courseList.Count; i++)
            {
                for (int j = 0; j < courseList[i].clas.Count; j++)
                {
                    if (courseList[i].clas[j] == student)
                    {
                        result[0] = i;
                        result[1] = j;
                        break;
                    }
                }

            }
            return result;
        }
        public void StudentDetail(Student student)
        {
            if (IsStudent(student)[0] == -1)
            {
                Console.WriteLine("This student is not in any of your courses");
            }
            else
            {
                int i = IsStudent(student)[0];
                int j = IsStudent(student)[1];
                Console.WriteLine("ID : " + courseList[i].clas[j].ID + ", Name: " + courseList[i].clas[j].Name + ", Adress : " + courseList[i].clas[j].Adress + ", Phone : " + courseList[i].clas[j].PhoneNumber);
            }

        }
    }

}
