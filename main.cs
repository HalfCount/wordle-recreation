using System;
using System.Collections.Generic;
namespace worlde;

class Program
{
    static void Main(string[] args)
    {
        int numLetter;
        int tempNumber;

        Console.Write("\n");

        while (true)
        {
            Console.Write("How many letters in the word?: ");
            tempNumber = Convert.ToInt32(Console.ReadLine());

            if (tempNumber >= 3 && tempNumber <= 14)
            {
                numLetter = tempNumber;
                break;
            }
            else
            {
                Console.WriteLine("Please enter a number between 3 and 14.");
            }
        }

        Random rnd = new Random();
        string corWord;
        string tempWord;
        int rndNum;
        WordList wordClass = new WordList();
        List<string> wordList = wordClass.GetList();

        while (true)
        {
            rndNum = rnd.Next(0, wordList.Count);
            tempWord = wordList[rndNum];
            if (tempWord.Length == numLetter)
            {
                corWord = tempWord;
                break;
            }
        }

        string userGuess;
        int guessLength;
        int numGuess = 6;
        string border = "--------------------------";
        bool userWin = false;
        char[] curSolve = new char[numLetter];
        char[] guessArr = new char[numLetter];
        char[] ansArr = new char[numLetter];
        char[] checkArr = new char[numLetter];
        checkArr = corWord.ToCharArray();
        ansArr = corWord.ToCharArray();

        for (int i = 0; i < numLetter; i++)
        {
            curSolve[i] = '_';
        }

        Console.Write("\n");
        Console.WriteLine("The word is " + numLetter + " letters and you have 6 guesses. If you guess a letter in the word right, it will reveal that letter to you.");
        Console.WriteLine("If you get a letter right but it is not in the correct position, the console will tell you so.");
        Console.WriteLine(border);

        for (int i = 1; i <= numGuess; i++)
        {
            Console.Write("Guess " + i + "/" + numGuess + ": ");
            userGuess = Console.ReadLine();
            guessLength = userGuess.Length;
            userGuess = userGuess.ToLower();

            if (guessLength != numLetter)
            {
                Console.WriteLine("Guess must be " + numLetter + " letters long.");
                Console.WriteLine(border);
                i--;
                continue;
            }

            guessArr = userGuess.ToCharArray();

            if (userGuess == corWord)
            {
                userWin = true;
                break;
            }

            for (int h = 0; h < numLetter; h++)
            {
                if (guessArr[h] == ansArr[h])
                {
                    checkArr[h] = '_';
                }
            }

            for (int h = 0; h < numLetter; h++)
            {
                if (guessArr[h] == ansArr[h])
                {
                    curSolve[h] = ansArr[h];
                }
                else
                {
                    for (int j = 0; j < numLetter; j++)
                    {
                        if (guessArr[h] == ansArr[j] && checkArr[j] != '_')
                        {
                          
                            Console.WriteLine("The letter " + ansArr[j] + " is in the word.");
                        }
                    }
                }
            }

            for (int h = 0; h < numLetter; h++)
            {
                Console.Write(curSolve[h]);
            }

            Console.Write("\n");
            Console.WriteLine(border);
        }

        Console.Write("\n");

        if (userWin)
        {
            Console.WriteLine("You won!");
        }
        else
        {
            Console.WriteLine("Sorry, you lost. The word was " + corWord + ".");
        }

        Console.ReadKey();
    }
}