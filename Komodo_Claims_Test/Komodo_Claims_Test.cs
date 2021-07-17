using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Komodo_Claims_Repository;

namespace Komodo_Claims_Test
{
    [TestClass]
    public class Komodo_Claims_Test
    {
        [TestMethod]
        public void CreateClaimWithName_ShouldSetClaimDescription()
        {
            // Arrange
            int claimID = 5;
            var description = "Motorcycle hit a wall";
            int claimAmmount = 50000;

            // Act
            var claimsMenu = new Claims_Content(claimID, Claims_Content.Claimtype.Motorcycle, description, claimAmmount, DateTime.Now, DateTime.Now);
            // Assert
            Assert.AreEqual(claimID, description);
        }
    }
}
