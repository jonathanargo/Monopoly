using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class GameLogic
    {
        private GameState mGame;

        public GameLogic(ref GameState game)
        {
            this.Game = game;
        }//GameLogic

        public GameState Game { get { return mGame; } private set { mGame = value; } }

        public void GameStateChangeTest()
        {
            Game.Players[0].Money = 12345;
        }//GameStateChangeTest

        public void Land(int playerID)
        {
            //logic for what happens when player lands on a space
        }//Land() //TODO

        public void PassGo(int playerID)
        {
            Game.Players[playerID].Money += 200;
        }//PassGo()

        public void StartGame()
        {
            int[] Roll = new int[2];
            int[] RollResult = new int[2];
            Random mRand = new Random();

            foreach (Deck d in Game.Decks)
            {
                d.ShuffleDeck(); //initalized cards in each deck
            }//foreach

            foreach (Player p in Game.Players)
            {
                p.Money = 1500;
                p.Position = 1;
            }//foreach

            RollResult[0] = 0;
            RollResult[1] = 0;

            while (RollResult[0] == RollResult[1]) //reroll if both players get same result
            {
                for (int i = 0; i <= 1; i++)
                {
                    Roll[0] = mRand.Next(1, 7);
                    Roll[1] = mRand.Next(1, 7);
                    RollResult[i] = Roll.Sum();
                }//for
            }//while

            if (RollResult[0] > RollResult[1])
            {
                Game.ActivePlayer = Game.Players[0];
            }
            else
            {
                Game.ActivePlayer = Game.Players[1];
            }

            System.Windows.Forms.MessageBox.Show("Player 1 rolled " + RollResult[0] + " and Player 2 rolled " + RollResult[1] + ", so Player " + Game.ActivePlayer.ID + " goes first.");

        }//StartGame()

        public void ChangeActivePlayer()
        {
            int intActiveID = Game.ActivePlayer.ID;
            intActiveID++;
            if (intActiveID > (Game.Players.Count() - 1))
            {
                intActiveID = 0;
            }//if
            Game.ActivePlayer = Game.Players[intActiveID];
        }//ChangeActivePlayer()

        public void AdvancePlayer(int playerID, int numberOfSpaces)
        {
            int finalPosition = Game.Players[playerID].Position + numberOfSpaces;

            //check for >40
            if (finalPosition > 40)
            {
                finalPosition -= 40;
                //Player has passed Go, so award $200
                PassGo(playerID);
            }
            else if (finalPosition <= 0) //to handle the -3 spaces card
            {
                finalPosition += 40;
            }

            Game.Players[playerID].Position = finalPosition;
            Land(playerID);
        }//AdvancePlayer()

        public void AdvancePlayerToPosition(int playerID, int position)
        //used for handling some cards
        {
            int currentPos = Game.Players[playerID].Position;

            //if player will need to pass Go
            if (Game.Players[playerID].Position > position) { PassGo(playerID); }//if

            Game.Players[playerID].Position = position;
            Land(playerID);

        }//AdvancePlayerToPosition()

        public void AdvanceToPositionCustomPay(int playerID, int position)
        //used for handling the "advance to railroad" and 
        //"advance to utility" cards, since they manually 
        //pay the owner a certain amount
        {
            int currentPos = Game.Players[playerID].Position;

            //if player will need to pass Go
            if (Game.Players[playerID].Position > position) { PassGo(playerID); }//if

            Game.Players[playerID].Position = position;
        }//AdvancePlayerToPositionCustomPay()

        public void SendToJail(int playerID)
        {
            Game.Players[playerID].Position = 11; //don't advancePlayer, don't pass go!
            Game.Players[playerID].IsJailed = true;
        }//SendToJail

    }//GameLogic
}
