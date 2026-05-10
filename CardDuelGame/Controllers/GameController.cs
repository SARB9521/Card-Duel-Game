using Microsoft.AspNetCore.Mvc;
using CardDuelGame.Models;

namespace CardDuelGame.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Duel(string mode, string playerCard, string friendCard)
        {
            Card player = ParseCard(playerCard);
            Card opponent = mode == "computer" ? new Deck().Draw() : ParseCard(friendCard);

            string result = player.Value > opponent.Value ? "You Win!" :
                            player.Value < opponent.Value ? (mode == "computer" ? "Computer Wins!" : "Friend Wins!") :
                            "It's a Tie!";

            var model = new GameModel
            {
                PlayerCard = player,
                ComputerCard = opponent,
                Winner = result
            };

            ViewBag.Mode = mode;
            return View("Result", model);
        }

        private Card ParseCard(string input)
        {
            var parts = input.Split("-of-");
            if (parts.Length != 2) return new Card { Rank = "?", Suit = "?", Value = 0 };

            string rank = parts[0];
            string suit = parts[1];

            int value = rank switch
            {
                "J" => 11,
                "Q" => 12,
                "K" => 13,
                "A" => 14,
                _ => int.TryParse(rank, out int v) ? v : 0
            };

            return new Card { Rank = rank, Suit = suit, Value = value };
        }
    }
}
