using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Card
    {
        private int mCardID;
        private String mDescription;

        public Card(int cardID, String description)
        {
            this.CardID = cardID;
            this.Description = description;
        }

        //PROPERTIES
        //Immutable
        public int CardID { get { return mCardID; } private set { mCardID = value; } }
        public String Description { get { return mDescription; } private set { mDescription = value; } }

        //METHODS
        override public String ToString()
        {
            return (CardID + ": " + Description);
        }

    }//Card
}
