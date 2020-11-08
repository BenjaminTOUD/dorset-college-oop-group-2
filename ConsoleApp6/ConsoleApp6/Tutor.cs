using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    // 23166 Victor CAZAUX, 23163 Théo UNDERWOOD, 23167 Nicolas GONCALVES, 23206 BENJAMIN TOUBIANA, 23178 FOUCAUD BONNEFONT, 23174 Thomas CULINO
   
    class Tutor
        {
            public List<Course> courseList;

            /*public Tutor(List<Course> courseList, int ID, string name, string password, string adress, string inscriptionDate, string phoneNumber) : base(ID, name, password, adress, inscriptionDate, phoneNumber)
            {
                this.courseList = courseList;
            }
            */
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

}
