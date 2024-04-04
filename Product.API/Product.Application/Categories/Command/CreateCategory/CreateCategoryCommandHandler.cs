using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TestTask.Domain;
using TestTask.Application.Interfaces;

namespace TestTask.Application.Categories.Command.CreateCategory
{
    //Данный класс содержит логику создания
    public class CreateCategoryCommandHandler
        :IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly ITestTaskDbContext _dbContext;
        public CreateCategoryCommandHandler(ITestTaskDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.Name,
                Description = request.Description,
                Id = Guid.NewGuid()
            };

            await _dbContext.Categories.AddAsync(category, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return category.Id;
        }
    }
}
