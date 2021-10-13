using System;
using System.Collections.Generic;

#nullable disable

namespace ModelsLayer.EFModels
{
    public partial class Product
    {
        public Product()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StoreId { get; set; }
        public string Picture { get; set; }

        public virtual Store Store { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
