using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Komodo_Badges_Repo;

namespace Komodo_Badges_Test
{
    [TestClass]
    public class Komodo_Badges_Test1
    {
        [TestMethod]
        public void CreateBadge_ShouldSetBadgeDoors()
        {
            // Arrange
            var doorDescription = "North, South, East, West";

            // Act
            var newBadge = new Komodo_Badge(doorDescription);
            // Assert
            Assert.AreEqual(doorDescription, 0);
        }
    }
}
