using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_projet
{
    public abstract class User //User is abstract - it can only be created as a Student, Tutor, Admin, or FacultyMember
    {                          //There fore it has no constructor.
                               //Attributes, things common to all Users - clear and simple attribute names
        #region Attributes                     
        public int ID;
        public string name;
        public string password;
        public string adress;
        public string inscriptionDate;
        public string phoneNumber;
        #endregion
        //Public Properties for User to work in tandem with its inherited classes
        //only get. Sets are handled through methods for some attributes only
        #region Properties
        public string Name
        {
            get { return name; }

        }

        public string Adress
        {
            get { return adress; }
        }

        public string InscriptionDate
        {
            get { return inscriptionDate; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
        }

        public User(int ID, string name, string password, string adress, string inscriptionDate, string phoneNumber)
        {
            this.ID = ID;
            this.name = name;
            this.password = password;
            this.adress = adress;
            this.inscriptionDate = inscriptionDate;
            this.phoneNumber = phoneNumber;
        }
        #endregion
        //User-wide methods
        #region Methods
        public bool Login(string passInput) //Simple logging in attempt - will return false if the input is different to the registered password
        {
            return passInput == password;
        }
        public void ChangePassword(string newPass) //Changes the password attribute into the input string
        { password = newPass; }
        public void ChangeAdress(string newAdress) //Changes the adresss attribute into the input string
        { adress = newAdress; }

        public override string ToString() //User-Wide ToString method - Only outputs User available data, without phone number and adress
        {
            return $"User card : Name : {name} Student ID : {ID} Signed up the : {inscriptionDate}";
        }

        #endregion
    }

}
