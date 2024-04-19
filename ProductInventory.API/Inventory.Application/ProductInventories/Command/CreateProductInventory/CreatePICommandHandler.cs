using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Inventory.Domain;
using Inventory.Application.Interfaces;

namespace Inventory.Application.ProductInventories.Command.CreateProductInventory
{
    public class CreatePICommandHandler:
        IRequestHandler<CreatePICommand,Guid>
    {
        private readonly ITestDbContext _DbContext;
        public CreatePICommandHandler(ITestDbContext context)=>
            _DbContext = context;
        public async Task<Guid> Handle(CreatePICommand request,
            CancellationToken cancellationToken)
        {
            var PI = new ProductInventory
            {
                Id = Guid.NewGuid(),
                ProductId = request.ProductId,
                WarehouseId = request.WarehouseId,
                Quantity = request.Quantity,
            };
            await _DbContext.ProductInventories.AddAsync(PI,cancellationToken);
            await _DbContext.SaveChangesAsync(cancellationToken);
            return PI.Id;
        }
    }
}
