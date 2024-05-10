using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Account_DAL
    {
        private static int codeOTP;
        #region xác nhận email
        public static bool SendCodeConfirm(string email)
        {
            try
            {
                codeOTP = new Random().Next(100000, 999999);
                string pass = "eyrbwcujqkfethzh";

                MailMessage message = new MailMessage();
                message.To.Add(email);
                message.From = new MailAddress("ptienanh19@gmail.com");
                message.Subject = "XÁC NHẬN EMAIL ĐĂNG KÍ TÀI KHOẢN CUSTOMER BÀI GIỮ XE KHÉP KÍN (TEST)";
                message.Body = "OTP CỦA BẠN LÀ : " + codeOTP;

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("ptienanh19@gmail.com", pass)
                };
                smtp.Send(message);
                return true;
            }
            catch
            {
                return false; // gửi không thành công
            }
        }
        public static bool ConFirmCode(string code)
        {
            return (code == codeOTP + "");
        }
        public static bool CheckEmail (string email)
        {
            string querry = $"SELECT COUNT(*) FROM [Account] WHERE Email = N'{email}'";
            return MyDB.ExecuteScalar(querry) != 0; // nếu tài khoản không tồn tại thì return false và ngược lại  
        }
        #endregion 
        private static List<Account_DTO> GetAccounts (DataTable dt)
        {
            List<Account_DTO> accounts = new List<Account_DTO> ();
            foreach (DataRow dr in dt.Rows)
            {
                string userName = dr[0].ToString();
                string email = dr[1].ToString();    
                string idUser = dr[3].ToString();
                string typeUser = dr[4].ToString();
                accounts.Add(new Account_DTO(userName,email,idUser,typeUser));
            }
            return accounts;
        }
        public static Account_DTO GetAccouts (string idUser,string typeUser)
        {
            string querry = $"SELECT * FROM [ACCOUNT] WHERE idUser = N'{idUser}' AND typeUser = N'{typeUser}'";
            return GetAccounts(MyDB.GetDataTable(querry))[0];
        }
        public static Account_DTO ProcessLogin(Account_DTO account)
        {
            string querry = $"SELECT * FROM [Account] WHERE USERNAME = N'{account.UserName}' AND PASSWORD = N'{account.Password}'";
            var AccoutLst = GetAccounts(MyDB.GetDataTable(querry));
            if (AccoutLst.Count == 0)
                return null;
            return AccoutLst[0];
        }
        public static bool InsertAccount(Account_DTO newAccount)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "INSERT INTO [Account] VALUES (@USERNAME, @EMAIL, @PASSWORD, @IDUSER, @TYPEUSER)";
            sqlCommand.Parameters.AddWithValue("@USERNAME", newAccount.UserName);
            sqlCommand.Parameters.AddWithValue("@EMAIL", newAccount.Email);
            sqlCommand.Parameters.AddWithValue("@PASSWORD", newAccount.Password);
            sqlCommand.Parameters.AddWithValue("@IDUSER", newAccount.IdUser);
            sqlCommand.Parameters.AddWithValue("@TYPEUSER", newAccount.TypeUser);
            return MyDB.ExecuteNonQuery(sqlCommand);
        }
        public static bool DeleteAccount(Account_DTO account)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "DELETE FROM [ACCOUNT] WHERE UserName = @UserName";
            sqlCommand.Parameters.AddWithValue("@UserName", account.UserName);
            return MyDB.ExecuteNonQuery(sqlCommand);
        }
        public static bool ChangePassword (Account_DTO account)
        {
            string querry = $"UPDATE [ACCOUNT] SET PASSWORD = '{account.Password}' WHERE EMAIL = '{account.Email}'";
            return MyDB.ExecuteNonQuery(querry);
        }
    }
}
