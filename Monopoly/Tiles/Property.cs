using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Tiles
{
    public class Property: Tiles.BoardSpace
    {
        private int mOwner;
        private PropertyColor mColor;
        private Rent mRent;
        private int mMortgageVal;
        private ImprovementLevel mImprovementLvl;

        public Property(int position, String name, PropertyColor color, Rent rent, int mortgageVal)
            : base(position, name)
        {
            this.Position = position;
            this.Name = name;
            this.Owner = -1; //interpreted as no owner
            this.Color = color;
            this.Rent = rent;
            this.ImprovementLevel = ImprovementLevel.NoImprovement; //all spaces start with no improvements
            this.MortgageVal = mortgageVal;
        }


        //Public Set
        public int Owner { get { return mOwner; } set { mOwner = value; } }
        public ImprovementLevel ImprovementLevel { get { return mImprovementLvl; } private set { mImprovementLvl = value; } }

        //Private Set (immutable)
        public PropertyColor Color { get { return mColor; } private set { mColor = value; } }
        public Rent Rent { get { return mRent; } private set { mRent = value; } }
        public int MortgageVal { get { return mMortgageVal; } private set { mMortgageVal = value; } }

        public int CurrentRent()
        {
            return this.Rent.GetRentLevel(ImprovementLevel);
        }//CurrentRent

    }//class Property: BoardSpace
}
