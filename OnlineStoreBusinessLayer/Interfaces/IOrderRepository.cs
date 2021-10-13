using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsLayer.Models;

namespace OnlineStoreBusinessLayer.Interfaces
{
  public interface IOrderRepository
  {
    Task<ViewModelOrder> OrdersAsync(ViewModelOrder vmc);

    Task<ViewModelOrder> RegisterOrdersAsync(ViewModelOrder vmc);

    Task<List<ViewModelOrder>> OrdersListAsync(ViewModelOrder vmc);

  }
}