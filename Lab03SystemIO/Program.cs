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
        }

        /// <summary>
        /// Method used to display the game's main menu
        /// </summary>
        /// <param name="path">path to word file</param>
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

        /// <summary>
        /// Method used to take the user's menu input and call corresponding method
        /// </summary>
        /// <param name="userEntry">Menu item selected</param>
        /// <param name="path">path to word file</param>
        static void MenuSelect(string userEntry, string path)
        {
            int userEntryInt = 0;

            if (int.TryParse(userEntry, out userEntryInt))
            {
                switch (userEntryInt)
                {
                    case 1:
                        Console.Clear();
                        Game(path);
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
                        Console.WriteLine("Please enter the word you would like to remove: ");
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

        /// <summary>
        /// Method creates the file that stores words to guess
        /// </summary>
        /// <param name="path">path to word file</param>
        static void CreateFile(string path)
        {
            try
            {
                using (FileStream fs = File.Create(path))
                {
                    Byte[] myWords = new UTF8Encoding(true).GetBytes("Brian\nMicrosoft\ncodefellows\n");
                    fs.Write(myWords, 0, myWords.Length);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Method execute's the game code
        /// </summary>
        /// <param name="path">path to word file</param>
        static void Game(string path)
        {
            string[] myWords = File.ReadAllLines(path);

            
            for (int i = 0; i < myWords[1].Length; i++)
            {
                Console.Write("_ ");
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Reads all lines in the words file
        /// </summary>
        /// <param name="path">path to word file</param>
        /// <returns>all words stored in file</returns>
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

        /// <summary>
        /// Method adds a word to the file
        /// </summary>
        /// <param name="path">path to word file</param>
        /// <param name="newWord">word to be added</param>
        public static bool AppendToFile(string path, string newWord)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                try
                {

                    sw.WriteLine(newWord);
                    return true;
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
        }

        /// <summary>
        /// Method deletes word from the file
        /// </summary>
        /// <param name="path">path to word file</param>
        /// <param name="lineToRemove">index of word to be removed</param>
        static void DeleteLineFromFile(string path, string lineToRemove)
        {
            string[] myWords = File.ReadAllLines(path);
            string[] newMyWords = new string[myWords.Length - 1];
            int index = 0;

            for (int i = 0; i < myWords.Length; i++)
            {
                if(lineToRemove == myWords[i])
                {
                    continue;
                }
                else
                {
                    newMyWords[index] = myWords[i];
                    index++;
                }
            }
            File.WriteAllLines(path, newMyWords);
        }
    }
}
