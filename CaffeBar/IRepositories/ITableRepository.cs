using CaffeBar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeBar.Repositories
{
    public interface ITableRepository
    {
        IEnumerable<Table> GetAllTables();
        Table GetTableById(int TableId);
        void AddTable(Table table);
        void RemoveTable(Table table);
    }
}
