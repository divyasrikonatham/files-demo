using System;
using System.IO;
using System.Text.RegularExpressions;

namespace FilesDemo

{
    class Program

    {
        public static bool ValidateInputString(string inputString)

        {
            Regex regex = new Regex("[!@#$%^&*]");
            bool hasSpecialChars = regex.IsMatch(inputString);
            if (hasSpecialChars == true)
            {

                return false;
            }

            else
            {

                return true;
            }
        }

        public static int FindWordCount(string inputString)

        {
            string pattern = "[^\\w]";
            string[] words = null;
            int i = 0, wordCount = 0;
            words = Regex.Split(inputString, pattern, RegexOptions.IgnoreCase);
            for (i = words.GetLowerBound(0); i <= words.GetUpperBound(0); i++)
            {
                if (words[i].ToString() == string.Empty)
                    wordCount = wordCount - 1;
                wordCount = wordCount + 1;
            }

            return wordCount;
        }

        public static int FindPalindromeCount(string inputString)

        {
            int count = 0;
            string[] words = inputString.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 1)
                {
                    char[] charArray = words[i].ToCharArray();
                    Array.Reverse(charArray);
                    if (new string(charArray) == words[i])
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public static void WriteFileToPath(string inputString)

        {
            string fileName = @"D:user_input.txt";
            try

            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    sw.WriteLine("{0}", inputString);
                }
            }
            catch

            {
                Console.WriteLine("Given Path not found to create file");
            }
        }

        public static void Main(string[] args)
        {

            Console.WriteLine("Please enter atleast 500 words description ");
            string str = Console.ReadLine();
            if (ValidateInputString(str))
            {
                Console.WriteLine("Number of words in the description is {0}", FindWordCount(str));
                Console.WriteLine("Number of palindromes in the description is {0}", FindPalindromeCount(str));
                WriteFileToPath(str);
            }

            else
            {
                Console.WriteLine("Please re-enter 500 words description without any of the !@#$%^&* special characters");
            }
            Console.WriteLine("Enter any key to exit");
            Console.ReadKey();
        }
    }
}




