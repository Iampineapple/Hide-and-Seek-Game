using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookapp27_p332
{
    class Room : Location
    {
        public Room(string name, string decoration) : base(name, decoration)
        {

        }
    }

    class RoomWithHidingPlace : Room, IHasHidingPlace
    {
        public string HidingPlace { get; }

        public RoomWithHidingPlace(string name, string decoration, string hidingPlace) : base(name, decoration)
        {
            HidingPlace = hidingPlace;
        }

    }

    class RoomWithDoor : RoomWithHidingPlace, IHasExteriorDoor
    {
        public RoomWithDoor(string name, string decoration, string hidingPlace, string doorDescription) : base(name, decoration, hidingPlace)
        {
            DoorDescription = doorDescription;
        }

        public string DoorDescription { get; }
        

        public Location DoorLocation { get; set; }
    }
}
