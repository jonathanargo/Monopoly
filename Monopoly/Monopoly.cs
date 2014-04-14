﻿using System;
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
        private GameState mGame;
        private GameLogic mGameLogic;
        private MoneyLogic mMoneyLogic;
        private TileLogic mTileLogic;
        private CardLogic mCardLogic;
        public Monopoly()
        {
            InitializeComponent();
            ActiveGame = new GameState();
            this.GameLogic = new GameLogic(ref ActiveGame);
            this.CardLogic = new CardLogic(ref ActiveGame);
            this.MoneyLogic = new MoneyLogic(ref ActiveGame);
            this.TileLogic = new TileLogic(ref ActiveGame);

        }//Monopoly()


        //PROPERTIES

        public GameState ActiveGame;
        public GameLogic GameLogic { get { return mGameLogic; } set { mGameLogic = value; } }
        public TileLogic TileLogic { get { return mTileLogic; } set { mTileLogic = value; } }
        public MoneyLogic MoneyLogic { get { return mMoneyLogic; } set { mMoneyLogic = value; } }
        public CardLogic CardLogic { get { return mCardLogic; } set { mCardLogic = value; } }

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
                ActiveGame.StartGame();
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

            if (ActiveGame.ActivePlayer.ID == 1){
                lblPlayer1.ForeColor = System.Drawing.Color.Green;
            } else if (ActiveGame.ActivePlayer.ID == 2){
                lblPlayer2.ForeColor = System.Drawing.Color.Green;
            }//if

        }//IndicateActivePlayer

        private void btnTest_Click(object sender, EventArgs e)
        {




        }





    }
}
