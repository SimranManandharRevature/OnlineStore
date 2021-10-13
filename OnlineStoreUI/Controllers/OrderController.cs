using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBStoreContext.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer.EFModels;
using Microsoft.EntityFrameworkCore;
using OnlineStoreBusinessLayer.Interfaces;
using OnlineStoreUi;
using ModelsLayer.Models;
using Microsoft.Extensions.Logging;


namespace OnlineStoreUi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class OrderController : ControllerBase
  {

    private readonly IOrderRepository _orderRepo;
    private readonly ILogger<OrderController> _logger;

    public OrderController(IOrderRepository cr, ILogger<OrderController> logger)
    {
      _orderRepo = cr;
      _logger = logger;
    }


    [HttpPost]
    // public async Task<ActionResult<Order>> PostOrder(Order order)
    // {
    //   _context.Orders.Add(order);
    //   await _context.SaveChangesAsync();

    //   return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
    // }

    public async Task<ActionResult<ViewModelOrder>> Create(ViewModelOrder c)
    {
      // _context.Orders.Add(order);
      // await _context.SaveChangesAsync();

      // // return Created($"~order/{order.CustomerId}", order);
      // return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);

      if (!ModelState.IsValid) return BadRequest();

      //ViewModelCustomer c = new ViewModelCustomer() { Fname = fname, Lname = lname };
      //send fname and lname into a method of the business layer to check the Db fo that guy/gal;
      ViewModelOrder c1 = await _orderRepo.RegisterOrdersAsync(c);
      if (c1 == null)
      {
        return NotFound();
      }
      return Created($"~order/{c1.OrderId}", c1);
    }

    [HttpGet("{selectorderId}")]
    public async Task<ActionResult<ViewModelOrder>> GetOrderList(int selectorderId)
    {
      //  if (!ModelState.IsValid) return BadRequest();

      ViewModelOrder o = new ViewModelOrder() { OrderId = selectorderId };
      //send fname and lname into a method of the business layer to check the Db fo that guy/gal;
      List<ViewModelOrder> o1 = await _orderRepo.OrdersListAsync(o);
      if (o1 == null)
      {
        return NotFound();
      }

      return Ok(o1);
    }

  }
}