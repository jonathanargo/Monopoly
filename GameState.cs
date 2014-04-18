using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Monopoly
{
    public class GameState
        //contains the majority of the game logic, as well as the game elements
        //creates the board, deck, and players
    {
        private Board mBoard;
        private int mTurnCount;
        private Player[] mPlayers;
        private int mActivePlayerID;
        private Deck[] mDecks;
        private DoublesQueue[] mDoublesQueues;

        public GameState()
        {
            SetState();
        }//Game()       


        //PROPERTIES

        public Deck[] Decks { get { return mDecks; } set { mDecks = value; } }
        public Player[] Players { get { return mPlayers; } private set { mPlayers = value; } }
        public Board Board { get { return mBoard; } private set { mBoard = value; } }
        public int ActivePlayerID { get { return mActivePlayerID; } set { mActivePlayerID = value; } }        
        public int TurnCount { get { return mTurnCount; } set { mTurnCount = value; } }
        public DoublesQueue[] Doubles { get { return mDoublesQueues; } set { mDoublesQueues = value; } }
        public int LastRoll { get; set; }
        public bool IsOver { get; set; }
        public int WinnerID { get; set; }
        //METHODS

        public Player GetActivePlayer()
        {
            Player thisPlayer = this.Players[this.ActivePlayerID];
            return thisPlayer;
        }//GetActivePlayer()

        public Tiles.BoardSpace GetActiveTile()
        {
            Player thisPlayer = this.GetActivePlayer();
            Tiles.BoardSpace thisTile = this.Board.BoardSpaces[thisPlayer.Position];
            return thisTile;
        }//GetActiveTile()

        public void SetState()
            //Used as both the constructor and a publicly callable function to reset the state of the game
        {
            this.Board = new Board();
            this.Players = new Player[2];
            this.Decks = new Deck[2];

            TurnCount = 1;
            ActivePlayerID = 0;

            Players[0] = new Player(0);
            Players[1] = new Player(1);

            Decks[0] = new Deck(1, DeckType.CommunityChest);
            Decks[1] = new Deck(2, DeckType.Chance);

            BoardfileReader reader = new BoardfileReader("Boards\\DefaultBoard.csv");
            Board = reader.CreateBoard();

            //Create an array of queues for each player. This will be used to hold a boolean for 
            //the last three rolls, representing if it was a double.
            mDoublesQueues = new DoublesQueue[Players.Length];
            for (int i = 0; i <= Players.Length - 1; i++)
            {
                mDoublesQueues[i] = new DoublesQueue(new Queue<bool>());
            }//for

            this.LastRoll = 0;
            IsOver = false;
        }//SetState()


    }//class Game

}//Monopoly
