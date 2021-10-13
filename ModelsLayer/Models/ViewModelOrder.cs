using System;


namespace ModelsLayer.Models
{
  public class ViewModelOrder
  {

    public ViewModelOrder() { }

    public ViewModelOrder(int customerId)
    {
      CustomerId = customerId;
    }


    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }

  }
}