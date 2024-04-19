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

namespace Inventory.Application.Warehouses.Queries.GetWarehouseInfo
{
    public class GetWarehouseInfoQueryHandler
        :IRequestHandler<GetWarehouseInfoQuery, WarehouseInfoVm>    
    {
        private readonly IMapper _mapper;
        private readonly ITestDbContext _dbContext;
        public GetWarehouseInfoQueryHandler(IMapper mapper, ITestDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }   
        public async Task<WarehouseInfoVm>Handle(GetWarehouseInfoQuery request,
            CancellationToken cancellationToken)
        {
            var entity=await _dbContext.Warehouses
                .FirstOrDefaultAsync(warehouse=>
                warehouse.Id == request.Id, cancellationToken);
            if (entity == null||entity.Id!=request.Id)
            {
                throw new NotFoundException(nameof(Warehouse),request.Id);
            }
            return _mapper.Map<WarehouseInfoVm>(entity);
        }
    }
}
