using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Rent
    {

        private int[] mRentArray;

        public Rent(int rentDefault, int rentOneHouse, int rentTwoHouses, int rentThreeHouses, int rentFourHouses, int rentHotel)
        {
            RentArray = new int[6] { rentDefault, rentOneHouse, rentTwoHouses, rentThreeHouses, rentFourHouses, rentHotel };

        }//Rent

        public int GetRentLevel(ImprovementLevel improvementLvl)
        {
            int improveInt = (int)improvementLvl;
			return RentArray[improveInt];
        }//GetCurrentRent

        public int[] RentArray
        {
            get { return mRentArray; }
            private set { mRentArray = value; }
        }


    }//class Rent
}
