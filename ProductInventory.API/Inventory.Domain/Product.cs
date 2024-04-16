using System;
using System.Collections.Generic;

namespace Inventory.Domain
{
    public partial class Product
    {
        public Product()
        {
            ProductInventories = new HashSet<ProductInventory>();
        }

        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<ProductInventory> ProductInventories { get; set; }
    }
}
