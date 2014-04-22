using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Monopoly
{
    public class Board
    {   
        private Tiles.BoardSpace[] mBoardSpaces;
        private ColorGroup[] mColorGroups;
        private Tiles.Jail mJail;

        public Board()
        {

            //create BoardSpaces
            //initialize ColorGroups
            //set Jail

            BoardSpaces = new Tiles.BoardSpace[41];
            BoardSpaces[0] = new Tiles.FreeParking(0, "ERROR- TILE POSITION 0"); //To make sure there's not any null boardspaces
            ColorGroups = new ColorGroup[8];
            ColorGroups[0] = new ColorGroup(0, PropertyColor.Brown);
            ColorGroups[1] = new ColorGroup(1, PropertyColor.LightBlue);
            ColorGroups[2] = new ColorGroup(2, PropertyColor.Pink);
            ColorGroups[3] = new ColorGroup(3, PropertyColor.Orange);
            ColorGroups[4] = new ColorGroup(4, PropertyColor.Red);
            ColorGroups[5] = new ColorGroup(5, PropertyColor.Yellow);
            ColorGroups[6] = new ColorGroup(6, PropertyColor.Green);
            ColorGroups[7] = new ColorGroup(7, PropertyColor.DarkBlue);


        }//Board

        public ColorGroup[] ColorGroups { get { return mColorGroups; } private set { mColorGroups = value; } }
        public Tiles.BoardSpace[] BoardSpaces { get { return mBoardSpaces; } set { mBoardSpaces = value; } }
        public Tiles.Jail Jail { get { return mJail; } private set { mJail = value; } }


        //METHODS
        public override string ToString()
        {
            String result = String.Empty;
            
            foreach (Tiles.BoardSpace b in BoardSpaces)
            {
                result = result + b.ToString() + Environment.NewLine;
            }//foreach

            
            return result;
        }//ToString


    }//class Board
}
