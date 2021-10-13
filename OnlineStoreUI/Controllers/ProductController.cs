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
  public class ProductController : ControllerBase
  {

    private readonly OnlineStoreDBContext _context;

    public ProductController(OnlineStoreDBContext context)
    {
      _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
      return await _context.Products.ToListAsync();
    }

    [HttpGet("storeid={id}")]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts(int id)
    {
      var products = await _context.Products.FromSqlRaw<Product>($"select * from Products where StoreId ='{id}'").ToListAsync();

      if (products == null)
      {
        return NotFound();
      }

      return products;
    }

  }
}