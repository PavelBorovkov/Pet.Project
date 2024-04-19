using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Inventory.Application.ProductInventories.Queries.GetProductInventoryInfo
{
    public class GetPIInfoQuery:IRequest<PIInfoVm>
    {
        public Guid Id { get; set; }
    }
}
