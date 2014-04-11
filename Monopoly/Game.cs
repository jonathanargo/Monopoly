using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Game
    {
        private Board mBoard;
        private int mTurnCount;
        private Player[] mPlayers;
        private Player mActivePlayer;
        private Deck[] mDecks;

        private Random mRand;

        public Game()
        {
            this.Board = new Board();
            this.Players = new Player[2];
            this.Decks = new Deck[2];

            TurnCount = 1;
            ActivePlayer = Players[1];

            Players[0] = new Player(1);
            Players[1] = new Player(2);

            Decks[0] = new Deck(1, DeckType.CommunityChest);
            Decks[1] = new Deck(2, DeckType.Chance);

        }//Game()       


        //PROPERTIES

        public Deck[] Decks { get { return mDecks; } set { mDecks = value; } }
        public Player[] Players { get { return mPlayers; } private set { mPlayers = value; } }
        public Board Board { get { return mBoard; } private set { mBoard = value; } }

        public Player ActivePlayer { get { return mActivePlayer; } private set { mActivePlayer = value; } }        
        public int TurnCount { get { return mTurnCount; } set { mTurnCount = value; } }      


        //METHODS

        public void StartGame()
        {
            int[] Roll = new int[2];
            int[] RollResult = new int[2];
            mRand = new Random();

            foreach (Deck d in Decks)
            {
                d.ShuffleDeck(); //initalized cards in each deck
            }//foreach

            foreach (Player p in Players)
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
                ActivePlayer = Players[0];
            }
            else
            {
                ActivePlayer = Players[1];
            }

            System.Windows.Forms.MessageBox.Show("Player 1 rolled " + RollResult[0] + " and Player 2 rolled " + RollResult[1] + ", so Player " + (int)ActivePlayer.ID + " goes first.");

        }//StartGame

        public void ChangeActivePlayer()
        {
            int intActiveID = ActivePlayer.ID;
            intActiveID++;
            if (intActiveID > (Players.Count() - 1))
            {
                intActiveID = 0;
            }//if
            ActivePlayer = Players[intActiveID];
        }//ChangeActivePlayer

        

    }//class Game

}//Monopoly
