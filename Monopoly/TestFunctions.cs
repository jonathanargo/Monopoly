﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Monopoly
{
    public class TestFunctions
    {
        public TestFunctions(ref Monopoly monopoly)
        {
            this.Monopoly = monopoly;
            this.ActiveGame = monopoly.ActiveGame;
            this.GameLogic = monopoly.GameLogic;
            this.MoneyLogic = monopoly.MoneyLogic;
            this.CardLogic = monopoly.CardLogic;
            this.UI = monopoly.UI;            
        }

        private Monopoly Monopoly { get; set; }
        private GameState ActiveGame { get; set; }
        private GameLogic GameLogic { get; set; }
        private MoneyLogic MoneyLogic { get; set; }
        private CardLogic CardLogic { get; set; }
        private UI UI { get; set; }


        public void TestPropertyBuying()
        {
            //Create players, then advance one to Baltic Ave. Then, have the 
            //other one go to it and pay him rent. Finally, print out the
            //stats on both players

            Player player1 = ActiveGame.Players[0];
            Player player2 = ActiveGame.Players[1];
            GameLogic.AdvancePlayer(0, 3); //Advances player to Baltic Ave
            Tiles.Property baltic = (Tiles.Property)ActiveGame.Board.BoardSpaces[4];
            baltic.Improve(2);
            ActiveGame.ActivePlayerID = 1; //changes active player ID to 1 for the purposes of the game logic
            GameLogic.AdvancePlayer(1, 3); //Advance second player to BA

            String player1stats = player1.ToString() + Environment.NewLine + player1.PropsToString();
            String player2stats = player2.ToString() + Environment.NewLine + player2.PropsToString();

            Debug.WriteLine(player1stats);
            Debug.WriteLine("");
            Debug.WriteLine(player2stats);
        }//TestPropertyBuying()
    }
}
