using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace TestTask.Application.Products.Command.CreateProduct
{
    public class CreateProductCommandValidator:AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator() 
        {
            RuleFor(createProductCommand =>
            createProductCommand.Name).NotEqual(string.Empty);
            RuleFor(createProductCommand=>
            createProductCommand.CategoryID).NotEqual(Guid.Empty);
            RuleFor(updateProductCommand =>
            updateProductCommand.Price).NotEqual(decimal.Zero);
        }
    }
}
