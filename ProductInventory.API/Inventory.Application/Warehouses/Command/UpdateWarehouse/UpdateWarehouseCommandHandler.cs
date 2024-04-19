using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Inventory.Domain;
using Inventory.Application.Interfaces;
using Inventory.Application.Common.Execptions;

namespace Inventory.Application.Warehouses.Command.UpdateWarehouse
{
    public class UpdateWarehouseCommandHandler:
        IRequestHandler<UpdateWarehouseCommand,Warehouse>
    {
        private readonly ITestDbContext _DbContext;
        public UpdateWarehouseCommandHandler(ITestDbContext dbContext)=>
            _DbContext = dbContext;
        public async Task<Warehouse>Handle(UpdateWarehouseCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _DbContext.Warehouses.FirstOrDefaultAsync(
                Warehouse => Warehouse.Id == request.Id, cancellationToken);
            if (entity == null||entity.Id!=request.Id)
            {
                throw new NotFoundException(nameof(Warehouse), request.Id);
            }
            entity.Name = request.Name;
            entity.Location = request.Location;

            await _DbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
