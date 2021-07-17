using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claims_Repository
{
    //POCO Plain Old C# Object
    public class Claims_Content
    {
        //Empty Constructor
        public Claims_Content() { }
        //Full Constructor 
        public Claims_Content(int claimID, Claimtype claimType, string description, int claimAmmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            TypeOfClaim = claimType;
            Description = description;
            ClaimAmmount = claimAmmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }

        public int ClaimID { get; set; }
        public Claimtype TypeOfClaim { get; set; }
        public string Description { get; set; }
        public int ClaimAmmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        //I need help here
        public DateTime DateOfClaim { get; set; }
        //I Need help here

        public bool YesNo 
        { 
            get
            {
                if((DateOfClaim - DateOfIncident).TotalDays <= 30)
                {
                    return true;
                }
                return false;
            }
                
        }
        //I need help here

        public enum Claimtype
        {
            House, 
            Car, 
            Boat, 
            Motorcycle, 
            Life,
        }
    }
}

// ClaimID int 
// ClaimType enum
// Description string
// ClaimAmount int
// DateOfIncident int or date (need research on how dates are done) 
// DateOfClaim int or date (need research on dates are done)
// IsValid True = expired date past 6 months, yesNo

