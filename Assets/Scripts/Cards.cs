using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Cards
    {
        public string CardType { get; set; }
        public string Message { get; set; }
        public string Action { get; set; }

        public Cards(string type, string message, string action)
        {
            CardType = type;
            Message = message;
            Action = action;
        }

        public static List<Cards> AllCards()
        {
            List<Cards> cards = new List<Cards>();

            cards.Add(new Cards(
                "Chance",
                "Advance to Illinois Avenue",
                "move"));
            cards.Add(new Cards(
                "Chance",
                "Pay Poor Tax of $15",
                "pay"));
            cards.Add(new Cards(
                "Chance",
                "Advance to St. Charles Place",
                "move"));
            cards.Add(new Cards(
                "Chance",
                "Advance token to nearest utility",
                "move"));
            cards.Add(new Cards(
                "Chance",
                "Go back 3 spaces",
                "move"));
            cards.Add(new Cards(
                "Chance",
                "Advance to Go (Collect $200)",
                "move"));
            cards.Add(new Cards(
                "Chance",
                "Elected Chairman of Board: Pay each player $50",
                "pay"));
            cards.Add(new Cards(
                "Chance",
                "Make General Repairs. For each house, pay $25. For each hotel, pay $100",
                "pay"));
            cards.Add(new Cards(
                "Chance",
                "Get Out of Jail Free! This card may be kept until needed or sold",
                "keep"));
            cards.Add(new Cards(
                "Chance",
                "Advance Token to nearest Railroad and pay owner Twice the rental to which they are owed",
                "move"));
            cards.Add(new Cards(
                "Chance",
                "Take a ride on the Reading Railroad. If you pass go, collect $200",
                "move"));
            cards.Add(new Cards(
                "Chance",
                "Building and Loan Matures, Collect $150",
                "collect"));
            cards.Add(new Cards(
                "Chance",
                "Advance Token to Nearest Railroad and pay owner Twice the rental to which they are owed",
                "collect"));
            cards.Add(new Cards(
                "Chance",
                "Advance token to Boardwalk",
                "move"));
            cards.Add(new Cards(
                "Chance", "Bank pays you dividend of $50",
                "collect"));
            cards.Add(new Cards(
                "Chance",
                "Go Directly to Jail. Do not pass Go, do not collect $200",
                "move"));
            cards.Add(new Cards(
                "Community Chest",
                "Life Insurance Matures. Collect $100",
                "collect"));
            cards.Add(new Cards(
                "Community Chest",
                "Income Tax Refund, collect $20",
                "collect"));
            cards.Add(new Cards(
                "Community Chest",
                "Receive for services $25",
                "collect"));
            cards.Add(new Cards(
                "Community Chest",
                "Pay School Tax of $150",
                "pay"));
            cards.Add(new Cards(
                "Community Chest",
                "Street Repairs. $40 per house, $115 per hotel",
                "pay"));
            cards.Add(new Cards(
                "Community Chest",
                "Xmas fund matures, collect $100",
                "collect"));
            cards.Add(new Cards(
                "Community Chest",
                "Doctor's Fee, pay $50",
                "pay"));
            cards.Add(new Cards(
                "Community Chest",
                "Get Out of Jail Free. This card may be kept until needed or sold",
                "keep"));
            cards.Add(new Cards(
                "Community Chest",
                "Sale of Stock, you get $45",
                "collect"));
            cards.Add(new Cards(
                "Community Chest",
                "Advance to Go, collect $200",
                "move"));
            cards.Add(new Cards(
                "Community Chest",
                "Inherit $100",
                "collect"));
            cards.Add(new Cards(
                "Community Chest",
                "Second Prize in a Beauty Contest, collect $10",
                "collect"));
            cards.Add(new Cards(
                "Community Chest",
                "Bank Error in your Favor, collect $200",
                "collect"));
            cards.Add(new Cards(
                "Community Chest",
                "Go Directly to Jail. Do not pass Go, do not collect $200",
                "move"));
            cards.Add(new Cards(
                "Community Chest",
                "Grand Opera Opening: Collect $50 from everyone",
                "collect"));
            cards.Add(new Cards(
                "Community Chest",
                "Pay Hospital $100",
                "pay"));

            return cards;
        }
    
        public static List<Cards> CreateDeck_Chance()
        {
            List<Cards> chanceDeck = new List<Cards>();
            foreach (var card in AllCards())
            {
                if (card.CardType.Equals("Chance"))
                {
                    chanceDeck.Add(card);
                }
            }
            return chanceDeck;
        }

        public static List<Cards> CreateDeck_CommunityChest()
        {
            List<Cards> communityChestDeck = new List<Cards>();
            foreach (var card in AllCards())
            {
                if (card.CardType.Equals("Community Chest"))
                {
                    communityChestDeck.Add(card);
                }
            }
            return communityChestDeck;
        }

        public static void ShuffleDeck(List<Cards> deck)
        {
            System.Random rand = new System.Random();
            for (int i = 0; i < deck.Count; i++)
            {
                int x = rand.Next(i, deck.Count);
                Cards temp = deck[i];
                deck[i] = deck[x];
                deck[x] = temp;

            }
        }

        public static void PutCardOnBottomOfDeck(List<Cards> deck, Cards card)
        {
            List<Cards> tempDeck = new List<Cards>();
            for(int i = 0; i < (deck.Count-1); i++)
            {
                deck[i] = deck[i + 1];
            }

            deck[deck.Count] = card;
        }

        public static void DrawTopCard(List<Cards> deck)
        {
            Cards topCard = deck[0];
            switch(topCard.Action)
            {
                case "move":
                    //do stuff
                    break;
                case "pay":
                    //do stuff
                    break;
                case "collect":
                    //do stuff
                    break;
                case "keep":
                    //do stuff
                    break;
            }

        }
    }
}
