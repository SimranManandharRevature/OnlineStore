using System;
using ModelsLayer.EFModels;
using ModelsLayer.Models;

namespace OnlineStoreBusinessLayer.Interfaces
{
  public class IModelMapper
  {
    Order ViewModelOrderToOrder(ViewModelOrder c) { throw new NotImplementedException(); }
    ViewModelOrder OrderToViewModelOrder(Order c) { throw new NotImplementedException(); }
  }
}