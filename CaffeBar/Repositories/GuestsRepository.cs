using CaffeBar.Data;
using CaffeBar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeBar.Repositories
{
    public class GuestsRepository : IGuestsRepository
    {
        private CaffeContext context;
        public GuestsRepository(CaffeContext contextDb)
        {
            context = contextDb;
        }

        public IEnumerable<Guests> GetAllGuests()
        {
            return context.Guests.ToList();
        }
        public Guests GetGuestsById(int GuestsId)
        {
            return context.Guests.Find(GuestsId);
        }
        public void AddGuests(Guests guests)
        {
            context.Guests.Add(guests);
        }
        public void RemoveGuests(Guests guests)
        {
            context.Guests.Remove(guests);
        }
        public void RemoveByTable(int tableId)
        {
            var chosen = context.Guests.Where(g => g.TableId == tableId).FirstOrDefault();
            context.Guests.Remove(chosen);
        }

    }
}
