using CaffeBar.Data;
using CaffeBar.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace CaffeBar.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private CaffeContext context;
        private WaiterRepository waiters;
        private TableRepository tables;
        private BillRepository bills;
        private GuestsRepository guests;
        private DrinkRepository drinks;
        private AuthRepository auth;
        private BillDrinkRepository billDrinks;

        public UnitOfWork(CaffeContext context)
        {
            this.context = context;
        }
        public IWaiterRepository Waiters {
            get {
                return waiters ?? (waiters = new WaiterRepository(context));
            }
         }
        public IDrinkRepository Drinks
        {
            get
            {
                return drinks ?? (drinks = new DrinkRepository(context));
            }
        }

        public ITableRepository Tables {
            get {
                return tables ?? (tables = new TableRepository(context));
            }
        }

        public IBillRepository Bills { 
            get
            {
                return bills ?? (bills = new BillRepository(context));
            }
        }

        public IGuestsRepository Guests { 
            get
            {
                return guests ?? (guests = new GuestsRepository(context));
            }
        }

        public IBillDrinkRepository BillDrinks {
            get
            {
                return billDrinks ?? (billDrinks = new BillDrinkRepository(context));
            }
        }

        public IAuthRepository Auth
        {
            get
            {
                return auth ?? (auth = new AuthRepository(context));
            }
        }

        public void Complete()
        {
            context.SaveChanges();
        }
    }
}
