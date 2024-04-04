using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain;

namespace TestTask.Application.Categories.Command.DeleteCategory
{
    public class DeleteCategoryCommand:IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
