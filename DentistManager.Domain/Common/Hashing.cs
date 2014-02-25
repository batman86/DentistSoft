using System;
using System.Security.Cryptography;
using System.Text;

namespace DentistManager.Domain.Common
{
    class Hashing
    {
        public string GetHashedText(string rawTxt)
        {
            byte[] bytRawtxt;
            byte[] bytCrptTxt;
            MD5 md5;

            md5 = new MD5CryptoServiceProvider();
            bytRawtxt = ASCIIEncoding.Default.GetBytes(rawTxt);

            bytCrptTxt = md5.ComputeHash(bytRawtxt);
            return BitConverter.ToString(bytCrptTxt);
        }
    }
}
