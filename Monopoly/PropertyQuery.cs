using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly
{
    public partial class PropertyQuery : Form
    {
        public PropertyQuery()
        {
            InitializeComponent();
        }

        private void PropertyQuery_Load(object sender, EventArgs e)
        {/*
            Board newBoard = new Board();
            int i = 0;
            for (i = 1; i <= 40; i++)
            {
                cmbProperties.Items.Add(newBoard.BoardSpaces_old[i].Name);
            }//for
            Console.WriteLine("test");*/
        }

        private void cmbProperties_SelectedIndexChanged(object sender, EventArgs e)
        {/*
            Console.WriteLine("Test");
            Board newBoard = new Board();
            BoardSpace_old prop = newBoard.BoardSpaces_old[cmbProperties.SelectedIndex + 1];
            MessageBox.Show("Name: " + prop.Name + "\r\nLocation: " + prop.Location + "\r\nCost: " + prop.Cost + "\r\nColor: " + prop.Color + "\r\nCurrent Rent: " + prop.CurrentRent + "\r\nMortgageValue: " + prop.MortgageValue + "\r\nImprovements: " + prop.Improvements);
          * */
        }
    }
}
