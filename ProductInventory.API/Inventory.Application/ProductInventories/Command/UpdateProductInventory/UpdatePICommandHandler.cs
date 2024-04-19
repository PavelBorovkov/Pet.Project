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

namespace Inventory.Application.ProductInventories.Command.UpdateProductInventory
{
    public class UpdatePICommandHandler:IRequestHandler<UpdatePICommand, ProductInventory>
    {
        private readonly ITestDbContext _DbContext;
        public UpdatePICommandHandler(ITestDbContext dbContext)=>
            _DbContext = dbContext;
        public async Task<ProductInventory> Handle(UpdatePICommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _DbContext.ProductInventories.FirstOrDefaultAsync(
                ProductInventory => ProductInventory.Id == request.Id, cancellationToken);
            if (entity == null||entity.Id!=request.Id)
            {
                throw new NotFoundException(nameof(ProductInventory), request.Id);
            }
            entity.ProductId = request.ProductId;
            entity.WarehouseId = request.WarehouseId;
            entity.Quantity = request.Quantity;

            await _DbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
