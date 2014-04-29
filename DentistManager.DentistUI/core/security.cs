using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace DentistManager.DentistUI.core
{
    public class security
    {
        string a = "kjahdfoaidhaidhadlakndaldknadlakndlandawkdugabflkanfa";
        public void mainCreate()
        {

            generatKey();

            byte[] thekey = readKey();

            string encText = encryptData(a);

            using (FileStream fs = new FileStream(HttpContext.Current.Request.MapPath(@"~\core\text.config"), FileMode.Create))
            {
                byte[] aa = GetBytes(encText);
                fs.Write(aa, 0, aa.Length);
                fs.Close();
            }
        }


        public bool mainInLogin()
        {
            try
            {
                byte[] thekey = readKey();
            string theText= GetString(readtext());

            string decText = decryptData(theText);

            if (a == decText)
                return true;
            else
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }


        public void generatKey()
        {
            SymmetricAlgorithm sym = SymmetricAlgorithm.Create("Rijndael");
            sym.GenerateKey();
            byte[] key = sym.Key;
            key = ProtectedData.Protect(key, null, DataProtectionScope.LocalMachine);
            using (FileStream fs = new FileStream(HttpContext.Current.Request.MapPath(@"~\core\Key.config"), FileMode.Create))
            {
                fs.Write(key, 0, key.Length);
                fs.Close();
            }
        }

        private byte[] readtext()
        {
            byte[] key;

            using (FileStream fs = new FileStream(HttpContext.Current.Request.MapPath(@"~\core\text.config"), FileMode.Open))
            {
                key = new byte[fs.Length];
                fs.Read(key, 0, (int)fs.Length);
                fs.Close();
            }
           // key = ProtectedData.Unprotect(key, null, DataProtectionScope.LocalMachine);

            return key;
        }

        private byte[] readKey()
        {
            byte[] key;

                using (FileStream fs = new FileStream(HttpContext.Current.Request.MapPath(@"~\core\Key.config"), FileMode.Open))
                {
                    key = new byte[fs.Length];
                    fs.Read(key, 0, (int)fs.Length);
                    fs.Close();
                }
                key = ProtectedData.Unprotect(key, null, DataProtectionScope.LocalMachine);

                return key;
            
        }
        public string encryptData(string rawData)
        {
            SymmetricAlgorithm sym = SymmetricAlgorithm.Create("rijndael");
            sym.Key = readKey();
            sym.Key = readKey();
            byte[] clearData = Encoding.UTF8.GetBytes(rawData);
            MemoryStream mem = new MemoryStream();

            sym.GenerateIV();
            mem.Write(sym.IV, 0, sym.IV.Length);


            CryptoStream cs = new CryptoStream(mem, sym.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(clearData, 0, clearData.Length);
            cs.FlushFinalBlock();
            cs.Close();
            string creptedata = Convert.ToBase64String(mem.ToArray());
            mem.Close();
            return creptedata;
        }


        public string decryptData(string crypteData)
        {
            SymmetricAlgorithm sym = SymmetricAlgorithm.Create("rijndael");
            sym.Key = readKey();
            byte[] crepdata = Convert.FromBase64String(crypteData);
            int ivst = 0;
            byte[] iv = new byte[sym.IV.Length];
            Array.Copy(crepdata, iv, iv.Length);
            sym.IV = iv;
            ivst += sym.IV.Length;

            MemoryStream mem = new MemoryStream();
            CryptoStream cs = new CryptoStream(mem, sym.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(crepdata, ivst, (crepdata.Length - ivst));
            cs.FlushFinalBlock();
            cs.Close();

            string cleartxt = Encoding.UTF8.GetString(mem.ToArray());
            mem.Close();
            return cleartxt;
        }
    }
}