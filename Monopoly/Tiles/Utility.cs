using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Tiles
{
    public class Utility: Tiles.BuyableSpace
    {
        public Utility(int position, String name):base(position, name, 150, 75, "Utility"){

        }//Utility()

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
        }//GetBill

        public override string ToString()
        {
            return base.ToString();
        }//ToString()

    }//Utility
}
