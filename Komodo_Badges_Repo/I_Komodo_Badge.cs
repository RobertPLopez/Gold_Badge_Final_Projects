using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Badges_Repo
{
    public interface I_Komodo_Badge
    {
        void AddContentToMenu(Komodo_Badge content);
        List<Komodo_Badge> GetAllBadges();
        bool DeleteContentByBadgeNumber(string doorName);
        bool DeleteAllBadges(Komodo_Badge content);
        Komodo_Badge GetContentByDoor(string doorName);
        void UpdateBadgeByDoorNumber(string doorName, BadgePersonnelNames badgeNames);

    }
}
