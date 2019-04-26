using System;
using System.Collections.Generic;
using _04_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04_Challenge_Tests
{
    [TestClass]
    public class ClaimsTesting
    {
        Claim_Repo claimRepo = new Claim_Repo();
        [TestMethod]
        public void Claims_AddToQueue_ShouldAddToQueue()
        {
            //arrange
            DateTime date = new DateTime(19, 12, 20);
            Claims content = new Claims(1, ClaimType.Home, "break in", 2000, DateTime.Now, date, false);
            //act
            claimRepo.AddToQueue(content);
            Queue<Claims> queue = claimRepo.GetQueue();

            var expected = queue.Count;
            var actual = 1;
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Claims_GetContentByEnum_ShouldGetContentByEnum()
        {
            //arrange
            DateTime date = new DateTime(19, 11, 20);
            DateTime date2 = new DateTime(19, 12, 23);
            Claims content = new Claims(1, ClaimType.Home, "break in", 2000, DateTime.Now, date, false);
            Claims content2 = new Claims(1, ClaimType.Theft, "break in", 2000, DateTime.Now, date2, false);
            //act
            claimRepo.AddToQueue(content);
            Queue<Claims> queue = claimRepo.GetContentByEnum(ClaimType.Home);
            var actual = queue.Count;
            var expected = 1;

            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Claims_RemoveClaimFromQueue_ShouldRemoveAClaimFromTheQueue()
        {
            //arrange
            DateTime date = new DateTime(19, 11, 20);
            DateTime date2 = new DateTime(19, 12, 23);
            Claims content = new Claims(1, ClaimType.Home, "break in", 2000, DateTime.Now, date, false);
            Claims content2 = new Claims(1, ClaimType.Theft, "break in", 2000, DateTime.Now, date2, false);

            //act
            claimRepo.AddToQueue(content);
            claimRepo.AddToQueue(content2);
            claimRepo.RemoveClaimFromQueue();
            Queue<Claims> queue = claimRepo.GetQueue();

            var actual = queue.Count;
            var expected = 1;

            //assert
            Assert.AreEqual(actual, expected);
        }
    }
}
