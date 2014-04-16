using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Tiles
{
    public class Utility: Tiles.BoardSpace
    {
        private int mMortgageVal;
        private int mCost;
        private int mOwnerID;

        public Utility(int position, String name):base(position, name, "Utility"){
            this.Position = position;
            this.Name = name;
            this.MortgageVal = 75;
            this.Cost = 150;
            this.OwnerID = -1;
        }//Utility()

        public int MortgageVal { get { return mMortgageVal; } private set { mMortgageVal = value; } }
        public int Cost { get { return mCost; } private set { mCost = value; } }
        public int OwnerID { get { return mOwnerID; } set { mOwnerID = value; } }

        public int GetBill(int roll, int utilitiesOwned)
        {
            if (utilitiesOwned > 1)
            {
                return roll * 10;
            }
            else
            {
                return roll * 4;
            }
        }//Bil

    }//Utility
}
