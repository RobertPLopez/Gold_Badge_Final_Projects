using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Menu_Repository
{

    //POCO Plain Old C# Object
    public class Menu_Content
    {
        //Empty Constructor
        public Menu_Content() { }

        //Full Constructor
        public Menu_Content(string drink, string description, int price, IngrediemtType ingredient)
        {
            Drink = drink;
            Description = description;
            Price = price;
            Ingredient = ingredient;
        }

        public string Drink { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public IngrediemtType Ingredient { get; set; }
    }

    public enum IngrediemtType
    {
        Latte,
        Coffee,
        Americano,
        Machiato,
        Misto,
    }
}
