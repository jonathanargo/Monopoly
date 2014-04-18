using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Tiles
{
    public class Railroad: Tiles.BuyableSpace
    {
        public Railroad(int position, String name): base(position, name, 200, 100, "Railroad")
        {
            BaseFare = 25;
        }//Railroad()

        public int BaseFare { get; private set; }

        public override string ToString()
        {
            return base.ToString();
        }//ToString()

    }//Railroad
}
