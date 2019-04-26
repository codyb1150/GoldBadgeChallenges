using System;
using System.Collections.Generic;
using _01_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Challenge_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Meal_AddToList_ShouldAddMealToList()
        {
            MenuRepo newRpo = new MenuRepo();
            //arrange
            MenuRepo menuRpo = new MenuRepo();
            Menu content = new Menu(2, "Burger", "Best Burger In Town", "Meat, onions, pickle, mayo", 10.20);
            //act
            menuRpo.AddToList(content);
            List<Menu> list = menuRpo.GetMealList();

            var actual = list.Count;
            var expected = 1;

            //assert
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(list.Contains(content));
        }
       
        [TestMethod]
        public void Meal_RemoveMealFromList_ShouldRemoveMealFromList()
        {
            //arrange
            MenuRepo menuRpo = new MenuRepo();
            Menu content = new Menu(2, "Burger", "Best Burger In Town", "Meat, onions, pickle, mayo", 10.20);
            Menu content2 = new Menu(3, "Burger", "Best Burger In Town", "Meat, onions, pickle, mayo", 10.20);

            //act
            menuRpo.AddToList(content);
            menuRpo.AddToList(content2);
            menuRpo.RemoveMealFromList(2);
            List<Menu> list = menuRpo.GetMealList();

            var actual = list.Count;
            var expected = 1;
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
