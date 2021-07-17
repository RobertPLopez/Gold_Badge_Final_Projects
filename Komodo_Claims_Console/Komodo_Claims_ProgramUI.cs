using Komodo_Claims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claims_Console
{
    public class Komodo_Claims_ProgramUI

    {
        private bool _isRunning = true;

        private readonly Claims_Content_Repo _repo = new Claims_Content_Repo();

        public void Start()
        {
            //Seeds data into our app.
            SeedContentList();

            //Run Menu method
            RunMenu();
        }

        public void RunMenu()
        {
            while (_isRunning)
            {
                string userInput = GetClaimSelection();
                OpenClaim(userInput);
            }
        }

        private string GetClaimSelection()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Komodo Cafe! We look forward to serving you. Please Choose from the menu below.\n" +
                            "Select Menu Item:\n" +
                            "1. See all the claims.\n" +
                            "2. Take care of the next claim.\n" +
                            "3. Enter a new claim\n" +
                            "4. Exit\n");

            string userInput = Console.ReadLine();
            return userInput;
        }

        private void OpenClaim(string userInput)
        {
            Console.Clear();

            switch (userInput)
            {
                case "1":
                    //Show all the claims in the seed content
                    DisplayAllClaims();
                    break;
                case "2":
                    //Display the first claim in the queue
                    GetClaimByNumber();
                    break;
                case "3":
                    //Add a new claim
                    AddANewClaim();
                    break;
                case "4":
                    //Exit
                    _isRunning = false;
                    return;
                default:
                    Console.WriteLine("I'm sorry that is not a valid selection. Please press any button to return to the main menu.");
                    GetClaimSelection();
                    return;
            }
        }

        private void DisplayAllClaims()
        {
            List<Claims_Content> listOfContent = _repo.GetAllClaimsContent();

            foreach (Claims_Content content in listOfContent)
            {
                DisplayClaims(content);
            }

            PressAnyKeyToReturnToMainMenu();
        }

        private void GetClaimByNumber()
        {
            Console.Write("Enter a number: ");
            string drink = Console.ReadLine();

            Claims_Content content = _repo.GetClaimByQueueNumber(int.MaxValue);

            if (content != null)
            {
                DisplayClaims(content);

                PressAnyKeyToReturnToMainMenu();
            }
            else
            {
                Console.WriteLine("Invalid Selection. Press any key to return to main menu.");
                GetClaimSelection();
            }
        }
        private void DisplayClaims(Claims_Content content)
        {
            Console.WriteLine($"Claim ID: {content.ClaimID}\n" +
                                $"Type of claim: {content.TypeOfClaim}\n" +
                                $"Description: {content.Description}\n" +
                                $"Claim ammount: {content.ClaimAmmount}\n"+
                                $"Date of incident: {content.DateOfIncident}\n"+
                                $"Date of claim: {content.DateOfClaim}\n"+
                                $"Is the claim valid: {content.YesNo}\n");
        }

        private void AddANewClaim()
        {
            Console.Clear();
            Console.WriteLine("Enter a claim id: ");
            int claimID = int.Parse(Console.ReadLine());

            Claims_Content.Claimtype claimType = ATypeOfClaim();

            Console.WriteLine("Enter a description of the claim: ");
            string description = Console.ReadLine();

            Console.WriteLine("Enter the claim ammount: ");
            int claimAmmount = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the claim incident date (FORMAT MM/DD/YYYY): ");
            DateTime dateOfIncident = DateTime.Parse(Console.ReadLine());

            // Need to figure out how to enter in date/time

            Console.WriteLine("Enter the date of the claim (FORMAT MM/DD/YYYY): ");
            DateTime dateOfClaim = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Is this claim valid: ");
            // Need to ask how to put a bool here

            Claims_Content content = new Claims_Content(claimID, claimType, description, claimAmmount, dateOfIncident, dateOfClaim);

            _repo.AddANewClaim(content);

            PressAnyKeyToReturnToMainMenu();
        }

        private Claims_Content.Claimtype ATypeOfClaim()
        {
            Console.WriteLine("Select a claim type: \n" +
                                "1. House\n" +
                                "2. Car\n"+
                                "3. Boat\n"+
                                "4. Motorcycle\n"+
                                "5. Life\n");

            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        return Claims_Content.Claimtype.House;
                    case "2":
                        return Claims_Content.Claimtype.Car;
                    case "3":
                        return Claims_Content.Claimtype.Boat;
                    case "4":
                        return Claims_Content.Claimtype.Motorcycle;
                    case "5":
                        return Claims_Content.Claimtype.Life;
                }
            }
        }

        private void RunYesNo()
        {
            //I need help with this particualr bool. And getting it linked to the YesNo function inthe Claim_Content class
            Console.Clear();
            Console.WriteLine("Is the claim valid: ");
            bool YesNo = true;
            while (YesNo)
            {
                string command = Console.ReadLine().ToLower();
                Console.Clear();
                if (command.StartsWith("Y"))
                {
                    Console.WriteLine("This claim is still open");
                }
                else if (command.StartsWith("y"))
                {
                    Console.WriteLine("This claim is still open");
                }
                else if (command.StartsWith("N"))
                {
                    Console.WriteLine("This claim is now closed");
                }
                else if (command.StartsWith("n"))
                {
                    Console.WriteLine("This claim is now closed");
                }
                else
                {
                    Console.WriteLine("That is not a valid option. Please press Y or N.");
                    PressAnyKeyToReturnToMainMenu();
                }
            }
        }
        public void PressAnyKeyToReturnToMainMenu()
        {
            Console.WriteLine("Press any key to return to Main Menu.");
            Console.ReadKey();
            RunMenu();
        }

        //Seed Content
        private void SeedContentList()
        {
            // Claims_Content(int claimID, Claimtype claimType, string description, int claimAmmount, DateTime dateOfIncident, DateTime dateOfClaim, bool yesNo)
            Claims_Content claim1 = new Claims_Content(1, 0, "One occupent, who had a tree fall on his house", 40000, DateTime.Now, DateTime.Parse("11/15/21"));

        }
    }
}

