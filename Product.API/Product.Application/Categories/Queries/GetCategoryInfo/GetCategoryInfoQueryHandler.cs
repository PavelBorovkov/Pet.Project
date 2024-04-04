using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestTask.Application.Interfaces;
using TestTask.Application.Common.Exceptions;
using TestTask.Domain;

namespace TestTask.Application.Categories.Queries.GetCategoryInfo
{
    public class GetCategoryInfoQueryHandler
        :IRequestHandler<GetCategoryInfoQuery, CategoryInfoVm>
    {
        private readonly ITestTaskDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCategoryInfoQueryHandler(ITestTaskDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CategoryInfoVm> Handle(GetCategoryInfoQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Categories
                .FirstOrDefaultAsync(category =>
                category.Id == request.Id, cancellationToken);
            
            if (entity == null||entity.Id!=request.Id)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }
            return _mapper.Map<CategoryInfoVm>(entity);
        }
    }
}
