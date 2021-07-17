using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Menu_Repository
{
    public class Menu_Content_Repository : I_Menu_Content_Repository
    {
        private readonly List<Menu_Content> _contentDirectory = new List<Menu_Content>();
        //Build out our CRUD methods

        //CREATE
        public void AddContentToMenu(Menu_Content content)
        {
            _contentDirectory.Add(content);
        }


        //READ
        //Get all our menu objects from our directory
        public List<Menu_Content> GetAllMenuContent()
        {
            return _contentDirectory;
        }

        //Get menu object by title
        public Menu_Content GetContentByDrink(string drink)
        {
            foreach (Menu_Content item in _contentDirectory)
            {
                if (item.Drink == drink)
                {
                    return item;
                }
            }

            return null;
        }


        //UPDATE
        public void UpdateDrinkByDescription(string drink, string description)
        {
            Menu_Content content = GetContentByDrink(drink);

            content.Description = description;
        }


        //DELETE
        public bool DeleteExistingItem(Menu_Content content)
        {
            return _contentDirectory.Remove(content);
        }


        public bool DeleteContentByItem(string drink)
        {
            Menu_Content content = GetContentByDrink(drink);

            return DeleteExistingItem(content);
        }

        public void UpdateBadgeByDoorNumber(object doorName, object badgeNames)
        {
            throw new NotImplementedException();
        }
    }
}
