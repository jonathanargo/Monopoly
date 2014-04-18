using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Monopoly.Tiles
{
    public class Property : Tiles.BuyableSpace
    {
        private PropertyColor mColor;
        private Rent mRent;
        private ImprovementLevel mImprovementLvl;

        public Property(int position, String name, PropertyColor color, int cost, Rent rent, int mortgageVal)
            : base(position, name, cost, mortgageVal, "Property")
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
        public ImprovementLevel ImprovementLevel { get { return mImprovementLvl; } private set { mImprovementLvl = value; } }

        //Private Set (immutable)
        public PropertyColor Color { get { return mColor; } private set { mColor = value; } }
        public Rent Rent { get { return mRent; } private set { mRent = value; } }

        public int CurrentRent()
        {
            return this.Rent.GetRentLevel(ImprovementLevel);
        }//CurrentRent
                
        public void Improve(int numLevels)
        {
            int intCurLevel = (int)this.ImprovementLevel;
            if (intCurLevel + numLevels <= 5)
            {
                this.ImprovementLevel = (ImprovementLevel)intCurLevel + numLevels;
                Debug.WriteLine("Improvement level set to " + this.ImprovementLevel);
            }
            else
            {
                UI ui = new UI();
                ui.Error("Improvement level can not exceed 5.");
            }//else
        }//Improve()

        public override string ToString()
        {
            String result = base.ToString();
            result += String.Format(", Color: {0}, CurrentRent: {1}, ImprovementLevel: {2}", Color, CurrentRent(), ImprovementLevel);
            return result;
        }//ToString()

    }//class Property: BoardSpace
}
