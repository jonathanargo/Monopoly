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
            this.GameIsReady = false;
            this.TestMode = false;
        }//Monopoly()

        //PROPERTIES

        public GameState ActiveGame;
        public GameLogic GameLogic { get { return mGameLogic; } set { mGameLogic = value; } }
        public MoneyLogic MoneyLogic { get { return mMoneyLogic; } set { mMoneyLogic = value; } }
        public CardLogic CardLogic { get { return mCardLogic; } set { mCardLogic = value; } }
        public UI UI { get; set; }
        public bool GameIsReady { get; private set; }
        private TestFunctions Test { get; set; }
        public bool TestMode { get; private set; }

        //METHODS

        public void PrepareGame()
        {
            ActiveGame = new GameState();
            this.UI = new UI(ref ActiveGame);
            IntializeLogic();
            GameIsReady = true;
            Debug.WriteLine("Game has been prepared.");
        }

        public void IntializeLogic()
        {
            refMonopoly = this;
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
            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            Pen myPen = new Pen(System.Drawing.Color.Black, 2);
            Rectangle rect = new Rectangle(125, 75, 200, 250);
            graphicsObj.DrawRectangle(myPen, rect); //player 1's rectangle
            graphicsObj.DrawLine(myPen, 375, 20, 375, 400); //the division between the players
            rect = new Rectangle(425, 75, 200, 250);
            graphicsObj.DrawRectangle(myPen, rect); //player 2's rectangle

        }//Paint

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            if (GameIsReady)
            {
                //Do stuff (TODO)
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

        private void IndicateActivePlayer()
        {
            //foreach (Control c in Controls)
            //{
            //    if (c.GetType == Label)
            //    {

            //    }
            //    c.ForeColor = System.Drawing.Color.Black;
            //}//foreach TODO

            if (ActiveGame.ActivePlayerID == 0){
                lblPlayer1.ForeColor = System.Drawing.Color.Green;
            } else if (ActiveGame.ActivePlayerID == 1){
                lblPlayer2.ForeColor = System.Drawing.Color.Green;
            }//if

        }//IndicateActivePlayer TODO

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (!TestMode)
            {
                SetTestMode();
            }

            Test.TestRRUtilCards();    
        }//btnTest_Click()

    }//Monopoly
}

//TODO: Find out why it's not printing debug info for buying properties