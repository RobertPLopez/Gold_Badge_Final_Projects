using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Badges_Repo
{
    public class Komodo_Badge_Repo : I_Komodo_Badge
    {
        private readonly List<Komodo_Badge> _contentDirectory = new List<Komodo_Badge>();
        //Build out our CRUD methods

        //READ
        //Get all our menu objects from our directory
        public List<Komodo_Badge> GetAllBadges()
        {
            return _contentDirectory;
        }

        //UPDATE
        public void UpdateBadgeByDoorNumber(string doorName, BadgePersonnelNames badgeNames)
        {
            Komodo_Badge content = GetContentByDoor(doorName);

            content.BadgeNames = badgeNames;
            content.DoorName = doorName;
        }

        //CREATE
        public void AddContentToMenu(Komodo_Badge content)
        {
            _contentDirectory.Add(content);
        }

        //DELETE
        public bool DeleteAllBadges(Komodo_Badge content)
        {
            return _contentDirectory.Remove(content);
        }
        public bool DeleteContentByBadgeNumber(string doorName)
        {
            Komodo_Badge content = GetContentByDoor(doorName);

            return DeleteAllBadges(content);
        }

        //Get badge object by Key
        public Komodo_Badge GetContentByDoor(string doorName)
        {
            foreach (Komodo_Badge item in _contentDirectory)
            {
                if (item.DoorName == doorName)
                {
                    return item;
                }
            }

            return null;
        }

    }
}


//public void addOrUpdateABadge(Dictionary<int, string> badges, int badgeNumber, string doorCanOpen)
//{
  //  string val;
   // if (badges.TryGetValue(badgeNumber, out val))
    //{
        // yay, value exists!
     //   badges[badgeNumber] = val + doorCanOpen;
    //}
    //else
    //{
        // darn, lets add the value
      //  badges.Add(badgeNumber, doorCanOpen);
    //}
//}