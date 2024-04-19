using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace Inventory.Application.Warehouses.Command.UpdateWarehouse
{
    public class UpdateWarehouseCommandValidator:AbstractValidator<UpdateWarehouseCommand>
    {
        public UpdateWarehouseCommandValidator() 
        {
            RuleFor(updateWarehouseCommand=>
            updateWarehouseCommand.Name).NotEqual(string.Empty);
            RuleFor(updateWarehouseCommand =>
            updateWarehouseCommand.Location).NotEqual(string.Empty);
        }
    }
}
