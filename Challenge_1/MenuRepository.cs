using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class MenuRepository
    {
        // Fields
        private List<Menu> _menuList = new List<Menu>();

        public void AddItemToMenu(Menu menuItem)
        {
            _menuList.Add(menuItem);
        }

        public void DeleteItemFromMenu(Menu menuItem)
        {
            _menuList.Remove(menuItem);
        }

        public List<Menu> GetMenu()
        {
            return _menuList;
        }

        public Menu FindMenuItem(string name)
        {
            var menuItem = new Menu();

            foreach(var item in _menuList)
            {
                if (name == item.MealName)
                {
                    menuItem = item;
                    break;
                }
            }
            return menuItem;
        }
    }
}
