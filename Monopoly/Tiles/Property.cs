using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Tiles
{
    public class Property: Tiles.BoardSpace
    {
        private int mOwnerID;
        private PropertyColor mColor;
        private Rent mRent;
        private int mMortgageVal;
        private ImprovementLevel mImprovementLvl;
        private int mCost;

        public Property(int position, String name, PropertyColor color, int cost, Rent rent, int mortgageVal)
            : base(position, name)
        {
            this.Position = position;
            this.Name = name;
            this.OwnerID = -1; //interpreted as no owner
            this.Color = color;
            this.Cost = cost;
            this.Rent = rent;
            this.ImprovementLevel = ImprovementLevel.NoImprovement; //all spaces start with no improvements
            this.MortgageVal = mortgageVal;
        }


        //Public Set
        public int OwnerID { get { return mOwnerID; } set { mOwnerID = value; } }
        public ImprovementLevel ImprovementLevel { get { return mImprovementLvl; } private set { mImprovementLvl = value; } }

        //Private Set (immutable)
        public PropertyColor Color { get { return mColor; } private set { mColor = value; } }
        public Rent Rent { get { return mRent; } private set { mRent = value; } }
        public int MortgageVal { get { return mMortgageVal; } private set { mMortgageVal = value; } }
        public int Cost { get { return mCost; } private set { mCost = value; } }

        public int CurrentRent()
        {
            return this.Rent.GetRentLevel(ImprovementLevel);
        }//CurrentRent


        public override string ToString()
        {
            String result = base.ToString();
            result = (result + ", Color: " + this.Color.ToString() + ", Cost: " + this.Cost + ", MortgageVal: " + this.MortgageVal);
            return result;
        }

    }//class Property: BoardSpace
}
