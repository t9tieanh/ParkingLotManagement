using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Account_DTO
    {
        private string userName;
        private string email;
        private string password;
        private string idUser;
        private string typeUser;
        public Account_DTO(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
        public Account_DTO(string userName, string email, string password, string idUser, string typeUser)
        {
            UserName = userName;
            Email = email;
            Password = password;
            IdUser = idUser;
            TypeUser = typeUser;
        }
        public Account_DTO(string userName, string email, string idUser, string typeUser)
        {
            UserName = userName;
            Email = email;
            IdUser = idUser;
            TypeUser = typeUser;
        }
        public string UserName { get => userName; set => userName = value; }
        public string Email { get => email; set => email = value; }
        public string Password
        {
            get => password;
            set
            {
                password = "";
                byte[] temp = ASCIIEncoding.ASCII.GetBytes(value);
                byte[] hasdata = new MD5CryptoServiceProvider().ComputeHash(temp);
                foreach (byte b in hasdata)
                {
                    this.password += b;
                }
            }
        }
        public string IdUser { get => idUser; set => idUser = value; }
        public string TypeUser { get => typeUser; set => typeUser = value; }
    }
}
