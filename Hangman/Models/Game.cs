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
            if(Guesses.IndexOf(ch) >=0)
            {
                Message = "You already guessed that.";
                return;
            }
            Guesses.Add(ch);
            if(IsCharInWord(ch))
            {
                Message = "Nice guess.";
                MakeChanges(ch);
                if(HasWon()){
                    Message = "You won!";
                }
            }
            else
            {
                WrongGuesses++;
                Message = "Nope.";
                if(WrongGuesses > 5)
                {
                    Message = "Sorry, pal. Game Over.";
                }
                
            }
        }

        public bool IsCharInWord(char ch)
        {
            return Array.IndexOf(Word, ch) >= 0;
        }

         public bool IsCharInSolution(char ch)
        {
            return Array.IndexOf(Solution, ch) >= 0;
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
            return  (Array.IndexOf(Solution,'_') < 0);
           
        }

        public bool IsGameOver()
        {
            return (WrongGuesses > 5 || HasWon());
        }
    }
}