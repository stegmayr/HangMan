using System;
using System.Text;

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
                string secretWord = "";

                Console.Write("-----Hang Man-----\n\nThe difficulty levels are:\n1. Easy\n2. Medium\n3. Hard\n\nChoose a difficulty level or type 'q' to quit: ");

                selection = Console.ReadLine();

                switch (selection.ToLower())
                {
                    case "1":
                    case "easy":
                        secretWord = WordPickEasy();
                        break;
                    case "2":
                    case "medium":
                        secretWord = WordPickMedium();
                        break;
                    case "3":
                    case "hard":
                        secretWord = WordPickHard();
                        break;
                    case "q":
                    case "quit":
                        keepGameAlive = false;
                        break;
                    case "easteregg":
                    case "easter egg":
                        Console.WriteLine("The creator of this version of the game Hangman is Alex Stegmayr and he is awesome! ;P");
                        break;
                    default:
                        Console.WriteLine("Thats not a valid option!");
                        break;
                }

                bool win = false;
                int guessesLeft = 10;
                var incorrectGuesses = new StringBuilder();
                char[] correctGuesses = new char[secretWord.Length];


                for (int iCorrectGuesses = 0; iCorrectGuesses < correctGuesses.Length; iCorrectGuesses++)
                {
                    correctGuesses[iCorrectGuesses] = '_';
                }

                Console.Write($"\nYour secret word has been set and we are now ready to start. You have 10 guesses in total to find the word and remember that if you guess for a word it will count as a guess aswell. Letts go!\n\nYou have {guessesLeft} guesses left! \n{String.Join(" ", correctGuesses)}\n\nMake a guess: ");

                do
                {
                    string inputString;
                    char inputChar;


                    inputString = Console.ReadLine().ToUpper().Trim();

                    if (inputString.Length == 0)
                    {
                        Console.WriteLine("Your guess was empty. Try again!");
                        continue;
                    }
                    else if(inputString.Length == 1)
                    {
                        inputChar = inputString[0];

                        bool wasGuessCorrect = TryInputToCorrectGuesses(correctGuesses, secretWord, inputChar);
                        bool oldGuess = TryInputToIncorrectGuesses(incorrectGuesses, inputChar);

                        if(wasGuessCorrect && !oldGuess)
                        {
                            correctGuesses = ChangeCorrectGuessesToInput(correctGuesses, secretWord, inputChar);
                            Console.WriteLine("Your guess was correct.");

                            guessesLeft--;
                        }
                        else if(!oldGuess && !wasGuessCorrect)
                        {
                            incorrectGuesses.Append(inputChar + " ");
                            Console.WriteLine("Your guess was incorrect.");
                            guessesLeft--;
                        }
                        else
                        {
                            Console.WriteLine("You have allready tryed that letter before. Try again!");
                        }                        
                        
                    }
                    else if(secretWord.Equals(inputString))
                    {
                        win = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You guessed a full word and it was incorrect!");
                        guessesLeft--;
                    }

                    if(secretWord.Equals(ArrayToString(correctGuesses)))
                    {
                        win = true;
                        break;
                    }

                    Console.Write($"\nYou have {guessesLeft} guesses left! \n{String.Join(" ", correctGuesses)} and so far you have guessed: {incorrectGuesses}\n\nMake a guess: ");

                } while (guessesLeft > 0);

                if(win)
                {
                    Console.WriteLine($"Congratulations, you won the game! The correct word was {secretWord} and you managed to find that out with {guessesLeft} guesses left. Good for you :)");
                }
                else
                {
                    Console.WriteLine("Game Over! You lost.");
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
            wordList[3] = "NULL";
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

        static bool TryInputToCorrectGuesses(char[] correctGuesses, string secretWord, char inputChar)
        {
            bool guessWasRight = false;

            for (int iCorrectGuesses = 0; iCorrectGuesses < correctGuesses.Length; iCorrectGuesses++)
            {
                if (inputChar == secretWord[iCorrectGuesses])
                {
                    guessWasRight = true;
                    break;
                }
            }

            return guessWasRight;
        }

        static bool TryInputToIncorrectGuesses(StringBuilder incorrectGuesses, char inputChar)
        {
            bool oldGuess = false;

            for(int iIncorrectGuesses = 0; iIncorrectGuesses < incorrectGuesses.Length; iIncorrectGuesses++)
            {
                if(inputChar == incorrectGuesses[iIncorrectGuesses])
                {
                    oldGuess = true;
                    break;
                }
            }

            return oldGuess;
        }

        static char[] ChangeCorrectGuessesToInput(char[] correctGuesses, string secretWord, char inputChar)
        {
            for (int iCorrectGuesses = 0; iCorrectGuesses < correctGuesses.Length; iCorrectGuesses++)
            {
                if (inputChar == secretWord[iCorrectGuesses])
                {
                    correctGuesses[iCorrectGuesses] = inputChar;
                }
            }

            return correctGuesses;
        }

        static string ArrayToString(char[] charArray) // Because Char[].ToString() dosen´t give the value inside the array but pressents the name System.Char[] instead. 
        {
            StringBuilder arrayInStringBuilder = new StringBuilder();

            for(int i = 0; i < charArray.Length; i++)
            {
                arrayInStringBuilder.Append(charArray[i]);
            }

            return arrayInStringBuilder.ToString();
        }

    } // End of class
} // End of namespace
