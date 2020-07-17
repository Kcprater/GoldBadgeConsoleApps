using System;
using System.Collections.Generic;
using System.IO;
using ChallengeFour_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeFour_Tests
{
    [TestClass]
    public class KomodoOutingsTests
    {
        [TestMethod]
        public void CreateNewOuting_ShouldGetCorrectBool()
        {
            //Arrange
            Outings newOuting = new Outings();
            OutingsRepo repo = new OutingsRepo();
            //Act
            bool createOuting = repo.CreateNewOuting(newOuting);
            //Assert
            Assert.IsTrue(createOuting);
        }
        [TestMethod]
        public void ViewAllOutings_ShouldReturnCorrectBool()
        {
            //Arrange
            Outings newOuting = new Outings();
            OutingsRepo repo = new OutingsRepo();
            repo.CreateNewOuting(newOuting);
            //Act
            List<Outings> contents = repo.ViewAllOutings();
            bool directoryHasContent = contents.Contains(newOuting);
            //Assert
            Assert.IsTrue(directoryHasContent);
        }
    }
}
