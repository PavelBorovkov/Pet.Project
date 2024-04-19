using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Inventory.Application.Interfaces;

namespace Inventory.Application.ProductInventories.Queries.GetProductInventoryList
{
    public class GetPIListQueryHandler
        :IRequestHandler<GetPIListQuery, PIListVm>
    {
        private readonly ITestDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetPIListQueryHandler(ITestDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<PIListVm> Handle(GetPIListQuery request,
            CancellationToken cancellationToken)
        {
            var PIQuery = _dbContext.ProductInventories.ProjectTo<PILookupDto>(_mapper.ConfigurationProvider);
            if (request.WarehouseId != null)
            {
                PIQuery = PIQuery.Where(p => p.WarehouseId.Equals(request.WarehouseId));
            }
            if (request.ProductId!=null)
            {
                PIQuery=PIQuery.Where(p=>p.ProductId.Equals(request.ProductId));
            }
            return new PIListVm { ProductInventories = PIQuery.ToList() };
        }

    }
}
