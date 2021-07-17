using Komodo_Badges_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Badges_Console
{
    public class Komodo_Badges_ProgramUI
    {
        private bool _isRunning = true;

        private readonly Komodo_Badge_Repo _repo = new Komodo_Badge_Repo();

        public void Start()
        {
            //Seeds data into our app.
            SeedBadgesDictionary();

            //Run Menu method
            RunBadgeMenu();
        }

        private void RunBadgeMenu()
        {
            while (_isRunning)
            {
                string userInput = GetBadgeNumber();
                OpenBadgeNumber(userInput);
            }
        }

        private string GetBadgeNumber()
        {
            Console.Clear();
            Console.WriteLine("This is the badge management system. Please choose from the selection bellow:\n" +
                            "1. Create a new badge.\n" +
                            "2. Update an existing badge.\n" +
                            "3. Delete badge access.\n" +
                            "4. Show a every badge with a cooresponding door.\n" +
                            "5. Exit \n");

            string userInput = Console.ReadLine();
            return userInput;
        }
        private void OpenBadgeNumber(string userInput)
        {
            Console.Clear();

            switch (userInput)
            {
                case "1":
                    //Add a badge to the dictionary (similar to the update)
                    CreateANewBadge();
                    break;
                case "2":
                    //Update a badge in the dictionary
                    UpdateABadge();
                    break;
                case "3":
                    //Delete a badge
                    DeleteAllDoorsOnABadge();
                    break;
                case "4":
                    //Show the entire dictionary
                    ShowListOfDoorsAndBadges();
                    break;
                case "5":
                    //Exit
                    _isRunning = false;
                    return;
                default:
                    Console.WriteLine("I'm sorry that is not a valid selection. Please press any button to return to the main menu.");
                    GetBadgeNumber();
                    return;
            }
        }

        private void UpdateABadge()
        {
            Console.WriteLine("Write the key to be updated: ");
            string doorName = Console.ReadLine();

            Console.WriteLine("Enter the new doors: ");
            BadgePersonnelNames badgeNames = BadgeNewPersonnelNames();

            _repo.UpdateBadgeByDoorNumber(doorName, badgeNames);

            PressAnyKeyToReturnToMainMenu();
        }
        private void CreateANewBadge()
        {
            Console.Clear();
            Console.WriteLine("Enter the doors to be added: ");
            string doorName = Console.ReadLine();

            BadgePersonnelNames badgeNames = BadgeNewPersonnelNames();

            Komodo_Badge content = new Komodo_Badge(doorName, badgeNames);

            _repo.AddContentToMenu(content);

            PressAnyKeyToReturnToMainMenu();
        }

        private BadgePersonnelNames BadgeNewPersonnelNames()
        {
            Console.WriteLine("Select a name to add:\n" +
                            "1. Robert\n" +
                            "2. Chelsea\n" +
                            "3. Ashley\n" +
                            "4. Jamie\n");

            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        return BadgePersonnelNames.Robert;
                    case "2":
                        return BadgePersonnelNames.Chelsea;
                    case "3":
                        return BadgePersonnelNames.Ashley;
                    case "4":
                        return BadgePersonnelNames.Jamie;
                }
            }
        }

        private void DeleteAllDoorsOnABadge()
        {
            Console.WriteLine("Enter door key to be deleted: ");

            _repo.DeleteContentByBadgeNumber(Console.ReadLine());

            PressAnyKeyToReturnToMainMenu();
        }
        private void ShowListOfDoorsAndBadges()
        {
            List<Komodo_Badge> listOfBadges = _repo.GetAllBadges();

            foreach (Komodo_Badge content in listOfBadges)
            {
                DisplayContent(content);
            }

            PressAnyKeyToReturnToMainMenu();
        }

        private void DisplayContent(Komodo_Badge content)
        {
            Console.WriteLine($"Door Name: {content.DoorName}\n" +
                                $"Description: {content.BadgeNames}\n");
        }

        private void PressAnyKeyToReturnToMainMenu()
        {
            Console.WriteLine("Press any key to return to Main Menu.");
            Console.ReadKey();
            RunBadgeMenu();
        }

        //Seed content dictionary
        private void SeedBadgesDictionary()
        {
            var badges = new Dictionary<int, Komodo_Badge>
            {
                {1, new Komodo_Badge("North", BadgePersonnelNames.Jose)},
                {2, new Komodo_Badge("South, East", BadgePersonnelNames.Jane)},
                {3, new Komodo_Badge("West, North, South", BadgePersonnelNames.Peter)},
                {4, new Komodo_Badge("South", BadgePersonnelNames.Mary)},
            };

            foreach (var kvp in badges)
                Console.WriteLine("Key: {0}, Value:{1}", kvp.Key, kvp.Value);
        }
    }
}

// Create a Badge class with the following properties:
// A BadgeID(int)
// A List of door names (strings).
// A name for the badge.


// Create a badge repository:
// Create a dictionary of badges.
// The key for the dictionary will be the BadgeID.
// The value for the dictionary will be the List of Door Names.

// The Program will allow a security staff member to do the following:
// create a new badge
// update doors on an existing badge.
// delete all doors from an existing badge.
// show a list with all badge numbers and door access