using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Inventory.Application.ProductInventories.Command.UpdateProductInventory
{
    public class UpdatePICommandValidator:AbstractValidator<UpdatePICommand>
    {
        public UpdatePICommandValidator() 
        { 
            RuleFor(updatePICommand=>
            updatePICommand.ProductId).NotEqual(Guid.Empty);
            RuleFor(updatePICommand =>
            updatePICommand.WarehouseId).NotEqual(null);
            RuleFor(updatePICommand =>
            updatePICommand.Quantity).NotEqual(null);
        }

    }
}
