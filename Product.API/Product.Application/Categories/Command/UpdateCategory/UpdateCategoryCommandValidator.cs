using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace TestTask.Application.Categories.Command.UpdateCategory
{
    public class UpdateCategoryCommandValidator:AbstractValidator<UpdateCategoryCommand>  
    {
        public UpdateCategoryCommandValidator() 
        {
            RuleFor(updateCategoryCommand=>
                updateCategoryCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateCategoryCommand =>
                updateCategoryCommand.Name).NotEqual(String.Empty);
        }
    }
}
