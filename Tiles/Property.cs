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
            SetImprovementCost();
        }


        //Public Set
        public ImprovementLevel ImprovementLevel { get { return mImprovementLvl; } private set { mImprovementLvl = value; } }

        //Private Set (immutable)
        public PropertyColor Color { get { return mColor; } private set { mColor = value; } }
        public Rent Rent { get { return mRent; } private set { mRent = value; } }
        public int ImprovementCost { get; private set; }

        public int CurrentRent()
        {
            return this.Rent.GetRentLevel(ImprovementLevel);
        }//CurrentRent
                
        public void Improve(int numLevels)
        {
            int intCurLevel = (int)this.ImprovementLevel;
            UI ui = new UI();
            if (intCurLevel + numLevels <= 5)
            {
                this.ImprovementLevel = (ImprovementLevel)intCurLevel + numLevels;
                ui.UIDebug(this.Name + " improvement level set to " + this.ImprovementLevel);
            }
            else
            {                
                ui.Error("Improvement level can not exceed 5.");
            }//else
        }//Improve()

        private void SetImprovementCost()
        {
            int improveCost;
            if ((int)this.Color <= 1) { improveCost = 50; } //brown (0), and light blue(1)
            else if ((int)this.Color <= 3) { improveCost = 100; } //pink(2) and orange(3)
            else if ((int)this.Color <= 5) { improveCost = 150; } //red(4) and yellow(5)
            else { improveCost = 200; }//green(6) and darkblue(7)

            this.ImprovementCost = improveCost;
        }


        public override string ToString()
        {
            String result = base.ToString();
            result += String.Format(", Color: {0}, CurrentRent: {1}, ImprovementLevel: {2}", Color, CurrentRent(), ImprovementLevel);
            return result;
        }//ToString()

    }//class Property: BoardSpace
}
