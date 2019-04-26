using System;
using System.Collections.Generic;
using _03_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static _03_Challenge_Repository.Cars_Constructor;

namespace _03_Challeng_Tests
{
    [TestClass]
    public class ChallengeTests
    {
        Cars_Repository newRepo = new Cars_Repository();
        [TestMethod]
        public void Cars_AddToList_ShouldAddToList()
        {
            //arrange
            Cars content = new Cars(CarType.Electric, 123000, 15.5, "Tesla", "X", 120, "123ABC");

            //act
            newRepo.AddToList(content);
            List<Cars> list = newRepo.GetList();

            var actual = list.Count;
            var expected = 1;

            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Cars_GetListByCategories_ShouldGetListByCategories()
        {
            //arrange

            Cars content = new Cars(CarType.Electric, 123000, 0, "Tesla", "X", 120, "123ABC");
            Cars content2 = new Cars(CarType.Gas, 123000, 15.5, "Mazda", "3", 150, "321CBA");

            //act
            newRepo.AddToList(content);
            List<Cars> list = newRepo.GetListByCategories(CarType.Electric);

            var actual = list.Count;
            var expected = 1;

            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Cars_RemoveCarFromList_ShouldRemoveACarFromAList()
        {
            //arrange
            Cars_Repository carRepo = new Cars_Repository();
            Cars content = new Cars(CarType.Electric, 123000, 0, "Tesla", "X", 120, "123ABC");
            Cars content2 = new Cars(CarType.Gas, 123000, 15.5, "Mazda", "3", 150, "321CBA");

            //act
            carRepo.AddToList(content);
            carRepo.AddToList(content2);
            carRepo.RemovCarFromList("123ABC");
            List<Cars> list = carRepo.GetList();
            var actual = list.Count;
            var expected = 1;

            //assert
            Assert.AreEqual(actual, expected);
        }
    }
}
