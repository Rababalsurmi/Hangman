using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            bool running = true;
            int userInput;
            int live = 10;

            Console.WriteLine(" This is the Hangman Game!");
            Console.WriteLine(" ------------------------");
            Console.WriteLine();

            string[] words = new string[10];
            words[0] = "glass";
            words[1] = "blomma";
            words[2] = "dator";
            words[3] = "hund";
            words[4] = "bil";
            words[5] = "utbildning";
            words[6] = "kunskap";
            words[7] = "sommar";
            words[8] = "stad";
            words[9] = "spel";

            Random generate = new Random();
            var i = generate.Next(0, 9);
            string winningword = words[i];
            List<string> letterGuessed = new List<string>();

            Console.WriteLine("To win, you need to guess the word in swedish!");
            Console.WriteLine();
            Console.WriteLine("You have {0} lives...", live);
            Console.WriteLine();



            while (running)
            {
                Console.WriteLine("Do you want to Exit? 1 for Yes");
                userInput = GetNumberFromUser();
                if (userInput == 1)
                {
                    running = false;
                }

                while (live > 0)
                {
                  
                    Console.Write("Guess for a {0} letter Word : ", winningword.Length);
                    Isletter(winningword, letterGuessed);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    string input = Console.ReadLine();

                    if (words.Contains(input))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You Entered letter [{0}] already", input);
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Try a different word");
                        GetAlphabet(input);
                        continue;
                    }
                    letterGuessed.Add(input);

                    if (IsWord(winningword, letterGuessed))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(winningword);
                        Console.WriteLine("Congratulations");
                        break;
                    }

                    else if (winningword.Contains(input))
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("wow nice entry");
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        string letters = Isletter(winningword, letterGuessed);
                        Console.Write(letters);
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Oops, letter not in my word");
                        live -= 1;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("You have {0} live", live);
                    }
                    Console.WriteLine();

                    if (live == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Game over \nMy Winning Word is [ {0} ]", winningword);
                        break;
                    }
                }
                Console.WriteLine("press any key to Exit");
                Console.ReadKey();
            }
            
        }

        static bool IsWord(string winningword, List<string> letterGuessed)
        {
            bool word = false;
            for (int i = 0; i < winningword.Length; i++)
            {
                string c = Convert.ToString(winningword[i]);
                if (letterGuessed.Contains(c))
                {
                    word = true;
                }
                else
                {
                    return word = false;
                }
            }
            return word;
        }

        static string Isletter(string winningword, List<string> letterGuessed)
        {
            string correctletters = "";
            for (int i = 0; i < winningword.Length; i++)
            {
                string c = Convert.ToString(winningword[i]);

                if (letterGuessed.Contains(c))
                {
                    correctletters += c;
                }
                else
                {
                    correctletters += "_ ";
                }
            }
            return correctletters;
        }

        static void GetAlphabet(string letters)
        {
            List<string> alphabet = new List<string>();

            for (int i = 1; i <= 26; i++)
            {
                char alpha = Convert.ToChar(i + 96);
                alphabet.Add(Convert.ToString(alpha));
            }
            int num = 49;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Letters Left are :");

            for (int i = 0; i < num; i++)
            {
                if (letters.Contains(letters))
                {
                    alphabet.Remove(letters);
                    num -= 1;
                }
                Console.Write("[" + alphabet[i] + "] ");
            }

            Console.WriteLine();
        }


        static int GetNumberFromUser()
        {
            int userInput = 0;
            bool succeeded = false;
            while (!succeeded)
            {
                succeeded = int.TryParse(Console.ReadLine(), out userInput);
            }
            return userInput;
        }
    }
}
