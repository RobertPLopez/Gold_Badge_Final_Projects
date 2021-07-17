using System.Collections.Generic;

namespace Komodo_Menu_Repository
{
    public interface I_Menu_Content_Repository
    {
        void AddContentToMenu(Menu_Content content);
        bool DeleteContentByItem(string drink);
        bool DeleteExistingItem(Menu_Content content);
        List<Menu_Content> GetAllMenuContent();
        Menu_Content GetContentByDrink(string drink);
        void UpdateDrinkByDescription(string drink, string description);
    }
}