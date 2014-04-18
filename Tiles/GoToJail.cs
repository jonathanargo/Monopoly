using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Tiles
{
    //Used to determine if a player is sent to jail in GameLogic
    class GoToJail: Tiles.BoardSpace
    {
        public GoToJail(int position, String name)
            : base(position, name, "Go To Jail")
        {
            //nothing here
        }
    }
}
