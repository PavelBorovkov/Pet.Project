﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Inventory.Application.Warehouses.Command.DeleteWarehouse
{
    public class DeleteWarehouseCommand:IRequest<int>
    {
        public int Id { get; set; } 
    }
}
