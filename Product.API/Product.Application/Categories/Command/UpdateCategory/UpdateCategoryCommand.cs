using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain;

namespace TestTask.Application.Categories.Command.UpdateCategory
{
    public class UpdateCategoryCommand:IRequest<Category>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; } = null!;
    }
}
