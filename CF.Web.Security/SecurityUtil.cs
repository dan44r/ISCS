using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace CF.Web.Security
{
    public static class SecurityUtil
    {
        //ASCII character set ranges
        static int[][] characterSets = new int[][]{
            new int[] {48, 57},
            new int[] {65, 90},
            new int[] {97, 122}
        };

        //Prevents swear words (or any words) from being generated
        static Regex vowelRemover = new Regex("[AEIOUaeiou]");

        public static string GeneratePassword(int passwordLength)
        {
            //Generate strong random seeds for the Random class to use as a seed
            RNGCryptoServiceProvider seedGenerator = new RNGCryptoServiceProvider();
            int characterRandSeed, charsetRandSeed;
            byte[] seedByte = new byte[1];

            /*
             * Add the generated seed number to the current millisecond otherwise to increase (greatly increase) 
             * the number of possible generated passwords
             */
            seedGenerator.GetBytes(seedByte);
            characterRandSeed = DateTime.Now.Millisecond + (int)seedByte[0];

            seedGenerator.GetBytes(seedByte);
            charsetRandSeed = DateTime.Now.Millisecond + (int)seedByte[0];

            Random characterRand = new Random(characterRandSeed),
                charsetRand = new Random(charsetRandSeed);
            char[] password = new char[passwordLength];

            for (int i = 0; i < passwordLength; i++)
            {
                int charset = charsetRand.Next(0, 3);//Rand will never? return the maximum value in range.
                if (charset == 3) charset--;//But just in case...
                char? passwordChar = null;

                //Check for vowels, this avoids having undesirable words appearing in your passwords
                while (passwordChar == null || vowelRemover.IsMatch(passwordChar.Value.ToString()))
                {
                    passwordChar = (char)characterRand.Next(characterSets[charset][0], characterSets[charset][1]);
                }

                password[i] = passwordChar.Value;
            }

            return new string(password);
        }

        
    }
}