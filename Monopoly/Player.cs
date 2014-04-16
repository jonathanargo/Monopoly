using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Monopoly
{
    public class Player
    {
        private int mID;
        private int mMoney;
        private int mPosition;
        private int mJailFreeCards;
        private Boolean mIsJailed;
        private int mRailroads;
        private int mUtilities;

        public Player(int id)
        {
            this.Money = 1500;
            this.ID = id;
            this.Position = 1;
            this.JailFreeCards = 0;
            this.Railroads = 0;
            this.Utilities = 0;
            this.OwnedProperties = new List<Tiles.Property>();
            this.GameID = this.ID + 1;

        }//Player

        
        //PROPERTIES
        public int ID { get { return mID; } private set { mID = value; } } //represents GameState.Players array index
        public int Money { get { return mMoney; } set { mMoney = value; } }
        public int JailFreeCards { get { return mJailFreeCards; } set { mJailFreeCards = value; } }
        public int Railroads { get { return mRailroads; } set { mRailroads = value; } }
        public int Utilities { get { return mUtilities; } set { mUtilities = value; } }
        public Boolean IsJailed { get { return mIsJailed; } set { mIsJailed = value; } }
        public List<Tiles.Property> OwnedProperties { get; private set; }
        public int GameID { get; private set; } //represents player number as it appears to user

        public int Position //between 1 and 40        
        {
            get { return mPosition; }
            set
            {
                if (value > 40)
                {
                    mPosition = value - 40;
                    Debug.WriteLine("Player position " + value + " is greater than 40. Position set to " + (value - 40));
                }
                else
                {
                    mPosition = value;
                }//ifelse
            }//set
        }//Position

        //METHODS

        public String PropsToString()
        {
            String result = String.Empty;
            foreach (Tiles.Property p in OwnedProperties)
            {
                result += p.Name + Environment.NewLine;
            }//foreach

            return result;
        }//PropsString

        public override string ToString()
        {
            String result;
            result = String.Format("ID: {0}, Position: {1}, Money: {2}, Jailed: {3}, JailFreeCards: {4}", this.ID, this.Position, this.Money, this.IsJailed, this.JailFreeCards);
            return result;
        }//ToString()




    }//Player
}
