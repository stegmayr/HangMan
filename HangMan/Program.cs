using System;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepGameAlive = true;

            while(keepGameAlive)
            {
                string selection;
                string wordString = "";

                Console.Write("-----Hang Man-----\n\nThe difficulty levels are:\n1. Easy\n2. Medium\n3. Hard\n\nChose a difficulty level or type 'q' to quit: ");

                selection = Console.ReadLine();

                switch (selection.ToLower())
                {
                    case "1":
                    case "easy":
                        wordString = WordPickEasy();
                        break;
                    case "2":
                    case "medium":
                        wordString = WordPickMedium();
                        break;
                    case "3":
                    case "hard":
                        wordString = WordPickHard();
                        break;
                    case "q":
                    case "quit":
                        keepGameAlive = false;
                        break;
                    case "easter egg":
                        Console.WriteLine("The creator of this version of the game Hangman is Alex Stegmayr and he is awesome! ;P");
                        break;
                    default:
                        Console.WriteLine("Thats not a valid option!");
                        break;
                }

                char[] wordArray = new char[wordString.Length];

                for (int iWordArray = 0; iWordArray < wordArray.Length; iWordArray++)
                {
                    Console.Write('*');
                }

                Console.WriteLine();
                Console.ReadKey();
                Console.Clear();

            }

        }
        static string WordPickEasy()
        {
            string[] wordList = new string[10];
            wordList[0] = "CAT";
            wordList[1] = "AIR";
            wordList[2] = "HAPPY";
            wordList[4] = "DRUM";
            wordList[5] = "KISS";
            wordList[6] = "LOVE";
            wordList[7] = "HATT";
            wordList[8] = "DANCE";
            wordList[9] = "SNOW";

            Random randomWordPick = new Random();
            int iWordList = randomWordPick.Next(wordList.Length);

            string wordString = wordList[iWordList];

            return wordString;
        }

        static string WordPickMedium()
        {
            string[] wordList = new string[10];
            wordList[0] = "MONKEY";
            wordList[1] = "BREEZE";
            wordList[2] = "MEMORY";
            wordList[3] = "HAPPILY";
            wordList[4] = "PINEAPPLE";
            wordList[5] = "PROMISED";
            wordList[6] = "POSITIVE";
            wordList[7] = "SHALLOW";
            wordList[8] = "GARAGE";
            wordList[9] = "REQUIRE";

            Random randomWordPick = new Random();
            int iWordList = randomWordPick.Next(wordList.Length);

            string wordString = wordList[iWordList];

            return wordString;
        }

        static string WordPickHard()
        {
            string[] wordList = new string[11];
            wordList[0] = "JAZZ";
            wordList[1] = "IVY";
            wordList[2] = "PIXEL";
            wordList[3] = "ONYX";
            wordList[4] = "SHIV";
            wordList[5] = "UNZIP";
            wordList[6] = "TOPAZ";
            wordList[7] = "ZIPPER";
            wordList[8] = "VOODOO";
            wordList[9] = "WAXY";
            wordList[10] = "JINX";

            Random randomWordPick = new Random();
            int iWordList = randomWordPick.Next(wordList.Length);

            string wordString = wordList[iWordList];

            return wordString;
        }

    } // End of class
} // End of namespace
