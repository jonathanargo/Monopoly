using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Tiles
{
    //DrawCard represents both the Chance spaces and the CommunnityChest spaces. The only difference is which deck they draw from.
    class DrawCard: Tiles.BoardSpace
    {
        private DeckType mDeck;

        public DrawCard(int position, String name, DeckType deck)
            : base(position, name)
        {
            this.Position = position;
            this.Name = name;
            this.DeckType = deck;
        }//DrawCard

        public DeckType DeckType{ get { return mDeck; } private set { mDeck = value; } }

    }//class DrawCard
}
