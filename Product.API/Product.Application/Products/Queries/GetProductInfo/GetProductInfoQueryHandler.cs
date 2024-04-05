using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestTask.Application.Interfaces;
using TestTask.Application.Common.Exceptions;
using TestTask.Domain;

namespace TestTask.Application.Products.Queries.GetProductInfo
{
    public class GetProductInfoQueryHandler
        :IRequestHandler<GetProductInfoQuery,ProductInfoVm>
    {
        private readonly IMapper _mapper;
        private readonly ITestTaskDbContext _dbContext;
        public GetProductInfoQueryHandler(ITestTaskDbContext dbContext,IMapper mapper)
        { 
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ProductInfoVm> Handle(GetProductInfoQuery request,
            CancellationToken cancellationToken)
        {
            var entity=await _dbContext.Products
                .FirstOrDefaultAsync(product=>
                product.Id==request.Id,cancellationToken);
            if (entity==null||entity.Id!=request.Id)
            {
                throw new NotFoundException(nameof(Product),request.Id);
            }
            return _mapper.Map<ProductInfoVm>(entity);
        }
    }
}
