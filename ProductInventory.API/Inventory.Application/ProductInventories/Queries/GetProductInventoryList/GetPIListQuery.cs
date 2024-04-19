using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Inventory.Application.ProductInventories.Queries.GetProductInventoryList
{
    public class GetPIListQuery:IRequest<PIListVm>
    {
        public Guid? ProductId { get; set; }
        public Guid? WarehouseId { get; set; }
    }
}
