using System;
using System.Collections.Generic;
using _02_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static _02_Challenge_Repository.OutingContrustor;

namespace _02_Challenge_Tests
{
    [TestClass]
    public class challengetesting
    {
        [TestMethod] 
        public void Outing_AddToList_ShouldAddToList()
        {
            //arrange
            OutingRepository outingRepo = new OutingRepository();
            Outing content = new Outing(EventType.AmusementPark, 5000, new DateTime(12, 12, 12), 15, 75000);
            //act
            outingRepo.AddToList(content);
            List<Outing> list = outingRepo.GetOutingList();

            var actual = list.Count;
            var expected = 1;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Outing_RemoveOutingFromList_ShouldRemoveOutingFromList()
        {
            //arrange
            OutingRepository outingRepo = new OutingRepository();
            Outing content = new Outing(EventType.AmusementPark, 5000, new DateTime(12, 12, 12), 15, 75000);
            Outing content2 = new Outing(EventType.AmusementPark, 5000, new DateTime(12, 12, 11), 15, 75000);

            //act
            outingRepo.AddToList(content);
            outingRepo.AddToList(content2);
            outingRepo.RemoveOutingFromList(EventType.AmusementPark);
            List<Outing> list = outingRepo.GetOutingList();
            var actual = list.Count;
            var expected = 1;

            //assert
            Assert.AreEqual(actual, expected);
        }
    }
    
}
