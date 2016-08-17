using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Bookapp27_p332
{
    public partial class Form1 : Form
    {

        List<Opponent> kids;
        string[] kidsPotentialNames = { "Bobby", "Joan", "Alex", "Jeff", "Pedro", "Alexandro", "Samantha", "Eve", "Maya" , "Sophie", "Adrian", "Adam", "Eric", "Flora"};
        int numberOfKids;
        bool anyKidsInCurrentLocation;
        bool anyKidsUnhiddenInCurrentLocation;
        bool[] kidsFound;
        List<Opponent> kidsInCurrentLocation;

        Random rand;

        int moves;

        Location currentLocation;

        OutsideWithDoor backYard;
        OutsideWithHidingPlace garden;
        OutsideWithDoor frontYard;

        RoomWithDoor kitchen;
        Room diningRoom;
        RoomWithDoor livingRoom;

        Room stairway;
        RoomWithHidingPlace hallway;
        RoomWithHidingPlace masterBedroom;
        RoomWithHidingPlace secondBedroom;
        RoomWithHidingPlace bathroom;

        string backDoorDescription = "a screen door";
        string frontDoorDescription = "an oak door with a brass knob";

        StringBuilder displayString;

        public Form1()
        {
            InitializeComponent();
            CreateObjects();
            descriptionTextBox.Text = "Welcome to the game! Pick the number of kids you want to find from the dropdown, then press the Hide button to count to ten as the children hide!";
            
        }//Form1

 

        private void CreateObjects()
        {

            //Create all the rooms
            backYard = new OutsideWithDoor("Back Yard", "a porch with a cupboard on it", "the cupboard on the back porch", backDoorDescription);
            garden = new OutsideWithHidingPlace("Garden", "a luxurious garden next to a small shed", "the garden shed");
            frontYard = new OutsideWithDoor("Front Yard", "a hedge and flanking bushes", "in a number of bushes", frontDoorDescription);

            kitchen = new RoomWithDoor("Kitchen", "a beautiful collection of pots and pans", "in the cupboard", backDoorDescription);
            diningRoom = new RoomWithHidingPlace("Dining Room", "a table set with a scrumptious feast", "underneath the table");
            livingRoom = new RoomWithDoor("Living Room", "a lazyboy and couch pointed at a huge television", "behind the couch", frontDoorDescription);

            stairway = new Room("Stairway", "a hanging piece of artwork");
            hallway = new RoomWithHidingPlace("Upstairs Hallway", "a painting of a dog and a cupboard", "in the cupboard");
            masterBedroom = new RoomWithHidingPlace("Master Bedroom", "a luxurious king-sized bed", "underneath the bed");
            secondBedroom = new RoomWithHidingPlace("Second Bedroom", "a twin-sized bed", "underneath the bed");
            bathroom = new RoomWithHidingPlace("Bathroom", "a clawed bathtub/shower", "in the shower");

            //Populate the room exits
            backYard.Exits = new Location[]{ garden, frontYard };
            garden.Exits = new Location[] { backYard, frontYard };
            frontYard.Exits = new Location[] { garden, backYard };

            kitchen.Exits = new Location[] { diningRoom };
            diningRoom.Exits = new Location[] { kitchen, livingRoom };
            livingRoom.Exits = new Location[] { diningRoom, stairway };

            stairway.Exits = new Location[] { livingRoom, hallway };
            hallway.Exits = new Location[] { stairway, masterBedroom, secondBedroom, bathroom };
            masterBedroom.Exits = new Location[] { hallway };
            secondBedroom.Exits = new Location[] { hallway };
            bathroom.Exits = new Location[] { hallway };

            //And tell them where the outdoor doors go
            backYard.DoorLocation = kitchen;
            kitchen.DoorLocation = backYard;

            frontYard.DoorLocation = livingRoom;
            livingRoom.DoorLocation = frontYard;

            kidsInCurrentLocation = new List<Opponent> { };

            rand = new Random();

        }//CreateObjects

        private void GetNumberOfKids()
        {

            numberKidsComboBox.Visible = false;
            hideButton.Visible = false;

            switch (numberKidsComboBox.SelectedItem.ToString())
            {
                case "One":
                    numberOfKids = 1;
                    break;
                case "Two":
                    numberOfKids = 2;
                    break;
                case "Three":
                    numberOfKids = 3;
                    break;
                case "Four":
                    numberOfKids = 4;
                    break;
                case "Five":
                    numberOfKids = 5;
                    break;
                default:
                    numberOfKids = 1;
                    break;
            }

            kids = new List<Opponent> { };


            kidsFound = new bool[numberOfKids];
            for (int i = 0; i < kidsFound.Length; i++)
            {
                kidsFound[i] = false;
            }

            //Shuffle the names
            int j;
            string temp;
            for (int i = kidsPotentialNames.Length - 1; i >= 0; i--)
            {
                j = rand.Next(0, i);
                temp = kidsPotentialNames[j];
                kidsPotentialNames[j] = kidsPotentialNames[i];
                kidsPotentialNames[i] = temp;
            }

            //Deal out one name per kid
            for (int i = 0; i < numberOfKids; i++)
            {
                kids.Add(new Opponent(kidsPotentialNames[i], livingRoom, rand));
            }

            //Display who we'll be looking for
            displayString = new StringBuilder("You will be looking for ");
            displayString.Append(NameListCreator(kids));
            displayString.Append(".  ");
            descriptionTextBox.Text = displayString.ToString();
            Application.DoEvents();
            Thread.Sleep(2000);
            StartGame();
        }//GetNumberOfKids

        private void StartGame()
        {

            //Count to 10, then shout that you're coming
            for (int i = 1; i <= 10; i++) {
                foreach(var kid in kids)
                {
                    kid.Move();
                }
                descriptionTextBox.Text = i + "...";
                Application.DoEvents();
                Thread.Sleep(250);
            }
            
            descriptionTextBox.Text = "Ready or not, here I come!";
            Application.DoEvents();
            Thread.Sleep(600);

            goHereButton.Visible = true;
            exitsComboBox.Visible = true;
            goThroughTheDoorButton.Visible = true;
            checkHiddenButton.Visible = true;

            //Initialize moves at -1 so the first MoveToLivingRoom sets it to zero
            moves = -1;
            MoveToNewRoom(livingRoom);
        }//StartGame

        private void MoveToNewRoom(Location toMoveTo)
        {
            //Move to the new location
            currentLocation = toMoveTo;
            moves++;

            //Reset flag vars, then check if there's any kids in the current area
            anyKidsInCurrentLocation = false;
            anyKidsUnhiddenInCurrentLocation = !(currentLocation is IHasHidingPlace) && anyKidsInCurrentLocation;
            kidsInCurrentLocation.Clear();

            foreach (var kid in kids)
            {
                if (kid.Check(currentLocation))
                {
                    anyKidsInCurrentLocation = true;
                    kidsInCurrentLocation.Add(kid);
                }
            }

            //Change the description and combo box
            if (anyKidsUnhiddenInCurrentLocation)
            {
                displayString = new StringBuilder(currentLocation.Description + "You have moved " + moves + " moves.  You see ");
                displayString.Append(NameListCreator(kidsInCurrentLocation));
                displayString.Append("running around looking for a hiding place.  ");
                descriptionTextBox.Text = displayString.ToString();
            }
            else
                descriptionTextBox.Text = currentLocation.Description + "You have moved " + moves + " moves.  ";

            exitsComboBox.Items.Clear();
            foreach (var exit in currentLocation.Exits)
            {
                exitsComboBox.Items.Add(exit);
            }

            //If there's an outside door, let them go through it
            if (currentLocation is IHasExteriorDoor)
                goThroughTheDoorButton.Visible = true;
            else
                goThroughTheDoorButton.Visible = false;

            //If there's a hiding place, let them check it
            if (currentLocation is IHasHidingPlace)
                checkHiddenButton.Visible = true;
            else
            {
                if (anyKidsUnhiddenInCurrentLocation)
                {
                    checkHiddenButton.Visible = true;

                    //Build the string to display on the button, grammatically correct, with all the kids' names
                    displayString = new StringBuilder("Tell ");
                    displayString.Append(NameListCreator(kidsInCurrentLocation));
                    displayString.Append("you found them.");

                    checkHiddenButton.Text = displayString.ToString();
                }
                else
                    checkHiddenButton.Visible = false;
            }

        }//MoveToNewRoom

        private string NameListCreator(List<Opponent> kidsToGetNames)
        {

            
            StringBuilder nameString = new StringBuilder("");

            if (kidsToGetNames.Count > 2)
            {
                for (int i = 0; i < kidsToGetNames.Count; i++)
                {
                    //Add kid's name
                    nameString.Append(kidsToGetNames[i].name);

                    //Add grammar, commas and ands
                    if (i < kidsToGetNames.Count - 2)
                        nameString.Append(", ");
                    else if (i == kidsToGetNames.Count - 2)
                        nameString.Append(", and ");
                }//For adding kids names
            }
            else if (kidsToGetNames.Count == 2)
            {
                for (int i = 0; i < kidsToGetNames.Count; i++)
                {
                    //Add kid's name
                    nameString.Append(kidsToGetNames[i].name);

                    //Add grammar, commas and ands
                    if (kidsToGetNames.Count > 1 && i == kidsToGetNames.Count - 2)
                        nameString.Append(" and ");
                }//For adding kids names
            }
            else
                nameString.Append(kidsToGetNames[0].name);

            return nameString.ToString();
        }

        private void EndGame()
        {
            goHereButton.Visible = false;
            exitsComboBox.Visible = false;
            goThroughTheDoorButton.Visible = false;
            checkHiddenButton.Visible = false;
            hideButton.Visible = true;
            numberKidsComboBox.Visible = true;
            if (currentLocation is IHasHidingPlace)
            {
                IHasHidingPlace currLoc = currentLocation as IHasHidingPlace;
                displayString = new StringBuilder("You look " + currLoc.HidingPlace + " and find ");
                displayString.Append(NameListCreator(kidsInCurrentLocation));
                displayString.Append(".  Congradulations! You found all the kids in " + moves + " moves !  "
                    + "Select a number of kids and press Hide to play again.  ");
                descriptionTextBox.Text = displayString.ToString();
            }
            else
            {
                displayString = new StringBuilder("You tell ");
                displayString.Append(NameListCreator(kidsInCurrentLocation));
                displayString.Append("that you see them standing out in the open.  Congradulations! You found all the kids in " + moves + " moves !  " 
                    + "Select a number of kids and press Hide to play again.  ");
                descriptionTextBox.Text = displayString.ToString();
            }
        }//EndGame

        private void goHereButton_Click(object sender, EventArgs e)
        {

            if (exitsComboBox.SelectedItem is Location)
                MoveToNewRoom((Location)exitsComboBox.SelectedItem);
            else
                descriptionTextBox.Text = "Please select a room to go to before pressing Go Here";
            

        }

        private void goThroughTheDoorButton_Click(object sender, EventArgs e)
        {
            IHasExteriorDoor theLocation = currentLocation as IHasExteriorDoor;
            MoveToNewRoom(theLocation.DoorLocation);
        }

        private void checkHiddenButton_Click(object sender, EventArgs e)
        {
            //If there's kids in the current location, mark the ones there as found, then check if we've found all the kids
            if (anyKidsInCurrentLocation)
            {
                //Mark the kids as found
                for (int i = 0; i < kids.Count; i++)
                {
                    if (kidsInCurrentLocation.Contains(kids[i]))
                    {
                        kidsFound[i] = true;
                    }
                }

                //Display you found the kids
                if(currentLocation is IHasHidingPlace)
                {
                    IHasHidingPlace currLoc = currentLocation as IHasHidingPlace;
                    StringBuilder displayString = new StringBuilder("You look " + currLoc.HidingPlace + " and find ");
                    displayString.Append(NameListCreator(kidsInCurrentLocation));
                    displayString.Append(".  ");
                    descriptionTextBox.Text = displayString.ToString();
                }
                else
                {
                    StringBuilder displayString = new StringBuilder("You tell ");
                    displayString.Append(NameListCreator(kidsInCurrentLocation));
                    displayString.Append("that you see them standing out in the open.  ");
                    descriptionTextBox.Text = displayString.ToString();
                }

                //Check if we end the game
                bool endGame = true;
                foreach(var flag in kidsFound)
                {
                    if(flag == false)
                    {
                        endGame = false;
                        break;
                    }
                }

                if (endGame)
                    EndGame();

            }
            else
            {
                IHasHidingPlace currLoc = currentLocation as IHasHidingPlace;
                descriptionTextBox.Text = "You check " + currLoc.HidingPlace + ", but you do not find anyone.  ";
            }
        }//CheckHiddenButton_Click

        private void hideButton_Click(object sender, EventArgs e)
        {
            GetNumberOfKids();
        }
    }
}
