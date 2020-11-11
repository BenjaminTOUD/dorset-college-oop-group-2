using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    // 23166 Victor CAZAUX, 23163 Théo UNDERWOOD, 23167 Nicolas GONCALVES, 23206 BENJAMIN TOUBIANA, 23178 FOUCAUD BONNEFONT, 23174 Thomas CULINO
    public abstract class User
    {
        int ID;
        string name;
        private string password;
        private string adress;
        private string inscriptionDate;
        private string phoneNumber;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }

        public string InscriptionDate
        {
            get { return inscriptionDate; }
            set { inscriptionDate = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public bool Login(string passInput)
        {
            return passInput == password;
        }
        public void ChangePassword(string newPass)
        { password = newPass; }
        public void ChangeAdress(string newAdress)
        { adress = newAdress; }

        public override string ToString()
        {
            return $"Student card : Name : {name} Student ID : {ID} Signed up the : {inscriptionDate}";
        }
    }
}
