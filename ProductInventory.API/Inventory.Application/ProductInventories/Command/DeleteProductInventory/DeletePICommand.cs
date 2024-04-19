using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Inventory.Application.ProductInventories.Command.DeleteProductInventory
{
    public class DeletePICommand : IRequest <Guid>
    {
        public Guid Id { get; set; }
    }
}
