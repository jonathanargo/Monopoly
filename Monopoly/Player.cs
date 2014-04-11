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
        private Boolean mHasJailFreeCard;
        private int mRailroads;
        private int mUtilities;

        public Player(int id)
        {
            this.Money = 1500;
            this.ID = id;
            this.Position = 1;
            this.HasJailFreeCard = false;
            this.Railroads = 0;
            this.Utilities = 0;

        }//Player

        
        //PROPERTIES
        public int ID { get { return mID; } private set { mID = value; } }
        public int Money { get { return mMoney; } set { mMoney = value; } }
        public Boolean HasJailFreeCard { get { return mHasJailFreeCard; } set { mHasJailFreeCard = value; } }
        public int Railroads { get { return mRailroads; } set { mRailroads = value; } }
        public int Utilities { get { return mUtilities; } set { mUtilities = value; } }
        public int Position //between 1 and 40        
        {
            get { return mPosition; }
            set
            {
                if (value > 40)
                {
                    mPosition = value - 40;
                    Debug.WriteLine("Player position " + value + " is greater than 40. Position set to " + (value - 40));
                }//if
            }
        }//Position


        //METHODS





    }//Player
}
