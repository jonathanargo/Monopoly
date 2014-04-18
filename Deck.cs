using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.Properties;
using System.IO;
using System.Diagnostics;

namespace Monopoly
{
    public class Deck
    {
        private int mID;
        private DeckType mDecktype;
        private Card[] mCards;

        public Deck(int id, DeckType type)
        {
            this.ID = id;
            this.DeckType = type;
            ShuffleDeck();

        }//Deck()


        //PROPERTIES
        public int ID { get { return mID; } private set { mID = value; } }
        public DeckType DeckType { get { return mDecktype; } set { mDecktype = value; } }
        public Card[] Cards { get { return mCards; } set { mCards = value; } }
        private int TopCardIndex; //represents the top card on the deck, ie the first non-discarded card


        //METHODS
        //called when deck is initialized
        public void ShuffleDeck()
        {

            String allDescriptions = Resources.CardDescriptions;
            int cardIDMod = 0; //used to assign correct cardIDs

            if (this.DeckType == DeckType.CommunityChest)
            {
                Cards = new Card[17]; //wipe deck
                allDescriptions = allDescriptions.Substring(16, allDescriptions.IndexOf("Chance")); //+14 for 'communitychest', +2 for cr and lf
                Debug.WriteLine("Community Chest Deck initializing...");
            } else {
                Cards = new Card[16];
                cardIDMod = 17; 
                allDescriptions = allDescriptions.Substring(allDescriptions.IndexOf("Chance") + 8); //+6 for 'chance', + 2 for cr and lf
                Debug.WriteLine("Chance Deck initializing...");
            }
            
            String[] cardDescriptions = new String[Cards.Length];
            Card[] orderedCards = new Card[Cards.Length];

            StringReader reader = new StringReader(allDescriptions);
            
            for(int i = 0; i <= (Cards.Length - 1); i++)
            {
                String line = reader.ReadLine();
                orderedCards[i] = new Card(i + cardIDMod, line);
            }//foreach            
            reader.Close();
            Debug.WriteLine("Deck is now in proper order. Shuffling...");

            //Begin Fisher-Yates shuffling algorithm
            Random rand = new Random();
            int n = orderedCards.Length;
            for(int i = 0; i <= n - 1; i++)
            {
                int j = rand.Next(i, n);
                Card tempCard = orderedCards[i];
                orderedCards[i] = orderedCards[j];
                orderedCards[j] = tempCard;
            }//for

            this.Cards = orderedCards;
            this.TopCardIndex = 0;
            Debug.WriteLine("Deck has been shuffled.");

        }//ShuffleDeck

        public Card DrawCard()
        {
            Card topCard = Cards[this.TopCardIndex];
            this.TopCardIndex++;
            if (TopCardIndex > Cards.Length - 1)
            {
                this.ShuffleDeck();
                topCard = Cards[this.TopCardIndex];
            }//if
            Debug.WriteLine(String.Format("Card was drawn. ID: {0}, Description: {1}", topCard.CardID, topCard.Description));
            return topCard;
        }

        override public string ToString(){
            String output = "";
            foreach (Card c in Cards)
            {
                output = output + c.ToString() + System.Environment.NewLine;
            }//foreach
            return output;
        }//ToString()

    }//Deck
}