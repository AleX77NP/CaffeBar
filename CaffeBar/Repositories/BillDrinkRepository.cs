using CaffeBar.Data;
using CaffeBar.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeBar.Repositories
{
    public class BillDrinkRepository : IBillDrinkRepository
    {
        private CaffeContext context;

        public BillDrinkRepository(CaffeContext context)
        {
            this.context = context;
        }
        public BillDrink GetBillDrinkById(int BillDrinkId)
        {
            return context.BillDrinks.Find(BillDrinkId);
        }
        public IEnumerable<BillDrink> GetAllBillDrinks()
        {
            return context.BillDrinks.ToList();
        }
        public IEnumerable<BillDrink> GetAllByBill(int BillId)
        {
            return context.BillDrinks.Where(bd => bd.BillId == BillId).ToList();
        }
        public void AddBillDrink(BillDrink billDrink)
        {
            context.BillDrinks.Add(billDrink);
        }
        public void RemoveBillDrink(BillDrink billDrink)
        {
            context.BillDrinks.Remove(billDrink);
        }

    }
}
