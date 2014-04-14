using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Monopoly
{
    public class GameLogic
    {
        private GameState mGame;

        public GameLogic(ref GameState game)
        {
            this.Game = game;
        }//GameLogic

        public GameState Game { get { return mGame; } set { mGame = value; } }

        public void Turn()
        {
            int roll = RollDice();
            bool rollWasDouble = Game.Doubles[Game.ActivePlayerID].LastRollWasDouble;

            if (Game.Players[Game.ActivePlayerID].IsJailed)
            {
                if (rollWasDouble)
                {
                    ReleaseFromJail(Game.ActivePlayerID);
                    AdvancePlayer(Game.ActivePlayerID, roll);
                }//if
                else 
                {
                    //Player remains in jail, does he want to use a GOOJ card? TODO
                }//else
            }
            else if (Game.Doubles[Game.ActivePlayerID].LastThreeWereDoubles()) //if player rolled his third double
            {
                SendToJail(Game.ActivePlayerID);
            }
            else //player is unjailed and didn't roll his third double
            {
                AdvancePlayer(Game.ActivePlayerID, roll);
            }//else

            if (rollWasDouble && !Game.Players[Game.ActivePlayerID].IsJailed) //if player rolled doubles, but didn't get sent to jail for it..
            {
                Turn();
            }//if

            ChangeActivePlayer(); //will fire after player didn't roll doubles, or is in jail.

        }//Turn() TODO

        public void AdvancePlayer(int playerID, int numberOfSpaces)
        {
            int finalPosition = Game.Players[playerID].Position + numberOfSpaces;

            //check for >40
            if (numberOfSpaces > 79)
            {
                System.Windows.Forms.MessageBox.Show("ERROR: Unable to advance player more than 79 spaces.");
            }
            else if (finalPosition > 40)
            {
                finalPosition = 41 - numberOfSpaces;
                //Player has passed Go, so award $200
                PassGo(playerID);
            }
            else if (finalPosition <= 0) //to handle the -3 spaces card
            {
                Debug.WriteLine("finalPos = {0}, moving backwards by {1}", finalPosition, numberOfSpaces);
                finalPosition = 41 + numberOfSpaces;
            }


            Game.Players[playerID].Position = finalPosition;
            Land(playerID);
        }//AdvancePlayer()
        
        public void Land(int playerID)
        {
            //logic for what happens when player lands on a space
        }//Land() //TODO

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
                Game.ActivePlayerID = 0;
            }
            else
            {
                Game.ActivePlayerID = 1;
            }

            System.Windows.Forms.MessageBox.Show("Player 1 rolled " + RollResult[0] + " and Player 2 rolled " + RollResult[1] + ", so Player " + Game.ActivePlayerID + " goes first.");

        }//StartGame()

        public void ChangeActivePlayer()
        {
            int intActiveID = Game.ActivePlayerID;
            intActiveID++;
            if (intActiveID > (Game.Players.Count() - 1))
            {
                intActiveID = 0;
            }//if
            Game.ActivePlayerID = Game.Players[intActiveID].ID;
        }//ChangeActivePlayer()

        public int RollDice()
        {
            Random rand = new Random();
            bool rolledDoubles = false;
            int roll1, roll2;

            roll1 = rand.Next(1, 7);
            roll2 = rand.Next(1, 8);

            if (roll1 == roll2)
            {
                rolledDoubles = true;
            }//if

            Game.Doubles[Game.ActivePlayerID].NextDouble(rolledDoubles);

            return roll1 + roll2;
            //Roll dice
        }//RollDice() TODO

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

        public void PassGo(int playerID)
        {
            Game.Players[playerID].Money += 200;
        }//PassGo()

        public void SendToJail(int playerID)
        {
            Game.Players[playerID].Position = 11; //don't advancePlayer, don't pass go!
            Game.Players[playerID].IsJailed = true;
        }//SendToJail

        public void ReleaseFromJail(int playerID)
        {
            Game.Players[playerID].IsJailed = false;
        }//SendToJail
    }//GameLogic
}
