using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class BoardSpace_old
    {
        private String mName;
        private int mCost;
        private String mColor;
        private int mRentDefault;
        private int mRent1;
        private int mRent2;
        private int mRent3;
        private int mRent4;
        private int mRentHotel;
        private int mMortgageValue;
        private int mImprovements;
        private int mOwner; 
        private int mLocation; 
        private String mType;

        public BoardSpace_old(String name, String type, int location, int cost, String color, int rentDefault, int rent1, int rent2, int rent3, int rent4, int rentHotel, int mortgageValue)
        {
            this.Name = name;
            this.Type = type;
            this.Owner = 0;
            this.Location = location;
            this.Cost = cost;
            this.Color = color;
            this.RentDefault = rentDefault;
            this.Rent1 = rent1;
            this.Rent2 = rent2;
            this.Rent3 = rent3;
            this.Rent4 = rent4;
            this.RentHotel = rentHotel;
            this.MortgageValue = mortgageValue;
            this.Improvements = 0;
        }//Property

        public String Name
        {
            get { return mName; }
            set { mName = value; }
        }//Name

        public int Cost //The cost to purchase the property
        {
            get { return mCost; }
            set { mCost = value; }
        }//Cost

        public String Color //The color group of the property. Used to determine if a player can purchase an improvement.
        {
            get { return mColor; }
            set { mColor = value; }
        }//Color

        public int MortgageValue //The money the bank gives the player if the property is mortgaged.
        {
            get { return mMortgageValue; }
            set { mMortgageValue = value; }
        }//MortgageValue

        public int Improvements //Buidings that increase the rent
        {
            get { return mImprovements; }
            set { mImprovements = value; }
        }//Improvements

        public int Owner //The ID of the player that holds the property. ID of 0 = no owner
        {
            get { return mOwner; }
            set { mOwner = value; }
        }//Owner

        public int Location //Physical location on the board
        {
            get { return mLocation; }
            set { mLocation = value; }
        }//Location

        public String Type //property, jail, go to jail, go, chance, free, chest, income tax, luxery tax, railroad, or utility
        {
            get { return mType; }
            set { mType = value; }
        }//Type

        public int CurrentRent
        {
            get{
                int result;
                switch (Improvements)
                {
                    case 0:
                        result = RentDefault;
                        break;
                    case 1:
                        result = Rent1;
                        break;
                    case 2:
                        result = Rent2;
                        break;
                    case 3:
                        result = Rent3;
                        break;
                    case 4:
                        result = Rent4;
                        break;
                    case 5:
                        result = RentHotel;
                        break;
                    default:
                        result = RentDefault;
                        break;
                }//switch
                return result;
            }//get
        }//CurrentRent

        public int RentDefault //What a player pays the owner when landing on this space with no improvements
        {
            get { return mRentDefault; }
            set { mRentDefault = value; }
        }//RentDefault

        private int Rent1 //what a player pays the owner if there is 1 house
        {
            get { return mRent1; }
            set { mRent1 = value; }
        }//Rent1

        private int Rent2
        {
            get { return mRent2; }
            set { mRent2 = value; }
        }//Rent2

        private int Rent3
        {
            get { return mRent3; }
            set { mRent3 = value; }
        }//Rent3

        private int Rent4
        {
            get { return mRent4; }
            set { mRent4 = value; }
        }//Rent4

        private int RentHotel
        {
            get { return mRentHotel; }
            set { mRentHotel = value; }
        }//RentHotel

        public String toString()
        {
            String result;
            result = this.Name + " " + this.Type + " " + this.Color + " " + this.Owner;
            return result;
        }//toString

    }//class Property
}
