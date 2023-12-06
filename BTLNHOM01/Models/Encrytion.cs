using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BTLNHOM01.Models
{
    public class Encrytion
    {
        [Obsolete]
        public string PasswordEncrytion(string pass)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(pass.Trim(), "MD5");
        }

    }

    internal class FormsAuthentication
    {
        internal static string HashPasswordForStoringInConfigFile(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        internal static void SetAuthCookie(string userName, bool v)
        {
            throw new NotImplementedException();
        }

        internal static void SignOut()
        {
            throw new NotImplementedException();
        }
    }
}