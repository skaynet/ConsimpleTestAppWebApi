using ConsimpleTestAppWebApi.Data;
using ConsimpleTestAppWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsimpleTestAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly ConsimpleTestDbContext _context;

        public ShopController(ConsimpleTestDbContext context)
        {
            _context = context;
        }

        // GET: api/<ShopController>
        [HttpGet("ListOfBirthday")]
        public async Task<ActionResult<List<string[]>>> GetListOfBirthday(string dateString)
        {
            DateOnly date;
            try
            {
                date = DateOnly.Parse(dateString);
            }
            catch(Exception e)
            {
                return BadRequest(new { MessageError = e.Message });
            }

            List<Customer> customers =  await _context.Customers.Where(c => c.DateBirth == date).ToListAsync();

            if (customers.Count < 1)
            {
                return NotFound();
            }

            List<string[]> customersBirthday = new List<string[]>();
            foreach (Customer item in customers)
            {
                customersBirthday.Add([item.Id.ToString(), item.FullName]);
            }

            return customersBirthday;
        }

        [HttpGet("LatestPurchases")]
        public async Task<ActionResult<List<string[]>>> GetLatestPurchases(int days)
        {
            if (days < 1)
            {
                return BadRequest("The days is incorrectly indicated");
            }

            DateOnly startDate = DateOnly.FromDateTime(DateTime.Now).AddDays(days * -1);

            //List<Purchase> purchases = await _context.Purchases.Include(p => p.Customer).Where(p => p.Date >= startDate).ToListAsync();

            var purchases = await _context.Purchases.Include(p => p.Customer).Where(p => p.Date >= startDate).GroupBy(p => p.CustomerId)
                                            .Select(g => new { 
                                                g.Key, 
                                                LastPurchaseDate = g.Max(p => p.Date),
                                                CustomerFullName = _context.Customers
                                                                    .Where(c => c.Id == g.Key)
                                                                    .Select(c => c.FullName)
                                                                    .FirstOrDefault()
                                            }).ToListAsync();

            if (purchases.Count() < 1)
            {
                return NotFound();
            }

            List<string[]> result = new List<string[]>();
            foreach (var item in purchases)
            {
                result.Add([item.Key.ToString(), item.CustomerFullName!, item.LastPurchaseDate.ToString()]);
            }
            return result;
        }

        [HttpGet("CategoriesDeman")]
        public async Task<ActionResult<List<string[]>>> GetCategoriesDemand(int customerId)
        {
            Customer? customer = await _context.Customers.FindAsync(customerId);

            if (customer == null)
            {
                return NotFound();
            }

            var categoryPurchaseCounts = await _context.PurchaseProducts
                                                    .Where(pp => _context.Purchases.Any(p => p.Id == pp.PurchaseId && p.CustomerId == customerId))
                                                    .Join(_context.Products,
                                                        pp => pp.ProductId,
                                                        pr => pr.Id,
                                                        (pp, pr) => new { pr.СategoryId, pp.Amount })
                                                    .GroupBy(x => x.СategoryId)
                                                    .Select(g => new
                                                    {
                                                        CategoryName = _context.Сategories
                                                            .Where(c => c.Id == g.Key)
                                                            .Select(c => c.Name)
                                                            .FirstOrDefault(),
                                                        PurchaseCount = g.Sum(x => x.Amount)
                                                    })
                                                    .ToListAsync();

            if (categoryPurchaseCounts.Count < 1)
            {
                return NotFound();
            }

            List<string[]> result = new List<string[]>();
            foreach (var item in categoryPurchaseCounts)
            {
                result.Add([ item.CategoryName!, item.PurchaseCount.ToString() ]);
            }
            return result;
        }
    }
}
