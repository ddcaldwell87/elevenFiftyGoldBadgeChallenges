using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class Menu
    {
        // Constructor
        public Menu(){}

        public Menu(int mealNum, string mealName, string desc, List<string> ingredients, decimal price)
        {
            MealNum = mealNum;
            MealName = mealName;
            Desc = desc;
            Ingredients = ingredients;
            Price = price;
        }

        // Properties
        public int MealNum { get; set; }
        public string MealName { get; set; }
        public string Desc { get; set; }
        public List<string> Ingredients { get; set; }
        public decimal Price { get; set; }
    }
}
