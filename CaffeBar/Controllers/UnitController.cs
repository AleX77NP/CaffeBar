using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaffeBar.Data;
using CaffeBar.Models;
using CaffeBar.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CaffeBar.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class UnitController : Controller
    {
        private  UnitOfWork unit;
        private CaffeContext context;
        public UnitController(CaffeContext caffeContext)
        {
            context = caffeContext;
            unit = new UnitOfWork(context);
        }
        [HttpGet]
        [Route("api/drinks")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Drink>> GetDrinks()
        {
            try
            {
                return Ok(unit.Drinks.GetAllDrinks());
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get drinks, " + ex.ToString());
            }
        }
        [HttpGet]
        [Route("api/tables")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Table>> GetTables()
        {
            try
            {
                return Ok(unit.Tables.GetAllTables());
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get tables, " + ex.ToString());
            }
        }
        [HttpGet]
        [Route("api/waiters")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Waiter>> GetWaiters()
        {
            try
            {
                return Ok(unit.Waiters.GetAllWaiters());
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get waiters, " + ex.ToString());
            }
        }
        [HttpGet]
        [Route("api/bills")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Bill>> GetBills()
        {
            try
            {
                return Ok(unit.Bills.GetAllBills());
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get bills, " + ex.ToString());
            }
        }
        [HttpGet]
        [Route("api/guests")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Guests>> GetGuests()
        {
            try
            {
                return Ok(unit.Guests.GetAllGuests());
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get guests, " + ex.ToString());
            }
        }
        [HttpGet]
        [Route("api/billdrinks")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<BillDrink>> GetBillDrinks()
        {
            try
            {
                return Ok(unit.BillDrinks.GetAllBillDrinks());
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get bill drinks, " + ex.ToString());
            }
        }
        [HttpGet]
        [Route("api/drinks/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetDrinkById(int id)
        {
            try
            {
                var drink = unit.Drinks.GetDrinkById(id);
                if (drink != null) return Ok(drink);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get drink, " + ex.ToString());
            }
        }
        [HttpPost]
        [Route("api/drinks/create")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult NewDrink ([FromBody]Drink drink)
        {
            try
            {
                unit.Drinks.AddDrink(drink);
                unit.Complete();
                return Ok("New drink added!");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to add drink, " + ex.ToString());
            }
        }
        [HttpDelete]
        [Route("api/drinks/delete/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult DeleteDrink(int id)
        {
            try
            {
                var drink = unit.Drinks.GetDrinkById(id);
                if (drink != null) {
                    unit.Drinks.RemoveDrink(drink);
                    unit.Complete();
                    return Ok("Drink is removed!");
                }
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to delete drink, " + ex.ToString());
            }
        }
        [HttpGet]
        [Route("api/tables/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetTableById(int id)
        {
            try
            {
                var table= unit.Tables.GetTableById(id);
                if (table != null) return Ok(table);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get table, " + ex.ToString());
            }
        }
        [HttpPost]
        [Route("api/tables/create")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult NewTable([FromBody] Table table)
        {
            try
            {
                unit.Tables.AddTable(table);
                unit.Complete();
                return Ok("New table added!");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to add table, " + ex.ToString());
            }
        }
        [HttpDelete]
        [Route("api/tables/delete/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult DeleteTable(int id)
        {
            try
            {
                var table = unit.Tables.GetTableById(id);
                if (table != null)
                {
                    unit.Tables.RemoveTable(table);
                    unit.Complete();
                    return Ok("Table is removed!");
                }
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to delete table, " + ex.ToString());
            }
        }
        [HttpGet]
        [Route("api/waiters/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetWaiterById(int id)
        {
            try
            {
                var waiter = unit.Waiters.GetWaiterById(id);
                if (waiter != null) return Ok(waiter);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get waiter, " + ex.ToString());
            }
        }
        [HttpPost]
        [Route("api/waiters/create")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult NewWaiter([FromBody] Waiter waiter)
        {
            try
            {
                unit.Waiters.AddWaiter(waiter);
                unit.Complete();
                return Ok("New waiter added!");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to add waiter, " + ex.ToString());
            }
        }
        [HttpDelete]
        [Route("api/waiters/delete/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult DeleteWaiter(int id)
        {
            try
            {
                var waiter = unit.Waiters.GetWaiterById(id);
                if (waiter != null)
                {
                    unit.Waiters.RemoveWaiter(waiter);
                    unit.Complete();
                    return Ok("Waiter is removed!");
                }
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to delete waiter, " + ex.ToString());
            }
        }
        [HttpGet]
        [Route("api/guests/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetGuestsById(int id)
        {
            try
            {
                var guests = unit.Guests.GetGuestsById(id);
                if (guests != null) return Ok(guests);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get guests, " + ex.ToString());
            }
        }
        [HttpPost]
        [Route("api/guests/create")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult NewGuests([FromBody] Guests guests)
        {
            try
            {
                unit.Guests.AddGuests(guests);
                unit.Complete();
                return Ok("New guests added!");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to add guests, " + ex.ToString());
            }
        }
        [HttpDelete]
        [Route("api/guests/delete/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult DeleteGuests(int id)
        {
            try
            {
                if (id != 0)
                {
                    unit.Guests.RemoveByTable(id);
                    unit.Complete();
                    return Ok("Guests are removed!");
                }
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to delete guests, " + ex.ToString());
            }
        }
        [HttpGet]
        [Route("api/bills/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetBillsById(int id)
        {
            try
            {
                var bills = unit.Bills.GetBillById(id);
                if (bills != null) return Ok(bills);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get bill, " + ex.ToString());
            }
        }
        [HttpPost]
        [Route("api/bills/create")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult NewBill([FromBody] Bill bill)
        {
            try
            {
                unit.Bills.AddBill(bill);
                unit.Complete();
                return Ok(bill);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to add bill, " + ex.ToString());
            }
        }
        [HttpDelete]
        [Route("api/bills/delete/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult DeleteBill(int id)
        {
            try
            {
                var bill = unit.Bills.GetBillById(id);
                if (bill != null)
                {
                    unit.Bills.RemoveBill(bill);
                    unit.Complete();
                    return Ok("Bill is removed!");
                }
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to delete bill, " + ex.ToString());
            }
        }
        [HttpGet]
        [Route("api/billdrinks/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetBillDrinksByBill(int id)
        {
            try
            {
                var billdrinks = unit.BillDrinks.GetAllByBill(id);
                if (billdrinks != null) return Ok(billdrinks);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get bill drinks by bill, " + ex.ToString());
            }
        }
        [HttpPost]
        [Route("api/billdrinks/create")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult NewBillDrink([FromBody] BillDrink billDrink)
        {
            try
            {
                unit.BillDrinks.AddBillDrink(billDrink);
                unit.Complete();
                return Ok("New bill drink added!");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to add bill drink, " + ex.ToString());
            }
        }
        [HttpDelete]
        [Route("api/billdrinks/delete/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult DeleteBillDrink(int id)
        {
            try
            {
                var billDrink = unit.BillDrinks.GetBillDrinkById(id);
                if (billDrink != null)
                {
                    unit.BillDrinks.RemoveBillDrink(billDrink);
                    unit.Complete();
                    return Ok("Bill drink is removed!");
                }
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to delete bill drink, " + ex.ToString());
            }
        }
        [HttpPost]
        [Route("api/auth")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult CheckAuth([FromBody] CaffeAuth auth)
        {
            try
            {
                if(unit.Auth.CombinationExists(auth)) return Ok("Combination exists.");
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to add bill drink, " + ex.ToString());
            }
        }
        [HttpPut]
        [Route("api/waiters/edit/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult EditWaiter(int id, [FromBody] Waiter waiter)
        {
            try
            {
                var waiterOld = unit.Waiters.GetWaiterById(id);
                if (waiterOld != null)
                {
                    waiterOld.Name = waiter.Name;
                    waiterOld.Surname = waiter.Surname;
                    waiterOld.Age = waiter.Age;
                    waiterOld.Salary = waiter.Salary;
                    waiterOld.Phone = waiter.Phone;
                    unit.Complete();
                    return Ok("Waiter is updated!");
                }
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to update waiter, " + ex.ToString());
            }
        }

        [HttpPut]
        [Route("api/drinks/edit/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult EditDrink(int id, [FromBody] Drink drink)
        {
            try
            {
                var drinkOld = unit.Drinks.GetDrinkById(id);
                if (drinkOld != null)
                {
                    drinkOld.Title = drink.Title;
                    drinkOld.Price = drink.Price;
                    drinkOld.TaxRate = drink.TaxRate;
                    drinkOld.Available = drink.Available;
                    unit.Complete();
                    return Ok("Drink is updated!");
                }
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to update drink, " + ex.ToString());
            }
        }
        [HttpPut]
        [Route("api/tables/edit/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult EditTable(int id, [FromBody] Table table)
        {
            try
            {
                var tableOld = unit.Tables.GetTableById(id);
                if (tableOld != null)
                {
                    tableOld.Marking = table.Marking;
                    tableOld.Title = table.Title;
                    tableOld.Taken = table.Taken;
                    unit.Complete();
                    return Ok("Table is updated!");
                }
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to update table, " + ex.ToString());
            }
        }
        [HttpPost]
        [Route("api/auth/login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Login(int id, [FromBody] CaffeAuth auth)
        {
            try
            {
                var isThere = unit.Auth.CombinationExists(auth);
                if (isThere) return Ok(auth);
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to update table, " + ex.ToString());
            }
        }


    }
}
