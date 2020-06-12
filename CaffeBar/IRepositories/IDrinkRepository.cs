using CaffeBar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeBar.Repositories
{
    public interface IDrinkRepository
    {
        IEnumerable<Drink> GetAllDrinks();
        Drink GetDrinkById(int DrinkId);
        void AddDrink(Drink drink);
        void RemoveDrink(Drink drink);
    }
}
