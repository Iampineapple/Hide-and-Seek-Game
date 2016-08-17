using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookapp27_p332
{
    public abstract class Location
    {
        public Location(string name, string decoration)
        {
            this.Name = name;
            this.Decoration = decoration;
        }

        public string Name { get; }
        
        public Location[] Exits { get; set; }
        string Decoration { get; }
        public virtual string Description
        {
            get
            {
                StringBuilder description = new StringBuilder("You're standing in the " + Name 
                    +".  You see exits to the following places : ");
                for (int i = 0; i < Exits.Length; i++)
                {
                    description.Append(" " + Exits[i].Name);
                    if (i != Exits.Length - 1)
                        description.Append(",");
                
                }//for
                description.Append(".  You also see " + Decoration + ".  ");
                return description.ToString();
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
