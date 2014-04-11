using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Tiles
{
    //BoardSpace is used as a superclass for the various tile types, but is also used for Free Parking
    public class BoardSpace
    {
        private int mPosition;
        private String mName;

        public BoardSpace(int position, String name){
            this.Name = name;
            this.Position = position;
        }//Boardspace

        public int Position {
            get { return mPosition; }
            protected set
            {
                if ((value >= 1) && (value <= 40))
                {
                    mPosition = value;
                }
                else
                {
                    mPosition = 1;
                    System.Windows.Forms.MessageBox.Show("Property position can not be greater than 40 or less than 1");
                }//if else
            }//set
        }//Position


        //PROPERTIES

        public String Name { get { return mName; } protected set { mName = value; } }


        //METHODS

        public override String ToString()
        {
            //return ("Name: " + this.Name + ", Position: " + this.Position);
            return (this.Position + " Name: " + this.Name);
        }//ToString

    }//class Boardspace
}
