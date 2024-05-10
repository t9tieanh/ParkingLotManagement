using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InputCheck
{
    public class CheckInput
    {
        public static bool Name(string name)
        {
            /// Regex pattern for valid name (only letters including Unicode characters and spaces)
            string pattern = "^[\\p{L} ]+$";

            // Check if the name matches the pattern
            if (Regex.IsMatch(name, pattern))
            {
                return true;
            }
            return false;
        }
        // Kiểm tra biển số xe ô tô
        // Kiểm tra biển số xe chỉ bao gồm chữ số và chữ cái viết hoa
        public static bool IsValidLicensePlate(string plateNumber)
        {
            // Regex pattern: Chỉ chấp nhận chữ số và chữ cái viết hoa, không có ký tự đặc biệt hoặc khoảng trắng
            string pattern = @"^[A-Z0-9]+$";
            return Regex.IsMatch(plateNumber, pattern);
        }
        // Kiểm tra số điện thoại hợp lệ, chỉ chấp nhận chữ số
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            // Regex pattern: Chấp nhận 10 chữ số (định dạng điện thoại tiêu chuẩn không có dấu)
            string pattern = @"^\d{10}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }
        public static bool IsValidUsername(string username)
        {
            // Regex pattern: Chỉ chấp nhận chữ số (0-9) và chữ cái (a-z, A-Z)
            string pattern = @"^[a-zA-Z0-9]+$";
            return Regex.IsMatch(username, pattern);
        }

        public static bool IsDouble (string s)
        {
            double result;
            return double.TryParse(s, out result);
        }
        public static bool IsInteger(string s)
        {
            int result;
            return int.TryParse(s, out result);
        }

        public static bool DoubleIsValid(string score)
        {
            return score != "" && Regex.IsMatch(score, @"^[-?\d+\.\d+]+$");
        }


        public static bool NumberIsValid(string phone)
        {
            return phone != "" && Regex.IsMatch(phone, @"^[0-9]+$");
        }
        public static bool AgeIsValid(DateTime birthday)
        {
            if (birthday.ToString() == "")
            {
                return false;
            }
            int age = DateTime.Now.Year - birthday.Year;
            if (birthday > DateTime.Now)
            {
                return false;
            }

            return age >= 18 && age <= 150;
        }

        public static bool AddressIsValid(string address)
        {
            /// Regex pattern for valid name (only letters including Unicode characters and spaces)
            string pattern = "^[\\p{L} ]+$";

            // Check if the name matches the pattern
            if (Regex.IsMatch(address, pattern))
            {
                return true;
            }
            return false;
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
