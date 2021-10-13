using System;
using System.Collections.Generic;

#nullable disable

namespace ModelsLayer.EFModels
{
  public partial class Order
  {
    public Order()
    {
      ProductOrders = new HashSet<ProductOrder>();
    }

    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }

    public virtual Customer Customer { get; set; }
    public virtual ICollection<ProductOrder> ProductOrders { get; set; }
  }
}
