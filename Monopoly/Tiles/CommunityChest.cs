using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Tiles
{
    class CommunityChest: Tiles.BoardSpace
    {
        public CommunityChest(int position, string name)
            : base(position, name)
        {
            this.Position = position;
            this.Name = name;
        }//CommunityChest

    }//BoardSpace
}
