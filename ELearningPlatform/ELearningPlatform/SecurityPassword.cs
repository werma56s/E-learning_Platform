using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace ELearningPlatform
{
    public class SecurityPassword
    {
        public static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        public static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
        {
            // Hash the input.
            var hashOfInput = GetHash(hashAlgorithm, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0;
        }
        //Validation  password
        public static string ErrorMessage = string.Empty;
        public static bool CheckPassword(string text)
        {
            ErrorMessage = string.Empty;
            string[] numSet = new string[] { @"1-9" };
            string[] charSet = new string[] { "a-zA-Z" };

            int lenghtPass = text.Length;
            if (lenghtPass >= 7 && lenghtPass <= 40)
            {
                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasLowerChar = new Regex(@"[a-z]+");
                var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

                if (!hasLowerChar.IsMatch(text))
                {
                    ErrorMessage = "Password should contain At least one lower case letter";
                    return false;
                }
                else if (!hasUpperChar.IsMatch(text))
                {
                    ErrorMessage = "Password should contain At least one upper case letter";
                    return false;
                }
                else if (!hasNumber.IsMatch(text))
                {
                    ErrorMessage = "Password should contain At least one numeric value";
                    return false;
                }
                else if (!hasSymbols.IsMatch(text))
                {
                    ErrorMessage = "Password should contain At least one special case characters";
                    return false;
                }
                else
                {
                    return true;
                }

            }
            else
            {
                ErrorMessage = "Password is too short";
                return false;
            }
        }
    }
}
