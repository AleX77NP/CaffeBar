using CaffeBar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeBar.Repositories
{
    public interface IBillRepository
    {
        IEnumerable<Bill> GetAllBills();
        Bill GetBillById(int BillId);
        void AddBill(Bill bill);
        void RemoveBill(Bill bill);
    }
}
