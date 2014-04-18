using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Tiles
{
    public class IncomeTax: Tiles.BoardSpace
    {
        public IncomeTax(int position, string name): base(position, name, "Income Tax"){
            this.Position = position;
            this.Name = name;
        }//IncomeTax()

    }//class Incometax
}
