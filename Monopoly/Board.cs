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
            BoardSpaces[0] = new Tiles.BoardSpace(0, "ERROR- TILE POSITION 0"); //To make sure there's not any null boardspaces


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
