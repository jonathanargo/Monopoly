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
using System.IO;

namespace Monopoly
{
    public partial class DebuggingForm : Form
    {
        public DebuggingForm(ref Monopoly monopoly)
        {
            InitializeComponent();
            this.MonopolyRef = monopoly;
            this.Game = monopoly.ActiveGame;
            this.SelectedID = 0;

            foreach (Tiles.BoardSpace b in Game.Board.BoardSpaces)
            {
                lbxBoardSpaces.Items.Add(b.Position + ": " + b.Name);
            }//foreach

            toolTip1.SetToolTip(btnCopyLog, "Copies the log of the current session to a new file");
        }//DebuggingForm

        private Monopoly MonopolyRef { get; set; }
        private GameState Game { get; set; }
        private int SelectedID { get; set; }
        
        private void btnSendToPos_Click_1(object sender, EventArgs e)
        {
            if (Game.IsStarted == true)
            {
                MonopolyRef.GameLogic.AdvancePlayerToPosition(SelectedID, lbxBoardSpaces.SelectedIndex);
            }
            else
            {
                MessageBox.Show("You can't send a player to a position until the game has been started.", "Error");
            }
        }

        private void btnGoToJail_Click(object sender, EventArgs e)
        {
            lbxBoardSpaces.SelectedIndex = 31;
        }

        private void btnGoToProp_Click(object sender, EventArgs e)
        {
            lbxBoardSpaces.SelectedIndex = 4;
        }

        private void btnGoToRailroad_Click(object sender, EventArgs e)
        {
            lbxBoardSpaces.SelectedIndex = 16;
        }

        private void btnGoToChance_Click_1(object sender, EventArgs e)
        {
            lbxBoardSpaces.SelectedIndex = 8;
        }

        private void btnGoToUtil_Click(object sender, EventArgs e)
        {
            lbxBoardSpaces.SelectedIndex = 29;
        }

        private void btnGoToGo_Click(object sender, EventArgs e)
        {
            lbxBoardSpaces.SelectedIndex = 1;
        }

        private void rbtPlayer1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtPlayer1.Checked == true)
            {
                SelectedID = 0;
            }
            else
            {
                SelectedID = 1;
            }//if-else
            MessageBox.Show(SelectedID.ToString());
        }

        private void btnPrintStats_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Game.Players[SelectedID].ToString(), String.Format("Player {0} Stats", SelectedID + 1)); 
        }

        private void btnTruncateLog_Click(object sender, EventArgs e)
        {
            File.Delete("Log.txt");
            MonopolyRef.UI.DisplayPopup("Log has been truncated on the debug menu", "Log truncated");
        }






    }
}
