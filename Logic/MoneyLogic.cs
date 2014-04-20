using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Monopoly
{
    public class MoneyLogic
    {
        public MoneyLogic(ref Monopoly monopoly)
        {
            this.Monopoly = monopoly;
            this.IsInitialized = false;
            this.UI = new UI(ref monopoly);
        }//GameLogic

        private Monopoly Monopoly { get; set; }
        private GameState Game { get; set; }
        public bool IsInitialized { get; private set; }
        private UI UI { get; set; }

        public void Initialize()
        {
            this.Game = Monopoly.ActiveGame;
            this.IsInitialized = true;
        }//Init()

        public void PayPlayer(int payerID, int recieverID, int amount)
        {
            ChangeMoney(payerID, -1 * amount);
            ChangeMoney(recieverID, amount);
            CheckForBankrupt(payerID);
            UI.Display(String.Format("Player {0} paid Player {1} {2} dollars.", payerID + 1, recieverID + 1, amount));
        }//PayPlayer

        public void ChangeMoney(int playerID, int amount)
        {
            Game.Players[playerID].Money += amount;
            UI.BankExchange(amount);
            CheckForBankrupt(playerID);
        }//ChangeMoney()

        public void CheckForBankrupt(int playerID)
        {
            //TODO: Current accomodates only two players, need to expand when adding more players
            
            if (Game.Players[playerID].Money <= 0)
            {
                Player winner = Game.Players[0];
                foreach (Player p in Game.Players)
                {
                    if (p.ID != playerID)
                    {
                        winner = p;
                    }//if
                }//foreach
                Monopoly.GameLogic.EndGame(winner.ID);
            }//if
            
        }//CheckForBankrupt() //TODO: Handle mortgages

        public void CollectFromBank(int playerID, int amount)
        {
            Game.Players[playerID].Money += amount;
            UI.BankExchange(amount);
            CheckForBankrupt(playerID);
        }//CollectFromBank

        public void CollectFromOtherPlayers(int playerID, int amount)
        //used for a few cards that have the player 
        //collecting money from all other players
        {
            foreach (Player p in Game.Players)
            {
                if (p.ID != playerID)
                {
                    ChangeMoney(playerID, amount);
                    ChangeMoney(p.ID, amount * -1);
                }//if

            }//foreach
        }//CollectFromPlayers


        public void BuySpace(int spaceIndex, int playerID)
        {
            Tiles.BuyableSpace thisSpace = (Tiles.BuyableSpace)Game.Board.BoardSpaces[spaceIndex];
            thisSpace.OwnerID = playerID;
            if (thisSpace.SpaceType == "Property")
            {
                Tiles.Property thisProp = (Tiles.Property)thisSpace;
                Game.Players[playerID].OwnedProperties.Add(thisProp);
            }
            else if (thisSpace.SpaceType == "Utility")
            {
                Game.Players[playerID].Utilities++;
            }
            else
            {
                Game.Players[playerID].Railroads++;
            }//if-else

            ChangeMoney(playerID, thisSpace.Cost * -1);
            UI.UpdateStats();
        }//BuySpace

        public void TaxTenPercent(Player thisPlayer)
        {
            double amt = thisPlayer.Money * .10;
            int intAmt = -1 * (int)Math.Ceiling(amt);
            ChangeMoney(thisPlayer.ID, intAmt);
        }//TaxTenPercent

        public int TestMethod()
        {
            return Monopoly.TestState;
        }

    }//MoneyLogic
}
