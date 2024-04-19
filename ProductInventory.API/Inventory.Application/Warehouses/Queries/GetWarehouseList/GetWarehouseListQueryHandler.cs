using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Inventory.Application.Interfaces;

namespace Inventory.Application.Warehouses.Queries.GetWarehouseList
{
    public class GetWarehouseListQueryHandler
        :IRequestHandler<GetWarehouseListQuery,WarehouseListVm>
    {
        private readonly IMapper _mapper;
        private readonly ITestDbContext _DbContext;
        public GetWarehouseListQueryHandler(IMapper mapper, ITestDbContext dbContext)
        {
            _mapper = mapper;
            _DbContext = dbContext;
        }
        public async Task<WarehouseListVm>Handle(GetWarehouseListQuery request,
            CancellationToken cancellationToken)
        {
            var warehouseQuery = _DbContext.Warehouses.ProjectTo<WarehouseLookupDto>(_mapper.ConfigurationProvider);
            if (!string.IsNullOrEmpty(request.Location))
            {
                warehouseQuery = warehouseQuery.Where(p => p.Location.Contains(request.Location));
            }
            if (!string.IsNullOrEmpty(request.Name))
            {
                warehouseQuery=warehouseQuery.Where(p=>p.Name.Contains(request.Name));
            }
            return new WarehouseListVm { Warehouses = warehouseQuery.ToList() };
        }
    }
}
