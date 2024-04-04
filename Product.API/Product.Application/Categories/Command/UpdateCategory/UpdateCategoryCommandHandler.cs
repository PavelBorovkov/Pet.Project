using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using TestTask.Application.Common.Exceptions;
using TestTask.Domain;

namespace TestTask.Application.Categories.Command.UpdateCategory
{
    public class UpdateCategoryCommandHandler
        :IRequestHandler<UpdateCategoryCommand, Category>
    {
        private readonly ITestTaskDbContext _dbContext;

        public UpdateCategoryCommandHandler(ITestTaskDbContext dbContext)=>
            _dbContext = dbContext;
        public async Task<Category> Handle(UpdateCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var entity=
                await _dbContext.Categories.FirstOrDefaultAsync(Category=>
                    Category.Id==request.Id, cancellationToken);
            if (entity == null|| entity.Id!=request.Id)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }

            entity.Name = request.Name;
            entity.Description = request.Description;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
