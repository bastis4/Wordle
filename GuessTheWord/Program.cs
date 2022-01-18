using System;
using System.IO;
using System.Text;

class Solution
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string filePath = "D:\\Docs\\test.txt";
        StreamReader sr = new StreamReader(filePath);
        List<string> words = new List<string>();
        while (!sr.EndOfStream)
        {
            words.Add(sr.ReadLine());    
        }
        sr.Close();
        int r = rnd.Next(words.Count);
        string wordToGuess = words[r];
        Console.WriteLine("Введите слово из " + words[r].Length + " букв:");
        int count = 0;
        int countOfTries = 6;
        while (count < countOfTries)
        {
            string inputWord = Console.ReadLine();
            CheckInputWord(wordToGuess, inputWord);
            count++;
        }
    }
    static Random rnd = new Random();
    static void CheckInputWord(string wordToGuess, string inputWord) 
    {
        
        Console.SetCursorPosition(0, Console.CursorTop - 1);

        try
        {

            if (wordToGuess == inputWord)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(inputWord);
                Console.ResetColor();
                Console.WriteLine("BINGO!");
                return;
            }

            else
            {
                for (int i = 0; i < wordToGuess.Length; i++)
                {

                    if (wordToGuess[i] == inputWord[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(inputWord[i]);
                        Console.ResetColor();
                    }

                    else if (wordToGuess.Contains(inputWord[i]))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(inputWord[i]);
                        Console.ResetColor();
                    }

                    else
                    {
                        Console.Write(inputWord[i]);
                    }
                }
                Console.WriteLine();
                return;

            }
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine();
            Console.WriteLine("В вашем слове маловато букв");
        }
      
    }

    /*static void Graphics(string wordToGuess)
    {
        int numberOfLetters = wordToGuess.Length;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        //string symbol = "\u25A1";
        string symbol = "\u1F79";
        int numberOfTries = 6;
        for (int i = 0; i < numberOfTries; i++)
        {
            for (int y = 0; y < numberOfLetters; y++)
            {
                Console.Write(symbol);
            }
            Console.WriteLine();
        }
    }*/
}
