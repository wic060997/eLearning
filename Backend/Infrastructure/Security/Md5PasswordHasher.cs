using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Security
{
    public class Md5PasswordHasher : IPasswordHasher
    {
        public string Hash(string password)
        {
            return CalculateMD5Hash(password);
        }

        public string Hash(string login, string password)
        {
            return CalculateMD5Hash(login + "." + password);
        }

        private string CalculateMD5Hash(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("x2"));

            string result = sb.ToString();
            return result;
        }
    }
}
