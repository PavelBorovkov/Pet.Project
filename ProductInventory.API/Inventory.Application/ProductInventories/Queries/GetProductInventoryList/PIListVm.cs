﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.ProductInventories.Queries.GetProductInventoryList
{
    public class PIListVm
    {
        public IList<PILookupDto> ProductInventories { get; set; }
    }
}
