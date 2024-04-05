﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace TestTask.Application.Products.Command.UpdateProduct
{
    public class UpdateProductCommandValidator:AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator() 
        {
            RuleFor(updateProductCommand=>
            updateProductCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateProductCommand=>
            updateProductCommand.Name).NotEqual(string.Empty);
            RuleFor(updateProductCommand=>
            updateProductCommand.CategoryID).NotEqual(Guid.Empty);
            RuleFor(updateProductCommand =>
            updateProductCommand.Price).NotEqual(decimal.Zero);
        }
    }
}
