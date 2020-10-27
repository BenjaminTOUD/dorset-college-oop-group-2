namespace Project
{
    public abstract class User
    {
        int ID;
        string name;
        private string password;
        private string adress;
        private string inscriptionDate;
        private string phoneNumber;
        
        public void Login()
        {}
        public void ChangePassword()
        {}
        public void ChangeAdress()
        {}

        public override string ToString() //Ne pas afficher le password
        {
            return password;
        }
    }
}