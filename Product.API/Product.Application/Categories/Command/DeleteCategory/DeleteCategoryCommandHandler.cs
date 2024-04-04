using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Interfaces;
using TestTask.Domain;
using TestTask.Application.Common.Exceptions;

namespace TestTask.Application.Categories.Command.DeleteCategory
{
    public class DeleteCategoryCommandHandler
        :IRequestHandler<DeleteCategoryCommand,Guid>
    {
        public readonly ITestTaskDbContext _dbContext;
        public DeleteCategoryCommandHandler(ITestTaskDbContext dbContext) => _dbContext = dbContext;
        
        //Unit-тип означающий пустой ответ
        public async Task<Guid> Handle(DeleteCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Categories
                .FindAsync(new object[] { request.Id }, cancellationToken);
            
            if (entity == null||entity.Id!=request.Id) 
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }
            _dbContext.Categories.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return entity.Id;
        }
    }
}
