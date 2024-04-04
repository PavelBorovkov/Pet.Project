using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Interfaces;
using TestTask.Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace TestTask.Application.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQueryHandler
        : IRequestHandler<GetCategoryListQuery, CategoryListVm>
    {
        private readonly ITestTaskDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCategoryListQueryHandler(ITestTaskDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<CategoryListVm>Handle(GetCategoryListQuery request,
            CancellationToken cancellationToken)
        {
            var categoryQuery = _dbContext.Categories.ProjectTo<CategoryLookupDto>(_mapper.ConfigurationProvider);
            if (!string.IsNullOrEmpty(request.Name))
            {
                categoryQuery = categoryQuery.Where(p => p.Name.Contains(request.Name));
            }

            return new CategoryListVm { Categories = categoryQuery.ToList() };
        }
    }
}
