using System.IO;
using System.Collections.Generic;
using System;
using System.Linq;
namespace Hangman.Models
{
    
    public class Game
    {
        public char[] Word {get;set;}
        public char[] Solution {get;set;}
        
        public int WrongGuesses {get;set;}
        public string Message {get;set;}
        public static Game Current {get;set;}  
        public static string[] words = new string[]{"backwards", "movement", "shadow", "lustre", "polish", "groove"};

        public List<char> Guesses = new List<char>(); 
        public static string GetRandomWord()
        {
           
            Random rnd = new Random();
            
            int r = rnd.Next(words.Length);
           
            return words[r];
        }
        public Game(string str)
        {
            Message = "";
            Word = str.ToCharArray();
            Solution = new char[str.Length];
            Solution = Solution.Select(x => x='_').ToArray();
            Current = this;
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
                Word[index] =  '_';
                Solution[index] = ch;
            }  
        }

        public bool HasWon()
        {
            if(Array.IndexOf(Solution,'_') < 0)
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