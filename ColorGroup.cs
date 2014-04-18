using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Monopoly
{
    public class ColorGroup
    {
        private int mID;
        private PropertyColor mGroupColor;
        private ArrayList mAllProps;

        //CONSTRUCTORS//

        //used when iteratively defining colorgroups
        public ColorGroup(int id, PropertyColor groupColor)
        {
            this.ID = id;
            this.GroupColor = groupColor;
            GroupProperties = new ArrayList();
            //Colors will need to be iteratively added with the AddProperty method
            
        }//ColorGroup
        
        //used when pre-defining colorgroups
        public ColorGroup(PropertyColor groupColor, Tiles.Property prop1, Tiles.Property prop2)
        {
            this.GroupColor = groupColor;
            Tiles.Property[] props = new Tiles.Property[2] { prop1, prop2 };
            AddPropertiesByArray(props);
                        
        }//ColorGroup

        //used when pre-defining colorgroups
        public ColorGroup(PropertyColor propertyColor, Tiles.Property prop1, Tiles.Property prop2, Tiles.Property prop3)
        {
            this.GroupColor = propertyColor;
            Tiles.Property[] props = new Tiles.Property[3] { prop1, prop2, prop3 };
            AddPropertiesByArray(props);
        }//ColorGroup



        //PROPERTIES//

        public int ID { get { return mID; } private set { mID = value; } }
        public ArrayList GroupProperties { get { return mAllProps; } private set { mAllProps = value; } }
        public PropertyColor GroupColor { get { return mGroupColor; } private set { mGroupColor = value; } }



        //METHODS//

        public void AddProperty(Tiles.Property prop)
        {
            mAllProps.Add(prop);
        }//AddProperty

        public void AddPropertiesByArray(Tiles.Property[] prop)
        {
            foreach (Tiles.Property p in prop)
            {
                AddProperty(p);
            }//foreach
        }//AddPropertiesByArray

        public bool isOwned(int playerid)
        {
            bool result = true;
            foreach (Tiles.Property p in GroupProperties)
            {
                if (p.OwnerID == playerid)
                {
                    result = false;
                }//if
            }
            return result;
        }//isOwned

        

    }//class ColorGroup
}
