using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Inventory.Application.Warehouses.Command.CreateWarehouse
{
    public class CreateWarehouseCommandValidator:AbstractValidator<CreateWarehouseCommand>
    {
        public CreateWarehouseCommandValidator() 
        {
            RuleFor(createWarehouseCommand=>
            createWarehouseCommand.Name).NotEqual(string.Empty);
            RuleFor(createWarehouseCommand=>
            createWarehouseCommand.Location).NotEqual(string.Empty);    
        }
    }
}
