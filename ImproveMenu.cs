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
    public partial class ImproveMenu : Form
    {
        public ImproveMenu(Monopoly monopoly)
        {
            InitializeComponent();
            this.MonopolyRef = monopoly;
            this.GameRef = monopoly.ActiveGame;
            PropList = new List<Tiles.Property>();
            PopulateProps();
        }//ImproveMenu()

        private Monopoly MonopolyRef { get; set; }
        private GameState GameRef { get; set; }
        private List<Tiles.Property> PropList { get; set; }

        private void PopulateProps()
        {            
            foreach (Tiles.BoardSpace b in GameRef.Board.BoardSpaces)
            {
                if (b.SpaceType == "Property")
                {
                    Tiles.Property thisProp = (Tiles.Property)b;
                    if (thisProp.OwnerID == GameRef.ActivePlayerID)
                    {
                        PropList.Add(thisProp);
                        lbxPropList.Items.Add(thisProp.Name + ": $" + thisProp.ImprovementCost);
                    }//if
                }//if
            }//foreach
        }

        private void btnImprove_Click(object sender, EventArgs e)
        {
            if ((lbxPropList.Items.Count > 0) && (lbxPropList.SelectedIndex != null))
            //if the box has been populated
            {
                Tiles.Property thisProp = PropList[lbxPropList.SelectedIndex];
                MonopolyRef.GameLogic.BuyImprovement(thisProp);
            }
            else
            {
                MonopolyRef.UI.Error("Please ensure that the property list has been populated and you've selected a property!");
            }//if-else
        }//PopulateProps()


    }//ImproveMenu
}
