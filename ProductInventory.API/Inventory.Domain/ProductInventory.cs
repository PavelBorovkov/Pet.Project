using System;
using System.Collections.Generic;

namespace Inventory.Domain
{
    public partial class ProductInventory
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Warehouse Warehouse { get; set; } = null!;
    }
}
