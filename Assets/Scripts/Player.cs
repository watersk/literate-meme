using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class Player
    {
        //public GameObject User { get; set; }
        public int Money { get; set; }
        public Property CurrentLocation { get; set; }
        public List<Property> OwnedProperties { get; set; }
        public List<Cards> KeptCards { get; set; }

        public Player(int money, Property currentLocation, List<Property> ownedProperties, List<Cards> keptCards)
        {
            //User = user;
            Money = money;
            CurrentLocation = currentLocation;
            OwnedProperties = ownedProperties;
            KeptCards = keptCards;
        }

        public static Player CreatePlayer()
        {
            List<Property> ownedProps = new List<Property>();
            List<Cards> keptCards = new List<Cards>();
            List<Property> board = Property.CreateBoard();
            return new Player(1500, board[0], ownedProps, keptCards);
        }

        public static void PrintOwnedProps(List<Player> players, Player desiredPlayer)
        {
            int index = players.IndexOf(desiredPlayer);
            foreach(var property in desiredPlayer.OwnedProperties)
            {
                Debug.Log("Player" + (index + 1) + " owns: " + property.Name);
            }
        }

        public static void UpdateMoney(Player player, int amount, string updateType)
        {
            switch(updateType)
            {
                case "pay":
                    player.Money -= amount;
                    break;
                case "collect":
                    player.Money += amount;
                    break;
            }
        }

        public static void UpdatePlayerLocation(Player player, Property property)
        {
            player.CurrentLocation = property;
        }

        public static void UpdatePropertyList(Player player, Property property)
        {
            player.OwnedProperties.Add(property);
            property.CanBeBought = false;
            property.IsOwned = true;
        }

        public static void UpdateCardList(Player player, Cards card)
        {
            player.KeptCards.Add(card);
        }

        public static Player DetermineLandlord(List<Player> players, Player currentPlayer, Property propInQuestion)
        {
            Player playerToReturn = currentPlayer;
            
            for(int x = 0; x < players.Count; x++)
            {
                Debug.Log("Player" + (x + 1) + "owns: ");
                for (int i = 0; i < players[x].OwnedProperties.Count; i++)
                {
                    Debug.Log(players[x].OwnedProperties[i].Name);
                    if (players[x].OwnedProperties[i].Equals(propInQuestion))
                    {
                        playerToReturn = players[x];
                    }
                }
                
            }
            return playerToReturn;
        }

        public static void Rent(List<Player> players, Player currentPlayer, Property propLanded)
        {
            int rent = propLanded.Rent;
            Player landlord = DetermineLandlord(players, currentPlayer, propLanded);

            if(!landlord.Equals(currentPlayer))
            {
                if (propLanded.IsMonopoly)
                {
                    rent = rent * 2;
                }

                UpdateMoney(landlord, rent, "collect");
                UpdateMoney(currentPlayer, rent, "pay");

                Debug.Log("Landlord gained: $" + rent + " and now has " + landlord.Money);
                Debug.Log("Current player lost: $" + rent + " and now has " + currentPlayer.Money);
            }
        }

        public static void PurchaseProperty(List<Player> players, Player currentPlayer, Property propToBeBought)
        {
            if (!propToBeBought.IsOwned && propToBeBought.CanBeBought)
            {
                Debug.Log("Property: " + propToBeBought.Name);
                Debug.Log("Cost: " + propToBeBought.Cost);
                UpdateMoney(currentPlayer, propToBeBought.Cost, "pay");
                UpdatePropertyList(currentPlayer, propToBeBought);
                UpdatePlayerLocation(currentPlayer, propToBeBought);
            }
            else if (propToBeBought.IsOwned)
            {
                Rent(players, currentPlayer, propToBeBought);
            }
            else
            {
                Debug.Log("Cannot purchase " + propToBeBought.Name + 
                    " because its CanBeBought value is: " + 
                    propToBeBought.CanBeBought);
            }
        }
    }
}
