using System;
using System.Collections.Generic;

namespace Inventory.Domain
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            ProductInventories = new HashSet<ProductInventory>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;

        public virtual ICollection<ProductInventory> ProductInventories { get; set; }
    }
}
