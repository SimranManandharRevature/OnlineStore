using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBStoreContext.Models;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.EFModels;
using ModelsLayer.Models;
using OnlineStoreBusinessLayer.Interfaces;


namespace OnlineStoreBusinessLayer
{
  public class OrderRepository : IOrderRepository
  {

    private readonly OnlineStoreDBContext _context;

    // step 2 of DI - call for an in stance from the DI system in your constructor.
    public OrderRepository(OnlineStoreDBContext context)
    {
      _context = context;
    }
    public async Task<ViewModelOrder> OrdersAsync(ViewModelOrder vmc)
    {
      // Order c1 = ModelMapper.ViewModelOrderToOrder(vmc);

      Order c2 = await _context.Orders.FromSqlRaw<Order>("SELECT * FROM Orders WHERE CustomerId = {0}", vmc.CustomerId).FirstOrDefaultAsync();// default is NULL

      if (c2 == null) return null;

      ViewModelOrder c3 = ModelMapper.OrderToViewModelOrder(c2);
      return c3;
    }

    public async Task<ViewModelOrder> RegisterOrdersAsync(ViewModelOrder vmc)
    {
      Order c1 = ModelMapper.ViewModelOrderToOrder(vmc);

      int c2 = await _context.Database.ExecuteSqlRawAsync("INSERT INTO Orders (CustomerId) VALUES ({0})", c1.CustomerId);// default is NULL

      if (c2 != 1) return null;

      //Customer c3 = _context.Customers.FromSqlRaw<Customer>("SELECT * FROM Customers WHERE FirstName = {0} and LastName = {1}", c1.FirstName, c1.LastName).FirstOrDefault();// default is NULL

      //if (c2 == null) return null;

      //ViewModelCustomer c4 = ModelMapper.CustomerToViewModelCustomer(c3);
      //return c4;

      return await OrdersAsync(vmc);
    }

    public async Task<List<ViewModelOrder>> OrdersListAsync(ViewModelOrder vmc)
    {
      List<Order> orders = await _context.Orders.FromSqlRaw<Order>("Select * FROM Orders where OrderId = {0}", vmc.OrderId).ToListAsync();
      List<ViewModelOrder> vmc1 = new List<ViewModelOrder>();
      foreach (Order o in orders)
      {
        vmc1.Add(ModelMapper.OrderToViewModelOrder(o));
      }
      return vmc1;
    }
  }
}

