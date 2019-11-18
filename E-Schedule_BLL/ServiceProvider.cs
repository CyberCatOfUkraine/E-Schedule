using System;
using System.Text;
using System.Security.Cryptography;

namespace E_Schedule_BLL
{
    static class ServiceProvider
    {
        public static string EncryptString(string str)
        {
            using (var sha1 = SHA1.Create())
            {
                byte[] hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(str));

                return Encoding.UTF8.GetString(hashBytes);
            }
        }

        public static string CreateLogin(string name, string surname)
        {
            return name + surname;
        }

        public static string RandomStringGenerator(int length = 10)
        {
            const string baseStr = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

            StringBuilder res = new StringBuilder();
            Random r = new Random();

            while (0 < length--)
            {
                res.Append(baseStr[r.Next(baseStr.Length)]);
            }

            return res.ToString();
        }
    }
}