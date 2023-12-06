using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BaiTapLon.Models
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
    }
}