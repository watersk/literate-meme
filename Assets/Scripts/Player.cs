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

        public static void UpdateMoney(Player player, int amount, string updateType)
        {
            switch(updateType)
            {
                case "pay":
                    player.Money = (player.Money - amount);
                    break;
                case "collect":
                    player.Money = (player.Money + amount);
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

        public static void Rent(Player landlord, Player tenant, Property propLanded)
        {
            int rent = propLanded.Rent;

            if(propLanded.IsMonopoly)
            {
                rent = rent * 2;
            }

            UpdateMoney(landlord, rent, "collect");
            UpdateMoney(tenant, rent, "pay");
        }

        public static void PurchaseProperty(Player player, Property propToBeBought)
        {
            if (!propToBeBought.IsOwned && propToBeBought.CanBeBought)
            {
                Debug.Log("Property: " + propToBeBought.Name);
                Debug.Log("Cost: " + propToBeBought.Cost);
                UpdateMoney(player, propToBeBought.Cost, "pay");
                UpdatePropertyList(player, propToBeBought);
                UpdatePlayerLocation(player, propToBeBought);
            }
            else
            {
                Debug.Log("Cannot purchase " + propToBeBought.Name);
            }
        }
    }
}
