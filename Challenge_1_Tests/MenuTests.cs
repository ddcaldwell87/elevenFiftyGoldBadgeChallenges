using System;
using System.Collections.Generic;
using Challenge_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_1_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MenuRepository_AddItemToMenu_GetMenu_ShouldAddAnItemToMenuList()
        {
            //-- Arrange
            MenuRepository _menuRepo = new MenuRepository();

            Menu item = new Menu();

            _menuRepo.AddItemToMenu(item); // Tested Method

            var list = _menuRepo.GetMenu(); // Tested Method

            //-- Act
            int actual = list.Count;
            int expected = 1;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MenuRepository_DeleteItemFromMenu_ShouldRemoveItemFromMenuList()
        {
            //-- Arrange
            MenuRepository _menuRepo = new MenuRepository();

            Menu item1 = new Menu();
            Menu item2 = new Menu();

            _menuRepo.AddItemToMenu(item1);
            _menuRepo.AddItemToMenu(item2);

            _menuRepo.DeleteItemFromMenu(item1); // Tested Method

            var list = _menuRepo.GetMenu();

            //-- Act
            int actual = list.Count;
            int expected = 1;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MenuRepository_FindMenuItem_ShouldFindSearchedItem()
        {
            //-- Arrange
            MenuRepository _menuRepo = new MenuRepository();

            Menu item1 = new Menu();
            item1.MealName = "Burger";
            _menuRepo.AddItemToMenu(item1);

            //-- Act
            Menu actual = _menuRepo.FindMenuItem("Burger");
            Menu expected = item1;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
