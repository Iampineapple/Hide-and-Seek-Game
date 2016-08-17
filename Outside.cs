using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookapp27_p332
{
    class Outside : Location
    {
        public Outside(string name, string decoration) : base(name, decoration)
        {
       
        }
    }

    class OutsideWithHidingPlace : Outside, IHasHidingPlace
    {
        public string HidingPlace { get; }
        public OutsideWithHidingPlace(string name, string decoration, string hidingPlace) : base(name, decoration)
        {
            HidingPlace = hidingPlace;
        }

    }

    class OutsideWithDoor : OutsideWithHidingPlace, IHasExteriorDoor
    {
        public OutsideWithDoor(string name, string decoration, string hidingPlace, String DoorDescription) : base(name, decoration, hidingPlace)
        {
            this.DoorDescription = DoorDescription;
        }

        public string DoorDescription { get; }

        public Location DoorLocation { get; set; }
    }
}
