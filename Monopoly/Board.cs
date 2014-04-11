using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Board
    {   
        private Tiles.BoardSpace[] mBoardSpaces;
        private ColorGroup[] mColorGroups;
        private Tiles.Jail mJail;

        public Board()
        {

            //create boardfile reader, read boardfile, create BoardSpaces
            //initialize ColorGroups
            //set Jail


        }//Board

        public ColorGroup[] ColorGroups { get { return mColorGroups; } private set { mColorGroups = value; } }
        public Tiles.BoardSpace[] BoardSpaces { get { return mBoardSpaces; } set { mBoardSpaces = value; } }
        public Tiles.Jail Jail { get { return mJail; } private set { mJail = value; } }



    }//class Board
}
