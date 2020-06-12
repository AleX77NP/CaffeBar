using CaffeBar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeBar.IRepositories
{
    public interface IBillDrinkRepository
    {
        IEnumerable<BillDrink> GetAllBillDrinks();
        IEnumerable<BillDrink> GetAllByBill(int BillId);
        BillDrink GetBillDrinkById(int BillDrinkId);
        void AddBillDrink(BillDrink billDrink);
        void RemoveBillDrink(BillDrink billDrink);
    }
}
