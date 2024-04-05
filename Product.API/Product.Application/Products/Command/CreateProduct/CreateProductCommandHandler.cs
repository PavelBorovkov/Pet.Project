using MediatR;
using TestTask.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain;

namespace TestTask.Application.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler:
        IRequestHandler<CreateProductCommand,Guid>
    {
        private readonly ITestTaskDbContext _DbContext;
        public CreateProductCommandHandler(ITestTaskDbContext dbContext) =>
            _DbContext = dbContext;
        public async Task<Guid> Handle(CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = new Product
            {
                CategoryID = request.CategoryID,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Id = Guid.NewGuid()
            };
            await _DbContext.Products.AddAsync(product,cancellationToken);
            await _DbContext.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
