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

        public Monopoly()
        {
            InitializeComponent();
            ActiveGame = new GameState();
            this.MoneyLogic = new MoneyLogic(ref ActiveGame);
            MoneyLogic refMoneyLogic = new MoneyLogic(ref ActiveGame); //clone of logic objects for the CardLogic and GameLogic constructor
            GameLogic refGameLogic = new GameLogic(ref ActiveGame);    //the card logic deals with both money and player positions, so both were needed
            this.GameLogic = new GameLogic(ref ActiveGame);
            this.CardLogic = new CardLogic(ref ActiveGame, ref refMoneyLogic, ref refGameLogic);
            this.UI = new UI(ref ActiveGame);
        }//Monopoly()


        //PROPERTIES

        public GameState ActiveGame;
        public GameLogic GameLogic { get { return mGameLogic; } set { mGameLogic = value; } }
        public MoneyLogic MoneyLogic { get { return mMoneyLogic; } set { mMoneyLogic = value; } }
        public CardLogic CardLogic { get { return mCardLogic; } set { mCardLogic = value; } }
        private UI UI { get; set; }

        //METHODS

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
            if (ActiveGame != null)
            {
                GameLogic.StartGame();
            }
        }//btnStart_Click

        private void IndicateActivePlayer()
        {
            //foreach (Control c in Controls)
            //{
            //    if (c.GetType == Label)
            //    {

            //    }
            //    c.ForeColor = System.Drawing.Color.Black;
            //}//foreach

            if (ActiveGame.ActivePlayerID == 0){
                lblPlayer1.ForeColor = System.Drawing.Color.Green;
            } else if (ActiveGame.ActivePlayerID == 1){
                lblPlayer2.ForeColor = System.Drawing.Color.Green;
            }//if

        }//IndicateActivePlayer

        private void btnTest_Click(object sender, EventArgs e)
        {


            

        }





    }//Monopoly
}
