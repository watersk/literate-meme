using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Property
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Cost { get; set; }
        public int Rent { get; set; }
        public bool IsOwned { get; set; }
        public bool CanBeBought { get; set; }
        public Property(string name, string color, int cost, int rent, bool isOwned, bool canBeBought)
        {
            Name = name;
            Color = color;
            Cost = cost;
            Rent = rent;
            IsOwned = isOwned;
            CanBeBought = canBeBought;
        }

        public static List<Property> CreateBoard()
        {
            List<Property> Board = new List<Property>();

            Board.Add(new Property("Go", "none", 0, 0, false, false));
            Board.Add(new Property("Mediterranean Avenue", "purple", 60, 2, false, true));
            Board.Add(new Property("Community Chest", "none", 0, 0, false, false));
            Board.Add(new Property("Baltic Avenue", "purple", 60, 4, false, true));
            Board.Add(new Property("Income Tax", "none", 0, 0, false, false));
            Board.Add(new Property("Reading Railroad", "railroad", 200, 25, false, true));
            Board.Add(new Property("Oriental Avenue", "light blue", 100, 6, false, true));
            Board.Add(new Property("Chance", "none", 0, 0, false, false));
            Board.Add(new Property("Vermont Avenue", "light blue", 100, 6, false, true));
            Board.Add(new Property("Connecticut Avenue", "light blue", 120, 8, false, true));
            Board.Add(new Property("Jail/Just Visiting", "none", 0, 0, false, false));
            Board.Add(new Property("St. Charles Place", "pink", 140, 10, false, true));
            Board.Add(new Property("Electric Company", "utility", 150, 10, false, true));
            Board.Add(new Property("States Avenue", "pink", 140, 10, false, true));
            Board.Add(new Property("Virginia Avenue", "pink", 160, 12, false, true));
            Board.Add(new Property("Pennsylvania Railroad", "railroad", 200, 25, false, true));
            Board.Add(new Property("St. James Place", "orange", 180, 14, false, true));
            Board.Add(new Property("Community Chest", "none", 0, 0, false, false));
            Board.Add(new Property("Tennessee Avenue", "orange", 180, 14, false, true));
            Board.Add(new Property("New York Avenue", "orange", 200, 16, false, true));
            Board.Add(new Property("Free Parking", "none", 0, 0, false, false));
            Board.Add(new Property("Kentucky Avenue", "red", 220, 18, false, true));
            Board.Add(new Property("Chance", "none", 0, 0, false, false));
            Board.Add(new Property("Indiana Avenue", "red", 220, 18, false, true));
            Board.Add(new Property("Illinois Avenue", "red", 240, 20, false, true));
            Board.Add(new Property("B&O Railroad", "railroad", 200, 25, false, true));
            Board.Add(new Property("Atlantic Avenue", "yellow", 260, 22, false, true));
            Board.Add(new Property("Ventnor Avenue", "yellow", 260, 22, false, true));
            Board.Add(new Property("Water Works", "utility", 150, 10, false, true));
            Board.Add(new Property("Marvin Gardens", "yellow", 280, 24, false, true));
            Board.Add(new Property("Go to Jail", "none", 0, 0, false, false));
            Board.Add(new Property("Pacific Avenue", "green", 300, 26, false, true));
            Board.Add(new Property("North Carolina Avenue", "green", 300, 26, false, true));
            Board.Add(new Property("Community Chest", "none", 0, 0, false, false));
            Board.Add(new Property("Pennsylvania Avenue", "green", 320, 28, false, true));
            Board.Add(new Property("Short Line Railroad", "railroad", 200, 25, false, true));
            Board.Add(new Property("Chance", "none", 0, 0, false, false));
            Board.Add(new Property("Park Place", "blue", 350, 35, false, true));
            Board.Add(new Property("Luxury Tax", "none", 0, 0, false, false));
            Board.Add(new Property("Boardwalk", "blue", 400, 50, false, true));

            return Board;
        }

        public static string getLocation(int wayPoint)
        {
            List<Property> board = CreateBoard();
            return board[wayPoint].Name;
        }
    }
}
