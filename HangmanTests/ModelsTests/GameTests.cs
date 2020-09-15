using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using Hangman.Models;



namespace HangmanTests.ModelsTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void GetRandomWord_RandomWordIsInList_ReturnsTrue()
        {
             Game g = new Game("string");
            //act
            string str = Game.GetRandomWord();
            int num = Array.IndexOf(Game.words,str);
           
            bool b = (num >= 0);
            
            Assert.AreEqual(true,b);
        }

        [TestMethod]
        public void Game_ConstructorCreatesValidObject_ReturnsTrue()
        {
            //arrange
           Game game = new Game("dope");
           char[] eWord = {'d','o','p','e'};
           char[] eSolution = {'_','_','_','_'};
           //act
           char[] aWord = game.Word;
           char[] aSolution = game.Solution;
           
           bool equal1 = eWord.SequenceEqual(aWord);
           bool equal2 = eSolution.SequenceEqual(aSolution);

           Assert.AreEqual(true, equal1 && equal2);
        }

        [TestMethod]
        public void IsCharInWord_DetermineIfCharIsInWord_ReturnsTrue()
        {
            //arrange
            Game game = new Game("dope");

            //act;
            bool guess = game.IsCharInWord('d');
            Assert.AreEqual(true,guess);
        }

        
        [TestMethod]
        public void IsCharInWord_DetermineIfCharIsInWord_ReturnsFalse()
        {
            //arrange
            Game game = new Game("dope");
            
            //act;
            bool guess = game.IsCharInWord('f');
            Assert.AreEqual(false,guess);
        }


        [TestMethod]
        public void MakeChanges_ChangeSolutionValue_ReturnsTrue()
        {
            //arrange
            Game game = new Game("deep");
            char[] eWord = {'d','_','_','p'};
            char[] eSolution = {'_','e','e','_'};
            
            //act
            game.MakeChanges('e');
            bool equal1 = eWord.SequenceEqual(game.Word);
            bool equal2 = eSolution.SequenceEqual(game.Solution);

            Assert.AreEqual(true,equal1 && equal2);
        }

        [TestMethod]
        public void HasWon_PlayerFinishedPuzzle_ReturnsTrue()
        {
            //arrange
            Game game = new Game("deep");
            
            //act
            game.Guess('d');
            game.Guess('e');
            game.Guess('p');

            Assert.AreEqual(true, game.HasWon());
        }

        [TestMethod]
         public void HasWon_PlayerFinishedPuzzle_ReturnsFalse()
        {
            //arrange
            Game game = new Game("deep");
            
            //act
            game.Guess('d');
            game.Guess('e');

            Assert.AreEqual(false, game.HasWon());
        }

         [TestMethod]
         public void IsGameOver_PlayerMadeTooManyWrongGuesses_ReturnsTrue()
        {
            //arrange
            Game game = new Game("deep");
            
            //act
            game.Guess('d');
            game.Guess('e');
            game.Guess('f');
            game.Guess('t');
            game.Guess('q');
            game.Guess('s');
            game.Guess('l');
            game.Guess('n');

            Assert.AreEqual(true, game.IsGameOver());
        }

         [TestMethod]
         public void IsGameOver_PlayerMadeTooManyWrongGuesses_ReturnsFalse()
        {
            //arrange
            Game game = new Game("deep");
            
            //act
            game.Guess('d');
            game.Guess('e');
            game.Guess('f');
            game.Guess('t');
            game.Guess('q');
            game.Guess('s');
            game.Guess('l');
            
            Assert.AreEqual(false, game.IsGameOver());
        }

          [TestMethod]
         public void Guess_GuessesAreAddedToGuessList_ReturnsTrue()
        {
            //arrange
            Game game = new Game("deep");
            List<char> eResult = new List<char>{'d','e','f','t','q','s','l'};
            //act
            game.Guess('d');
            game.Guess('e');
            game.Guess('f');
            game.Guess('t');
            game.Guess('q');
            game.Guess('s');
            game.Guess('l');
            
            CollectionAssert.AreEqual(eResult, game.Guesses);
        }
    }
}