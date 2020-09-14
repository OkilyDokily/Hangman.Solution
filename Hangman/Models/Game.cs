using System.IO;
using System.Collections.Generic;
using System;
namespace Hangman.Models
{
    
    public class Game
    {
        public char[] Word {get;set;}
        public char[] Solution {get;set;}
        
        public int WrongGuesses {get;set;} 
        public static string[] words = new string[]{"backwards, movement, shadow, lustre, polish, groove"};

        public List<char> Guesses = new List<char>(); 
        public static string GetRandomWord()
        {
            Random rnd = new Random();
            int r = rnd.Next(words.Length);
            return words[r];
        }
        public Game(string str)
        {
            Word = str.ToCharArray();
            Solution = new char[str.Length];
        }
        
        
        public void Guess(char ch)
        {
            Guesses.Add(ch);
            if(IsCharInWord(ch))
            {
                MakeChanges(ch);
            }
            else
            {
                WrongGuesses++;
            }
        }

        public bool IsCharInWord(char ch)
        {
            int index = Array.IndexOf(Word, ch);
            if (index >= 0)
            {
                return true;
            }
            return false;
        }

        public void MakeChanges(char ch)
        {
            while(true)
            {
                int index = Array.IndexOf(Word, ch);
                if (index < 0) break;
                Word[index] =  '\0';
                Solution[index] = ch;
            }  
        }

        public bool HasWon()
        {
            if(Array.IndexOf(Solution,'\0') < 0)
            {
                return true;
            }
            return false;
        }

        public bool IsGameOver()
        {
            if(WrongGuesses > 5)
            {
                return true;
            }
            return false;
        }
    }
}