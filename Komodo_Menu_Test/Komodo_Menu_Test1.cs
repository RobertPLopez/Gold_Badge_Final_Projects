using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Komodo_Menu_Repository;

namespace Komodo_Menu_Test
{
    [TestClass]
    public class Komodo_Menu_Test1
    {
        [TestMethod]
        public void CreateItemWithName_ShouldSetName()
        {
            // Arrange
            var drink = "Capachino";
            var description = "A foamy delight";
            int price = 2;

            // Act
            var menuWithDrink = new Menu_Content(drink, description, price, IngrediemtType.Latte);

            // Assert
            Assert.AreEqual(drink, description);
        }
    }
}
