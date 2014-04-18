using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Tiles
{
    //Board only contains one jail, so the jail just contain the inmates, and is used for Player.IsJailed()
    public class Jail: Tiles.BoardSpace
    {
        private List<int> mInmateIDs;

        public Jail(int position, String name)
            : base(position, name, "Jail")
        {
            this.Position = position;
            this.Name = name;
            this.Inmates = new List<int>();
        }//Jail()

        //PROPERTIES
        public List<int> Inmates { get { return mInmateIDs; } set { mInmateIDs = value; } }

        //METHODS
        public void Release(int playerID)
        {
            Inmates.Remove(playerID);
            Console.WriteLine("PlayerID " + playerID + " was removed from jail.");
        }//Release()

        public void Incarcerate(int playerID)
        {
            bool notJailed = true;
            foreach (int p in Inmates)
            {
                if (p == playerID)
                {
                    notJailed = false;
                }//if
            }//foreach

            if (notJailed)
            {
                Inmates.Add(playerID);
                Console.WriteLine("Player " + playerID + " has been jailed.");
            }else
            {
                UI ui = new UI();
                ui.Error(String.Format("Error: Player {0} is already in jail.", playerID + 1));
            }//ifelse
        }//Incarcerate()

    }//class Jail
}
