using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Inventory.Application.ProductInventories.Command.CreateProductInventory
{
    public class CreatePICommandValidator:AbstractValidator<CreatePICommand>
    {
        public CreatePICommandValidator() 
        {
            RuleFor(createPICommand =>
            createPICommand.ProductId).NotEqual(Guid.Empty);
            RuleFor(createPICommand=>
            createPICommand.WarehouseId).NotEqual(null);
            RuleFor(createPICommand=>
            createPICommand.Quantity).NotEqual(null);
        }
    }
}
