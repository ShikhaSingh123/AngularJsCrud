using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AngularJsCrud.Models
{
    public class Utility
    {
        public static string Encryptpassword(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));
            return hashedPassword;
        }

        public static string CheckPassword(string enteredPassword, string hashedPassword)
        {
            bool pwdHash = BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
            if(pwdHash== true)
            {
                return hashedPassword;
            }
             return hashedPassword;
        }
    }
}