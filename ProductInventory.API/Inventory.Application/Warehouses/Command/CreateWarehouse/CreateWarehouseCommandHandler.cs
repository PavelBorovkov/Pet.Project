using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Application.Interfaces;
using Inventory.Domain;
using MediatR;

namespace Inventory.Application.Warehouses.Command.CreateWarehouse
{
    public class CreateWarehouseCommandHandler:
        IRequestHandler<CreateWarehouseCommand,int>
    {
        private readonly ITestDbContext _DbContext;
        public CreateWarehouseCommandHandler(ITestDbContext dbContext)=>
            _DbContext = dbContext;
        public async Task<int> Handle(CreateWarehouseCommand request,
            CancellationToken cancellationToken)
        {
            var warehouse = new Warehouse
            {
                Name = request.Name,
                Location = request.Location,
            };
            await _DbContext.Warehouses.AddAsync(warehouse, cancellationToken);
            await _DbContext.SaveChangesAsync(cancellationToken);
        
            return warehouse.Id;
        }
        
    }
}
