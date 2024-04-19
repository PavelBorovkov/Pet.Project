using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Inventory.Application.ProductInventories.Command.CreateProductInventory
{
    public class CreatePICommand:IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
    }
}
