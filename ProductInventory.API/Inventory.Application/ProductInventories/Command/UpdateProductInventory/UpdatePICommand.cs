using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Inventory.Domain;

namespace Inventory.Application.ProductInventories.Command.UpdateProductInventory
{
    public class UpdatePICommand:IRequest<ProductInventory>
    {
        public Guid Id { get; set; }
        public int WarehouseId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
