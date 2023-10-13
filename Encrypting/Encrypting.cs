using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;


namespace _100647340PereiraDeSousaA2.Encrypting
{
    public class Encrypting
    {
        public string Encrypt(string pw)
        {
            //Encrypting the password: Method 
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF32Encoding utf = new UTF32Encoding();
                byte[] data = md5.ComputeHash(utf.GetBytes(pw));
                return Convert.ToBase64String(data);
            }
        }

    }
}