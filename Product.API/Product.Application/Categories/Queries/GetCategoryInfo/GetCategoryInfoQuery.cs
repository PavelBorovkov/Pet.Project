using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Application.Categories.Queries.GetCategoryInfo
{
    public class GetCategoryInfoQuery: IRequest<CategoryInfoVm>
    {
        public Guid Id { get; set; }
    }
}
