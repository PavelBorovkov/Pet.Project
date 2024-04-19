using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Inventory.Application.Warehouses.Queries.GetWarehouseList
{
    public class GetWarehouseListQuery:IRequest<WarehouseListVm>
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
    }
}
