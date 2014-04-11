using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Tiles
{
    class Utility: Tiles.BoardSpace
    {
        private int mMortgageVal;
        private int mCost;

        public Utility(int position, String name):base(position, name){
            this.Position = position;
            this.Name = name;
            this.MortgageVal = 75;
            this.Cost = 150;
        }//Utility()

        public int MortgageVal { get { return mMortgageVal; } private set { mMortgageVal = value; } }
        public int Cost { get { return mCost; } private set { mCost = value; } }

        public int GetBill(int roll, int utilitiesOwned)
        {
            if (utilitiesOwned == 2)
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
