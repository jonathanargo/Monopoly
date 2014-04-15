using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Tiles
{
    public class Railroad: Tiles.BoardSpace
    {
        private int mCost;
        private int mFare;
        private int mMortgageVal;
        private int mOwnerID;

        public Railroad(int position, String name): base(position, name, "Railroad")
        {
            this.Position = position;
            this.Name = name;
            this.Cost = 200;
            this.BaseFare = 25;
            this.MortgageVal = 100;
            this.mOwnerID = -1; //interpreted as no owner
        }//Railroad()

        //PROPERTIES
        //Immutable
        public int Cost { get { return mCost; } private set { mCost = value; } }
        public int BaseFare { get { return mFare; } private set { mFare = value; } }
        public int MortgageVal { get { return mMortgageVal; } private set { mMortgageVal = value; } }
        //Mutable
        public int OwnerID { get { return mOwnerID; } set { mOwnerID = value; } }

        //public int CurrentFare() { return 0; }

    }
}
