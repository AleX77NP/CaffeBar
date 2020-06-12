using CaffeBar.Data;
using CaffeBar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeBar.Repositories
{
    public class TableRepository : ITableRepository
    {
        private CaffeContext context;

        public TableRepository(CaffeContext context)
        {
            this.context = context;
        } 

        public IEnumerable<Table> GetAllTables()
        {
            return context.Tables.ToList();
        }
        public Table GetTableById(int TableId)
        {
            return context.Tables.Find(TableId);
        }
        public void AddTable(Table table)
        {
            context.Tables.Add(table);
        }
        public void RemoveTable(Table table)
        {
            context.Tables.Remove(table);
        }
    }
}
