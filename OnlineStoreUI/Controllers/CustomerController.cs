using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer.EFModels;
using DBStoreContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace OnlineStoreUi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomerController : ControllerBase
  {
    private readonly OnlineStoreDBContext _context;

    private readonly ILogger<CustomerController> _logger;

    public CustomerController(OnlineStoreDBContext context, ILogger<CustomerController> logger)
    {
      _context = context;
      _logger = logger;
    }

    //    public CustomerController(ILogger<CustomerController> logger)
    //    {
    //        _logger = logger;
    //    }

    //    public CustomerController(OnlineStoreDBContext context)
    //{
    //  _context = context;
    //}

    // GET: api/Customer
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
    {
      return await _context.Customers.ToListAsync();
    }

    // GET: api/Customers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomer(int id)
    {
      var customer = await _context.Customers.FindAsync(id);

      if (customer == null)
      {
        return NotFound();
      }

      return customer;
    }

    //method is async because copy pasted the template
    // GET: api/Customers/firstAndLastName
    /// <summary>
    /// This method takes a name and email and returns a validated customer's ID if found 
    /// otherwise returns NotFound()
    /// </summary>
    /// <param name="name"></param>
    /// <param name="email"></param>
    /// <returns></returns>
    [HttpGet("{name}&{email}")]
    public async Task<ActionResult<int>> CustomerLogin(string name, string email)
    {
      if (!ModelState.IsValid) return BadRequest();

      var customer = await _context.Customers.FromSqlRaw<Customer>($"select * from Customers where Name = '{name}' and Email = '{email}'").ToListAsync();

      _logger.LogInformation($"{customer[0].Name} LoggedIn");

      if (customer.Count == 1) return customer[0].CustomerId;
      else return NotFound();
    }

    // PUT: api/Customers/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCustomer(int id, Customer customer)
    {
      if (id != customer.CustomerId)
      {
        return BadRequest();
      }

      _context.Entry(customer).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!CustomerExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/Customers
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
    {
      _context.Database.ExecuteSqlRaw($"insert into Customers (Name,Email) values ('{customer.Name}','{customer.Email}')");
      await _context.SaveChangesAsync();
      _logger.LogInformation($"{customer.Name} Registered New User");

      return Created($"~customer/{customer.CustomerId}", customer);
    }

    // DELETE: api/Customers/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
      var customer = await _context.Customers.FindAsync(id);
      if (customer == null)
      {
        return NotFound();
      }

      _context.Customers.Remove(customer);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool CustomerExists(int id)
    {
      return _context.Customers.Any(e => e.CustomerId == id);
    }
  }


}
