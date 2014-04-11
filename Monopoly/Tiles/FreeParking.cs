using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Tiles
{
    public class FreeParking: Tiles.BoardSpace
    {
        public FreeParking(int position, String name)
            : base(position, name)
        {
            this.Position = position;
            this.Name = name;
        }//FreeParking()

    }//class FreeParking
}
