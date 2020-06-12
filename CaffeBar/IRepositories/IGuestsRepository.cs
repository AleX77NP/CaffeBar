using CaffeBar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeBar.Repositories
{
   public interface IGuestsRepository
    {
        IEnumerable<Guests> GetAllGuests();
        Guests GetGuestsById(int GuestsId);
        void AddGuests(Guests guests);
        void RemoveGuests(Guests guests);
        void RemoveByTable(int tableId);
    }
}
