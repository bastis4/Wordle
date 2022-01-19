using System;
using System.IO;
using System.Text;

class Solution
{
    static string filePath = @"D:\AMD\VS projects\GuessTheWord\GuessTheWord\words.txt";
    static int maxCountOfTries = 6;
    static Random rnd = new Random();

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string[] words = File.ReadAllLines(filePath);
        var r = rnd.Next(words.Length);
        var wordToGuess = words[r];
        Console.WriteLine("Введите слово из " + words[r].Length + " букв:");
        var count = 0;
        while (count < maxCountOfTries)
        {
            var inputWord = Console.ReadLine();
            if(inputWord.Length != wordToGuess.Length)
            {
                Console.WriteLine("Длина введенного слова не соответствует загаданному.");
            }
            else
            {
                CheckInputWord(wordToGuess, inputWord);
                count++;
            } 
        }
    }
    
    static void CheckInputWord(string wordToGuess, string inputWord) 
    {
        Console.SetCursorPosition(0, Console.CursorTop - 1);
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
                    }
                    else if (wordToGuess.Contains(inputWord[i]))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                Console.Write(inputWord[i]);
                Console.ResetColor();
            }
                Console.WriteLine();
                return;
            }   
    }
}
