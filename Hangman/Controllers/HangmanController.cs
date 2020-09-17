using Microsoft.AspNetCore.Mvc;
using Hangman.Models;
using System.Collections.Generic;
namespace Hangman.Controllers
{
    public class HangmanController : Controller
    {
        [HttpGet("/hangman")]
        public ActionResult Hangman()
        {
            
            if((Game.Current is null)){
                new Game(Game.GetRandomWord());
            }   
            return View(Game.Current);
        }

        [HttpPost("/hangman")]
        public ActionResult Guess(string guess)
        {
            
            char ch;
            Game.Current.Message = "";
            try{
                ch = char.Parse(guess);
                Game.Current.Guess(ch);
            }
            catch{
                Game.Current.Message= "You need to input one character";
            }
            return RedirectToAction("Hangman");

        }

        [HttpPost("/hangman/new")]
        public ActionResult New()
        {
            Game.Current = null;
            return RedirectToAction("Hangman");
        }
    }
}