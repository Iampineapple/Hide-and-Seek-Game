using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookapp27_p332
{
    class Opponent
    {
        public string name;
       
        Location myLocation { get; set; }

        public bool IsHidden { get { return myLocation is IHasHidingPlace; } }

        Random randMover;

        public Opponent(string name, Location startingLocation, Random randMover)
        {
            this.name = name;
            myLocation = startingLocation;
            this.randMover = randMover;
        }

        public void Move()
        {
            if (myLocation is IHasExteriorDoor)
            {
                if (randMover.Next(0, 2) == 1)
                {
                    IHasExteriorDoor curLoc = myLocation as IHasExteriorDoor;
                    myLocation = curLoc.DoorLocation;
                }
                else
                    myLocation = myLocation.Exits[randMover.Next(0, myLocation.Exits.Length)];

            }
            else
                myLocation = myLocation.Exits[randMover.Next(0, myLocation.Exits.Length)];
        }//Move

        public bool Check(Location locToCheck)
        {
            return locToCheck == myLocation;            
        }

    }
}
