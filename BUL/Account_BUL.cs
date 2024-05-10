using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class Account_BUL
    {
        public static bool SendCodeConfirm(string email)
        {
            return Account_DAL.SendCodeConfirm(email);  
        }
        public static bool ConFirmCode(string code)
        {
            return Account_DAL.ConFirmCode(code);
        }
        /// <summary>
        /// // nếu tài khoản không tồn tại thì return false và ngược lại  
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool CheckEmail(string email)
        {
            return Account_DAL.CheckEmail(email);
        }
        public static Account_DTO ProcessLogin(Account_DTO account)
        {
            return DAL.Account_DAL.ProcessLogin(account);
        }
        public static bool InsertAccount(Account_DTO newAccount)
        {
            return DAL.Account_DAL.InsertAccount(newAccount);
        }
        public static bool DeleteAccount(Account_DTO account)
        {
            return DAL.Account_DAL.DeleteAccount(account);
        }
        public static bool ChangePassword(Account_DTO account)
        {
            return Account_DAL.ChangePassword (account);
        }

    }
}
