using CaffeBar.Data;
using CaffeBar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeBar.Repositories
{
    public class BillRepository : IBillRepository
    {
        private CaffeContext context;

        public BillRepository(CaffeContext context)
        {
            this.context = context;
        }
        public void AddBill(Bill bill)
        {
            context.Bills.Add(bill);
        }

        public IEnumerable<Bill> GetAllBills()
        {
            return context.Bills.ToList();
        }

        public Bill GetBillById(int BillId)
        {
            return context.Bills.Find(BillId);
        }

        public void RemoveBill(Bill bill)
        {
            context.Bills.Remove(bill);
        }
    }
}
