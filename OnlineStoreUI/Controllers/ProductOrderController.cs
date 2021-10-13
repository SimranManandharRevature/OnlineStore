using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBStoreContext.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer.EFModels;
using Microsoft.EntityFrameworkCore;


namespace OnlineStoreUi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductOrderController : ControllerBase
  {

    private readonly OnlineStoreDBContext _context;

    public ProductOrderController(OnlineStoreDBContext context)
    {
      _context = context;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductOrder>> GetProductOrder(int id)
    {
      var productorder = await _context.ProductOrders.FindAsync(id);

      if (productorder == null)
      {
        return NotFound();
      }

      return productorder;
    }

    [HttpPost]
    public async Task<ActionResult<ProductOrder>> PostProductOrder(ProductOrder productorder)
    {
      _context.Database.ExecuteSqlRaw($"insert into ProductOrder (ProductId, OrderId, Quantity) values ('{productorder.ProductId}' ,'{productorder.OrderId}', '{productorder.Quantity}')");
      await _context.SaveChangesAsync();

      return Created($"~productorder/{productorder.ProductOrderId}", productorder);
      // return CreatedAtAction(nameof(GetProductOrder), new { id = productorder.ProductOrderId }, productorder);
    }

    private bool ProductOrderExists(int id)
    {
      return _context.ProductOrders.Any(e => e.OrderId == id);
    }

  }
}
