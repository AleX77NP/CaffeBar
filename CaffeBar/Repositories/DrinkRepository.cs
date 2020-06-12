using CaffeBar.Data;
using CaffeBar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeBar.Repositories
{
    public class DrinkRepository : IDrinkRepository
    {
        private CaffeContext context;

        public DrinkRepository(CaffeContext context)
        {
            this.context = context;
        }

        public IEnumerable<Drink> GetAllDrinks()
        {
            return context.Drinks.ToList();
        }
        public Drink GetDrinkById(int DrinkId)
        {
            return context.Drinks.Find(DrinkId);
        }
        public void AddDrink(Drink drink)
        {
            context.Drinks.Add(drink);
        }
        public void RemoveDrink(Drink drink)
        {
            context.Drinks.Remove(drink);
        }
    }
}
