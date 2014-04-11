using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Tiles
{
    //Only used to distinguish the space in the GameLogic class.
    class Go: Tiles.BoardSpace
    {
        public Go(int position, String name)
            : base(position, name)
        {
            //nothing here
        }
    }
}
