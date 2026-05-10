namespace CardDuelGame.Models
{
    public class Card
    {
        public string Rank { get; set; }
        public string Suit { get; set; }
        public int Value { get; set; }

        public string Display => $"{Rank} of {Suit}";
        public string ImageFileName => $"{Rank.ToLower()}_of_{Suit.ToLower()}.png";
    }
}
