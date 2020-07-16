using System;
using System.Collections.Generic;
using System.Security.Claims;
using ChallengeTwo_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeTwo_Test
{
    [TestClass]
    public class KomodoClaimsTests
    {
        [TestMethod]
        public void AddNewClaim_ShouldGetCorrectBoolean()
        {
            //Arrange
            Claims claim = new Claims();
            ClaimsRepo repo = new ClaimsRepo();
            //Act
            bool addClaim = repo.AddNewClaim(claim);
            //Assert
            Assert.IsTrue(addClaim);
        }
        [TestMethod]
        public void ViewClaims_ShouldReturnClaims()
        {
            //Arrange
            Claims claim = new Claims();
            ClaimsRepo repo = new ClaimsRepo();
            repo.AddNewClaim(claim);
            //Act
            Queue<Claims> claims = repo.ViewClaims();
            bool queueHasClaims = claims.Contains(claim);
            //Assert
            Assert.IsTrue(queueHasClaims);
        }
        [TestMethod]
        public void RemoveClaim_ShouldGetCorrectBoolean()
        {
            //Arrange
            Claims claim = new Claims();
            ClaimsRepo repo = new ClaimsRepo();
            repo.AddNewClaim(claim); //Don't Forget - Has To Have Something To Delete!!!!!
            //Act
            bool deleteClaim = repo.RemoveClaim(claim);
            //Assert
            Assert.IsTrue(deleteClaim);
        }
        private ClaimsRepo _repo;
        private Claims _nextClaim;
        private Claims _anotherClaim;
        private Claims _oneMoreClaim;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimsRepo();
            _nextClaim = new Claims(3, ClaimType.Theft, "Broken Window. TV was stolen.", 674.38d, new DateTime(2016, 12, 10), new DateTime(2017, 01, 02));
            _anotherClaim = new Claims(4, ClaimType.Theft, "Broken Window. TV was stolen.", 674.38d, new DateTime(2016, 12, 10), new DateTime(2017, 01, 02));
            _oneMoreClaim = new Claims(5, ClaimType.Theft, "Broken Window. TV was stolen.", 674.38d, new DateTime(2016, 12, 10), new DateTime(2017, 01, 02));
            _repo.AddNewClaim(_nextClaim);
            _repo.AddNewClaim(_anotherClaim);
            _repo.AddNewClaim(_oneMoreClaim);
        }
        [TestMethod]
        public void HandleNextClaim_ShouldGetCorrectBoolean()
        {
            //Act
            Claims claim = _repo.TakeCareOfNextClaim();
            //Assert
            Assert.AreEqual(_nextClaim, claim );
        }
    }
}
