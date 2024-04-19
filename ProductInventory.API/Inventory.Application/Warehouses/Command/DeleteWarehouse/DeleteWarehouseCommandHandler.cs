using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Inventory.Application.Interfaces;
using Inventory.Domain;
using Inventory.Application.Common.Execptions;

namespace Inventory.Application.Warehouses.Command.DeleteWarehouse
{
    public class DeleteWarehouseCommandHandler :
        IRequestHandler<DeleteWarehouseCommand, int>
    {
        public readonly ITestDbContext _DbContext;
        public DeleteWarehouseCommandHandler(ITestDbContext context) =>
            _DbContext = context;
        public async Task<int> Handle(DeleteWarehouseCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _DbContext.Warehouses
                .FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Warehouse), request.Id);
            }
            _DbContext.Warehouses.Remove(entity);
            await _DbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
