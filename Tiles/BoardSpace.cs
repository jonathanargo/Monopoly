using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Tiles
{
    public abstract class BoardSpace
    {
        private int mPosition;

        public BoardSpace(int position, String name, String spaceType){
            this.Name = name;
            this.Position = position;
            this.SpaceType = spaceType;
        }//Boardspace

        public String Name { get; protected set; }
        public String SpaceType { get; protected set; }
        public int Position {
            get { return mPosition; }
            set
            {
                if ((value >= 0) && (value <= 40))
                {
                    mPosition = value;
                }
                else
                {
                    mPosition = 1;
                    System.Windows.Forms.MessageBox.Show("Property position can not be greater than 40 or less than 0");
                }//if else
            }//set
        }//Position
        
        //METHODS

        public override String ToString()
        {
            //return ("Name: " + this.Name + ", Position: " + this.Position);
            return (this.Position + " Name: " + this.Name);
        }//ToString

    }//class Boardspace
}
