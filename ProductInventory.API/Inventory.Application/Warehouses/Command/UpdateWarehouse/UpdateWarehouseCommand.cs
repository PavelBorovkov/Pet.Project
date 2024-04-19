using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Inventory.Domain;

namespace Inventory.Application.Warehouses.Command.UpdateWarehouse
{
    public class UpdateWarehouseCommand:IRequest<Warehouse>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
    }
}
