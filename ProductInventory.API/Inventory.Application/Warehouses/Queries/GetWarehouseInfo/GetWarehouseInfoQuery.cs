using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Inventory.Application.Warehouses.Queries.GetWarehouseInfo
{
    public class GetWarehouseInfoQuery:IRequest<WarehouseInfoVm>
    {
        public int Id { get; set; }
    }
}
