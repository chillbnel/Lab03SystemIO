using System;
using System.IO;
using System.Text;

namespace Lab03SystemIO
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../myfile.txt";
            CreateFile(path);
            AppendToFile(path);
        }

        static string MainMenu()
        {
            string userEntry;

            Console.WriteLine("Welcome the Guessing Game, Please select from the following:\n" +
                "MAIN MENU\n" +
                "1. Play!" +
                "2. Add a new word" +
                "3. See all words" +
                "4. Exit\n" +
                "Enter 1, 2, 3, or 4 to continue");

            userEntry = Console.ReadLine();

            return userSelect;
        }

        static void CreateFile(string path)
        {
            try
            {
                using (FileStream fs = File.Create(path))
                {
                    Byte[] myWords = new UTF8Encoding(true).GetBytes("Hello Brian!");
                    fs.Write(myWords, 0, myWords.Length);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        static string[] ReadFile(string path)
        {
            try
            {
                string[] myWords = File.ReadAllLines(path);
                return myWords;
            }
            catch (Exception)
            {
                throw;
            }
        }

        static void AppendToFile(string path)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    for (int i = 1; i < 6; i++)
                    {
                        sw.WriteLine(i);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        static void DeleteLineFromFile(string path, string lineToRemove)
        {
            string[] currentWords = ReadFile(path);
            string[] newWords = new string[currentWords.Length - 1];
            for (int i = 0; i <currentWords.Length; i++)
            {
                if (lineToRemove == currentWords[i])
                {

                }
            }
        }
            
            

    }
}
