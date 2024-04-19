using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Inventory.Application.Interfaces;
using Inventory.Application.Common.Execptions;
using Inventory.Domain;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Application.ProductInventories.Queries.GetProductInventoryInfo
{
    public class GetPIInfoQueryHandler:
        IRequestHandler<GetPIInfoQuery,PIInfoVm>
    {
        private readonly IMapper _mapper;
        private readonly ITestDbContext _dbContext;
        public GetPIInfoQueryHandler(IMapper mapper, ITestDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<PIInfoVm> Handle(GetPIInfoQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.ProductInventories
                .FirstOrDefaultAsync(PI => PI.Id == request.Id, cancellationToken);
            if (entity == null||entity.Id!=request.Id)
            {
                throw new NotFoundException(nameof(ProductInventory), request.Id);
            }
            return _mapper.Map<PIInfoVm>(entity);
        }
    }
}
