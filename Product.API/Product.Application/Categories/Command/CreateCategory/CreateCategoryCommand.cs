using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Application.Categories.Command.CreateCategory
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        //Данный класс содержит в себе то , что необходимо для создания обьекта
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

    }
}
