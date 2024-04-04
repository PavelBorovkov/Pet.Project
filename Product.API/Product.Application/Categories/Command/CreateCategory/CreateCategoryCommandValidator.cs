using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace TestTask.Application.Categories.Command.CreateCategory
{
    public class CreateCategoryCommandValidator:AbstractValidator<CreateCategoryCommand>  
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(createCategoryCommand =>
            createCategoryCommand.Name).NotEqual(string.Empty);
        }
    }
}
