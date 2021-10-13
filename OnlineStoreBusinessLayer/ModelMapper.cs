using System;
using ModelsLayer.EFModels;
using ModelsLayer.Models;
using OnlineStoreBusinessLayer.Interfaces;

namespace OnlineStoreBusinessLayer
{
  public class ModelMapper : IModelMapper
  {

    /// <summary>
    /// This method takes a ViewModelOrder and returns the mapping to a Order
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    public static Order ViewModelOrderToOrder(ViewModelOrder c)
    {
      Order c1 = new Order();
      c1.OrderId = c.OrderId;
      c1.CustomerId = c.CustomerId;
      c1.OrderDate = c.OrderDate;
      return c1;
    }

    /// <summary>
    /// This method takes a Product and returns the mapping to a ViewModelProduct
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    public static ViewModelOrder OrderToViewModelOrder(Order c)
    {
      ViewModelOrder c1 = new ViewModelOrder();
      c1.OrderId = c.OrderId;
      c1.CustomerId = c.CustomerId;
      c1.OrderDate = c.OrderDate;
      return c1;
    }

  }
}