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
            MainMenu(path);
            //ReadFile(path);
        }

        static void MainMenu(string path)
        {
            string userEntry;

            Console.WriteLine("Welcome the Guessing Game, Please select from the following:\n" +
                "MAIN MENU\n" +
                "1. Play!\n" +
                "2. Add a new word\n" +
                "3. Remove a word\n" +
                "4. Exit\n" +
                "Enter 1, 2, 3, or 4 to continue");

            userEntry = Console.ReadLine();

            MenuSelect(userEntry, path);
        }

        static void MenuSelect(string userEntry, string path)
        {
            int userEntryInt = 0;

            if (int.TryParse(userEntry, out userEntryInt))
            {
                switch (userEntryInt)
                {
                    case 1:
                        Console.Clear();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Please enter a new word: ");
                        string newWord = Console.ReadLine();
                        AppendToFile(path, newWord);
                        break;

                    case 3:
                        Console.Clear();
                        ReadFile(path);
                        Console.WriteLine("Please enter the # of the word you would like to remove: ");
                        string removeWord = Console.ReadLine();
                        DeleteLineFromFile(path, removeWord);
                        Console.ReadLine();
                        break;

                    default:
                        break;
                }
            }

            Console.Clear();
            MainMenu(path);
        }

        static void CreateFile(string path)
        {
            try
            {
                using (FileStream fs = File.Create(path))
                {
                    Byte[] myWords = new UTF8Encoding(true).GetBytes("Brian\nMicrosoft\ncodefellows");
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

                for (int i = 0; i < myWords.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + myWords[i]);
                }

                return myWords;
            }
            catch (Exception)
            {
                throw;
            }
        }

        static void AppendToFile(string path, string newWord)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                try
                {

                    sw.WriteLine("\n" + newWord);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    sw.Close();
                }
            }
            ReadFile(path);
        }

        static void DeleteLineFromFile(string path, string lineToRemove)
        {
            string[] myWords = File.ReadAllLines(path);

            int lineToRemoveInt = 0;

            if (int.TryParse(lineToRemove, out lineToRemoveInt))
            {
               Console.WriteLine(myWords[lineToRemoveInt - 1]);
            }

        }
            
            

    }
}
