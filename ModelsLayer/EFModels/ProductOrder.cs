﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ModelsLayer.EFModels
{
    public partial class ProductOrder
    {
        public int ProductOrderId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
