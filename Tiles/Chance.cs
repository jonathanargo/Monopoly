using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Tiles
{
    class Chance: Tiles.BoardSpace
    //just used to distinguish space in Game Logic
    {
        public Chance(int position, String name)
            : base(position, name, "Chance")
        {
            this.Position = position;
            this.Name = name;
        }//Chance()
    }//class Chance
}
