using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

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
        }//TestFunctions()

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

            UI.UIDebug(player1stats);
            UI.UIDebug(player2stats);
        }//TestPropertyBuying()

        public void TestError()
        {
            UI.Error("error message");
        }//TestError()

        public void TestTaxForm()
        {
            TaxDialog form = new TaxDialog();
            DialogResult result = form.ShowDialog(Monopoly);
            switch (result)
            {
                case DialogResult.OK:
                    UI.UIDebug("10% was selected");
                    break;
                case DialogResult.Cancel:
                    UI.UIDebug("$200 was selected");
                    break;
            }//switch
        }

        public void TestIncomeTax()
        {
            Player player1 = ActiveGame.Players[0];
            player1.Position = 1;
            GameLogic.AdvancePlayer(player1.ID, 4); //puts the player on income tax
            UI.UIDebug("player1 stats: " + player1.ToString());
        }//TestIncomeTax()

        public void TestCards()
        {
            ActiveGame.SetState();
            Player player1 = ActiveGame.Players[0];
            Player player2 = ActiveGame.Players[1];

            ActiveGame.ActivePlayerID = 0;
            GameLogic.AdvancePlayer(player1.ID, 2); //places on CommChest
            ActiveGame.ActivePlayerID = 1;
            GameLogic.AdvancePlayer(player2.ID, 22); //places on Chance

            UI.UIDebug(player1.ToString());
            UI.UIDebug(player2.ToString());
        }//TestCards()

        public void TestRRUtilCards()
        {
            //create two players, p1 advances to nearest railroad and buys it
            //p2 advances to nearest rr and must pay doubles
            //reset state
            //p1 advances to nearest utility and buys it
            //p2 advances to nearest utility and must pay 10X roll

            Player player1 = ActiveGame.Players[0];
            Player player2 = ActiveGame.Players[1];
            Card testRRCard = new Card(20, "Advance to RR");
            Card testUtilCard = new Card(19, "Advance to Util");

            ActiveGame.ActivePlayerID = 0;
            CardLogic.HandleCard(testRRCard, 0);
            ActiveGame.ActivePlayerID = 1;
            CardLogic.HandleCard(testRRCard, 1);
            DebugPlayerInfo(player1, player2);

            ActiveGame.SetState(); //reset state
            player1 = ActiveGame.Players[0];
            player2 = ActiveGame.Players[1];

            ActiveGame.ActivePlayerID = 0;
            CardLogic.HandleCard(testUtilCard, 0);
            ActiveGame.ActivePlayerID = 1;
            CardLogic.HandleCard(testUtilCard, 1);
            DebugPlayerInfo(player1, player2);

            //TODO: Test currently fails. Think it has something to do with the ActivePlayer position at the start of the game.
        }//TestRRUtilCards

        public void DebugPlayerInfo(Player player1)
        {
            UI.UIDebug("Player 1 info: " + player1.ToString());
        }//DebugPlayerInfo(Player)

        public void DebugPlayerInfo(Player player1, Player player2)
        {
            UI.UIDebug("Player 1 info: " + player1.ToString());
            UI.UIDebug("Player 2 info: " + player2.ToString());
        }//DebugPlayerInfo(player, player)

        public void TestNewPropClass()
        {
            Tiles.Property prop = new Tiles.Property(5, "testprop", PropertyColor.Brown, 5, new Rent(1, 2, 3, 4, 5, 6), 7);
            UI.UIDebug(prop.ToString());
            Tiles.BuyableSpace buyablespace = prop;
            UI.UIDebug("buyspace cost: " + buyablespace.Cost);
            Tiles.BoardSpace boardspace = prop;
            UI.UIDebug("boardspace name: " + boardspace.Name);
        }//TODO Delete

        public void TestNewUtilandRR()
        {
            Tiles.Utility thisUtil = new Tiles.Utility(5, "Water Works");
            UI.UIDebug(thisUtil.ToString());
            Tiles.Railroad thisRR = new Tiles.Railroad(5, "Reading Rainbow");
            UI.UIDebug(thisRR.ToString());
        }

        public void TestJailCard()
        {
            ActiveGame.ActivePlayerID = 0;
            Player activePlayer = ActiveGame.GetActivePlayer();
            Card jailFreeCard = new Card(23, "Get out of Jail Free");
            Card jailCard = new Card(25, "Go to Jail");
            CardLogic.HandleCard(jailFreeCard, 0);
            CardLogic.HandleCard(jailCard, 0);
            GameLogic.Turn(GameLogic.RollDice());
        }//TestJailCard()

        public void TestUI()
        {
            UI.Display("test");
        }//testUi

    }//TestFunctions
}
