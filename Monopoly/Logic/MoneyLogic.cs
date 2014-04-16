﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class MoneyLogic
    {
        public MoneyLogic(ref Monopoly monopoly)
        {
            this.Monopoly = monopoly;
            this.IsInitialized = false;
        }//GameLogic

        private Monopoly Monopoly { get; set; }
        private GameState Game { get; set; }
        public bool IsInitialized { get; private set; }

        public void Initialize()
        {
            this.Game = Monopoly.ActiveGame;
            this.IsInitialized = true;
        }//Init()

        public void PayPlayer(int payerID, int recieverID, int amount)
        {
            ChangeMoney(payerID, -1 * amount);
            ChangeMoney(recieverID, amount);
        }//PayPlayer

        public void ChangeMoney(int playerID, int amount)
        {
            Game.Players[playerID].Money += amount;
            CheckForBankrupt(playerID);
        }//ChangeMoney()

        public void CheckForBankrupt(int playerID)
        {
            //check to see if player has < 0 money. If so, mortgage properties
        }//CheckForBankrupt() //TODO

        public void CollectFromBank(int playerID, int amount)
        {
            Game.Players[playerID].Money += amount;
        }//CollectFromBank

        public void CollectFromOtherPlayers(int playerID, int amount)
        //used for a few cards that have the player 
        //collecting money from all other players
        {
            foreach (Player p in Game.Players)
            {
                if (p.ID != Game.Players[playerID].ID)
                {
                    p.Money -= amount;
                    Game.Players[playerID].Money += amount;
                }//if

            }//foreach
        }//CollectFromPlayers

        public void BuyProp(int propIndex, int playerID)
        {
            Tiles.Property thisProp = (Tiles.Property)Game.Board.BoardSpaces[propIndex];
            thisProp.OwnerID = playerID;
            Game.Players[playerID].OwnedProperties.Add(thisProp);
            Game.Players[playerID].Money -= thisProp.Cost;
        }//BuyProp

        public void BuyRailroad(int rrIndex, int playerID)
        {
            Tiles.Property thisProp = (Tiles.Property)Game.Board.BoardSpaces[rrIndex];
            thisProp.OwnerID = playerID;
            Game.Players[playerID].Railroads++;
            Game.Players[playerID].Money -= thisProp.Cost;
        }//BuyProp

    }//MoneyLogic
}
