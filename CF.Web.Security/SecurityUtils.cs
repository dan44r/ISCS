using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CF.Web.Security
{
    public class SecurityUtils
    {
        public static string EncryptCode(string input)
        {
            UTF8Encoding utf = new UTF8Encoding();
            byte[] utf8Bytes = utf.GetBytes(input);
            SymmetricAlgorithm algo = SymmetricAlgorithm.Create();
            string code;
            using (MemoryStream ms = new MemoryStream())
            {
                algo.IV = Convert.FromBase64String(ConfigurationManager.AppSettings["IV"]);
                algo.Key = Convert.FromBase64String(ConfigurationManager.AppSettings["Key"]);
                using (CryptoStream cs = new CryptoStream(ms, algo.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(utf8Bytes, 0, utf8Bytes.Length);
                }
                code = Convert.ToBase64String(ms.ToArray(), Base64FormattingOptions.None);
            }
            return code;
        }

        public static string DecryptCode(string input)
        {
            string decryptedCode = null;
            SymmetricAlgorithm algo = SymmetricAlgorithm.Create();
            byte[] cryptoData = null;
            try
            {
                cryptoData = Convert.FromBase64String(input);
            }
            catch (FormatException)
            {

            }
            using (MemoryStream ms = new MemoryStream(cryptoData))
            {
                algo.IV = Convert.FromBase64String(ConfigurationManager.AppSettings["IV"]);
                algo.Key = Convert.FromBase64String(ConfigurationManager.AppSettings["Key"]);

                using (CryptoStream cs = new CryptoStream(ms, algo.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (MemoryStream output = new MemoryStream())
                    {
                        byte[] buffer = new byte[1024];
                        int count = 0;

                        while ((count = cs.Read(buffer, 0, 1024)) != 0)
                        {
                            output.Write(buffer, 0, count);
                        }
                        UTF8Encoding utf = new UTF8Encoding();
                        decryptedCode = utf.GetString(output.ToArray());
                    }

                    cs.Close();
                }
            }
            return decryptedCode;
        }

        public static string ConvertStringToInt(string input)
        {
            StringBuilder output = new StringBuilder();
            foreach (char i in input)
            {
                output.Append(Convert.ToInt32(i).ToString());
                output.Append("-");
            }
            return output.ToString();
        }

        public static string ConvertIntToString(string code)
        {
            StringBuilder userId = new StringBuilder();
            char[] splitter = { '-' };
            string[] codes = code.Split(splitter, StringSplitOptions.RemoveEmptyEntries);

            foreach (string intCode in codes)
            {
                userId.Append(Convert.ToChar(Convert.ToInt32(intCode)).ToString());
            }

            return userId.ToString();
        }

        public static string UrlEncode(string url)
        {
            try
            {
                url = SecurityUtils.ConvertStringToInt(SecurityUtils.EncryptCode(url));
            }
            catch
            {

            }
            return url;
        }

        public static string UrlDecode(string url)
        {
            try
            {
                url = SecurityUtils.DecryptCode(SecurityUtils.ConvertIntToString(url));
            }
            catch
            {
                throw;
            }
            return url;
        }
    }


}
