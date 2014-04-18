using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Tiles
{
    public abstract class BuyableSpace : Tiles.BoardSpace
    {
        public BuyableSpace(int position, String name, int cost, int mortgageVal, String spaceType): base(position, name, spaceType)
        {
            this.Position = position;
            this.Name = name;
            this.OwnerID = -1;
            this.Cost = cost;
            this.MortgageVal = mortgageVal;
            this.SpaceType = spaceType; //TODO: Change to enum, messy
        }//BuyableSpace()

        public int OwnerID { get; set; }
        public int Cost { get; protected set; }
        public int MortgageVal { get; protected set; }

        public override string ToString()
        {
            String result = String.Format("{0} Name: {1}, Cost: {2}, MortgageVal: {3}, SpaceType: {4}", Position, Name, Cost, MortgageVal, SpaceType);
            return result;
        }//ToString()

    }//BuyableSpace
}
