using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Inventory.Application.Warehouses.Command.CreateWarehouse
{
    public class CreateWarehouseCommand:IRequest<int>
    {
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
    }
}
