/* DESIGNER: Claudinei Pereira de Sousa (100647340)
   EXERCISE: Assignment 02
   TASK: Doonut Website - ASP.NET MVC Project */

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