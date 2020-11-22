using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    // 23166 Victor CAZAUX, 23163 Théo UNDERWOOD, 23167 Nicolas GONCALVES, 23206 BENJAMIN TOUBIANA, 23178 FOUCAUD BONNEFONT, 23174 Thomas CULINO
    public abstract class User //User is abstract - it can only be created as a Student, Tutor, Admin, or FacultyMember
    {                          //There fore it has no constructor.
        //Attributes, things common to all Users - clear and simple attribute names
        #region Attributes                     
        int ID;                 
        string name;
        private string password;
        private string adress;
        private string inscriptionDate;
        private string phoneNumber;
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
            return $"Student card : Name : {name} Student ID : {ID} Signed up the : {inscriptionDate}";
        }

		#endregion
	}
}
