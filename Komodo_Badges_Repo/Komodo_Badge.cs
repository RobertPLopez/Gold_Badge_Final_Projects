using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Badges_Repo
{
	public class Komodo_Badge
	{
		//POCO Plain Old C# Object 
		//Empty Constructor 
		public Komodo_Badge() { }

		// Full Constructor 
		public Komodo_Badge( string doorName, BadgePersonnelNames badgeNames) 
		{
			DoorName = doorName;
			BadgeNames = badgeNames;
		}
		public string DoorName { get; set; }
		public BadgePersonnelNames BadgeNames { get; set; }
	}

	public enum BadgePersonnelNames
    {
		Jose, 
		Peter, 
		Mary, 
		Jane,
		Robert,
		Chelsea,
		Ashley,
		Jamie,
	}
	// badges[1] = "South, East"; // update value of 2 badge
	//  badges[3] = "North"; // update value of 3 badge
	//cities["France"] = "Paris"; //throws run-time exception: KeyNotFoundException

	// Add directly to the dictionary in the code not console

	//  if (badges.ContainsKey(5))
	//  {
	// badges[5] = "Basement, Roof";
	// }
}

// Create a Badge class with the following properties:
// A BadgeID(int)
// A List of door names (strings).
// A name for the badge.
