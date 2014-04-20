using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Monopoly.Properties;
using System.IO;
using System.Timers;


namespace Monopoly
{
    public partial class Monopoly : Form
    {
        private GameLogic mGameLogic;
        private MoneyLogic mMoneyLogic;
        private CardLogic mCardLogic;
        private Monopoly refMonopoly;

        public Monopoly()
        {
            InitializeComponent();            
            this.ReadyToStart = false;
            this.TestMode = false;
            this.TestState = 1;
        }//Monopoly()

        //PROPERTIES

        public GameState ActiveGame { get; set; }
        public GameLogic GameLogic { get { return mGameLogic; } set { mGameLogic = value; } }
        public MoneyLogic MoneyLogic { get { return mMoneyLogic; } set { mMoneyLogic = value; } }
        public CardLogic CardLogic { get { return mCardLogic; } set { mCardLogic = value; } }
        public UI UI { get; set; }
        public bool ReadyToStart { get; private set; }
        private TestFunctions Test { get; set; }
        public bool TestMode { get; private set; }
        public int TestState { get; set; }

        //METHODS

        public void PrepareGame()
        {
            refMonopoly = this;
            ActiveGame = new GameState();   //called first, since UI needs it
            this.UI = new UI(ref refMonopoly);
            UI.WriteToLog("");
            UI.UIDebug("A new game is being prepared");                      
            IntializeLogic();            
            ReadyToStart = true;
            UI.UIDebug("Game has been prepared.");
        }

        public void IntializeLogic()
        {
            GameLogic = new GameLogic(ref refMonopoly);
            CardLogic = new CardLogic(ref refMonopoly);
            MoneyLogic = new MoneyLogic(ref refMonopoly);
            GameLogic.Initialize();
            CardLogic.Initialize();
            MoneyLogic.Initialize();
        }//InitializeLogic

        public void SetTestMode()
        {
            PrepareGame();
            refMonopoly = this;
            Test = new TestFunctions(ref refMonopoly);
            TestMode = true;
        }//SetTestMode()

        private void Monopoly_Paint(object sender, PaintEventArgs e)
        {
            /*
             * //This draws two rectangles that were once going to display the space each player was on, but it's no longer necessary
             * TODO: Clean up
            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            Pen myPen = new Pen(System.Drawing.Color.Black, 2);
            Rectangle rect = new Rectangle(125, 75, 200, 250);
            graphicsObj.DrawRectangle(myPen, rect); //player 1's rectangle
            graphicsObj.DrawLine(myPen, 375, 20, 375, 400); //the division between the players
            rect = new Rectangle(425, 75, 200, 250);
            graphicsObj.DrawRectangle(myPen, rect); //player 2's rectangle
             * */

        }//Paint

        private void Form1_Load(object sender, EventArgs e)
        {
            PrepareGame();
            P1GoojOut.Text = String.Empty;
            P1MoneyOut.Text = String.Empty;
            P1PosOut.Text = String.Empty;
            P2GoojOut.Text = String.Empty;
            P2MoneyOut.Text = String.Empty;
            P2PosOut.Text = String.Empty;
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            if (ReadyToStart)
            {
                GameLogic.StartGame();
            }
            else
            {
                PrepareGame();
                UI.Error("Game was not ready. Game was prepared. Try again.");
            }//else
        }//btnStart_Click

        private void OpenDialog(Form form)
        {
            form.ShowDialog(this);
        }//OpenDialog        

        public void HandleOutput(String output)
        {
            lbxOutput.Items.Add(output);
            lbxOutput.SelectedIndex = lbxOutput.Items.Count - 1;
        }//HandleOutput

        public void SyncPlayerStats()
        {
            Player p1 = ActiveGame.Players[0];
            Player p2 = ActiveGame.Players[1];

            P1MoneyOut.Text = p1.Money.ToString();
            P1PosOut.Text = String.Format("{0}: {1}", p1.Position, ActiveGame.Board.BoardSpaces[p1.Position].Name);
            P1GoojOut.Text = p1.JailFreeCards.ToString();

            P2MoneyOut.Text = p2.Money.ToString();
            P2PosOut.Text = String.Format("{0}: {1}", p2.Position, ActiveGame.Board.BoardSpaces[p2.Position].Name);
            P2GoojOut.Text = p2.JailFreeCards.ToString();

            P1OwnedPropsOut.Items.Clear();
            P2OwnedPropsOut.Items.Clear();

            foreach(Tiles.BuyableSpace p in p1.OwnedProperties) { P1OwnedPropsOut.Items.Add(p.Name); }
            foreach (Tiles.BuyableSpace p in p2.OwnedProperties) { P2OwnedPropsOut.Items.Add(p.Name); }

            if (p1.Railroads > 0) { P1OwnedPropsOut.Items.Add("Railroads: " + p1.Railroads); }
            if (p1.Utilities > 0) { P1OwnedPropsOut.Items.Add("Utilities: " + p1.Utilities); }
            if (p2.Railroads > 0) { P2OwnedPropsOut.Items.Add("Railroads: " + p2.Railroads); }
            if (p2.Utilities > 0) { P2OwnedPropsOut.Items.Add("Utilities: " + p2.Utilities); }
        }//SyncPlayerStats()

        private void btnRoll_Click(object sender, EventArgs e)
        {
            GameLogic.Roll();
        }

        public void EnableStartButton()
        {
            btnStart.Enabled = true;
        }//EnableStartButton()

        public void DisableStartButton()
        {
            btnStart.Enabled = false;
        }//DisableStartButton()
        
        public void EnableRollButton()
        {
            btnRoll.Enabled = true;
        }//EnableRollButton()

        public void DisableRollButton()
        {
            btnRoll.Enabled = false;
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            Monopoly thisRef = this;
            DebuggingForm debug = new DebuggingForm(ref thisRef);
            debug.Show();
        }//DisableRollButton()

        public void IndicateActivePlayer()
        {
            //Set the label of the active player to green
            //TODO: use system colors rather than hard-coded values
            if (ActiveGame.ActivePlayerID == 0)
            {
                lblPlayer1.ForeColor = Color.Green;
                lblPlayer2.ForeColor = Color.Black;
            }
            else
            {
                lblPlayer1.ForeColor = Color.Black;
                lblPlayer2.ForeColor = Color.Green;
            }
            this.Refresh();
        }

        private void Monopoly_FormClosing(object sender, FormClosingEventArgs e)
        {
            UI.UIDebug("Game form is closing");
        }

        private void btnTest_Click_1(object sender, EventArgs e)
        {
            
        }

    }//Monopoly
}