using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Tiles
{
    class LuxuryTax: Tiles.BoardSpace
    {
        public LuxuryTax(int position, string name)
            : base(position, name, "Luxury Tax")
        {
            this.Position = position;
            this.Name = name;
        }//LuxuryTax()

    }//class LuxuryTax
}
