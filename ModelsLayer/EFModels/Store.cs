using System;
using System.Collections.Generic;

#nullable disable

namespace ModelsLayer.EFModels
{
  public partial class Store
  {
    public Store()
    {
      Products = new HashSet<Product>();
    }

    public int StoreId { get; set; }
    public string Name { get; set; }

    public string Picture { get; set; }

    public virtual ICollection<Product> Products { get; set; }
  }
}
