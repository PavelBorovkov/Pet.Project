using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Inventory.Application.Interfaces;
using Inventory.Domain;
using Inventory.Application.Common.Execptions;

namespace Inventory.Application.ProductInventories.Command.DeleteProductInventory
{
    public class DeletePICommandHandler:
        IRequestHandler<DeletePICommand,Guid>
    {
        public readonly ITestDbContext _DbContext;
        public DeletePICommandHandler(ITestDbContext context) =>
            _DbContext = context;
        public async Task<Guid>Handle(DeletePICommand request,
            CancellationToken cancellationToken)
        {
            var entity=await _DbContext.ProductInventories
                .FindAsync(new object[] {request.Id},cancellationToken);
            if (entity == null||entity.Id!=request.Id)
            {
                throw new NotFoundException(nameof(ProductInventory),request.Id);
            }
            _DbContext.ProductInventories.Remove(entity);
            await _DbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
