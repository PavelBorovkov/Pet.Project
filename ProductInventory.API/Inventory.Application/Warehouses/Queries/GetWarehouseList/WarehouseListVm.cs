﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Warehouses.Queries.GetWarehouseList
{
    public class WarehouseListVm
    {
        public IList<WarehouseLookupDto> Warehouses { get; set; }
    }
}
