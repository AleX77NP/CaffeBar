using CaffeBar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeBar.Data
{
    public class CaffeContext : DbContext
    {
        public CaffeContext(DbContextOptions<CaffeContext> options) : base(options) { }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<Table> Tables {get; set;}
        public DbSet<Guests> Guests { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<CaffeAuth> Auth { get; set; }
        public DbSet<BillDrink> BillDrinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drink>().HasKey(d => new { d.DrinkId });
            modelBuilder.Entity<Bill>().HasKey(b => new { b.BillId });
            modelBuilder.Entity<Table>().HasKey(t => new { t.TableId });
            modelBuilder.Entity<Waiter>().HasKey(w => new { w.WaiterId });
            modelBuilder.Entity<Guests>().HasKey(g => new { g.GuestsId });
            modelBuilder.Entity<BillDrink>().HasKey(bd => new { bd.BillDrinkId });
            modelBuilder.Entity<CaffeAuth>().HasKey(ca => new { ca.Username });

            modelBuilder.Entity<CaffeAuth>().Property(ca => ca.Password).IsRequired();
            modelBuilder.Entity<CaffeAuth>().Property(ca => ca.Password).HasMaxLength(20);

            modelBuilder.Entity<Drink>().Property(d => d.Title).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Drink>().Property(d => d.Price).IsRequired();
            modelBuilder.Entity<Drink>().Property(d => d.TaxRate).IsRequired();
            modelBuilder.Entity<Drink>().Property(d => d.Available).IsRequired().HasDefaultValue(100);
            modelBuilder.Entity<Drink>().Property(d => d.TotalDrink).IsRequired().HasDefaultValue(0);
            modelBuilder.Entity<Drink>().Property(d => d.Count).IsRequired().HasDefaultValue(0);


            modelBuilder.Entity<Bill>().Property(b => b.DateAndTime).IsRequired();
            modelBuilder.Entity<Bill>().Property(b => b.TotalPrice).IsRequired().HasDefaultValue(0);

            modelBuilder.Entity<Table>().Property(t => t.Marking).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Table>().Property(t => t.Title).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<Table>().Property(t => t.Taken).IsRequired().HasDefaultValue(false);

            modelBuilder.Entity<Waiter>().Property(w => w.Name).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<Waiter>().Property(w => w.Surname).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Waiter>().Property(w => w.Age).IsRequired();
            modelBuilder.Entity<Waiter>().Property(w => w.Salary).IsRequired();
            modelBuilder.Entity<Waiter>().Property(w => w.Phone).IsRequired().HasMaxLength(20);

            modelBuilder.Entity<Guests>().Property(g => g.NumOfPersons).IsRequired();
            modelBuilder.Entity<Guests>().Property(g => g.Reservation).IsRequired().HasMaxLength(5);
            modelBuilder.Entity<Guests>().Property(g => g.ReservationTime).IsRequired().HasMaxLength(50).HasDefaultValue("No time");
            modelBuilder.Entity<Guests>().Property(g => g.ReservationName).IsRequired().HasMaxLength(25).HasDefaultValue("No name");

            modelBuilder.Entity<BillDrink>().HasOne(bd => bd.Drink).WithMany(d => d.BillDrinks).HasForeignKey(bd => bd.DrinkId);
            modelBuilder.Entity<BillDrink>().HasOne(bd => bd.Bill).WithMany(b => b.BillDrinks).HasForeignKey(bd => bd.BillId);

            modelBuilder.Entity<Bill>().HasOne(b => b.Waiter).WithMany(w => w.Bills).IsRequired();
            modelBuilder.Entity<Bill>().HasOne(b => b.Table).WithMany(t => t.Bills).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
