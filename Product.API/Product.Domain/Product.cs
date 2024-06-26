﻿using System;
using System.Collections.Generic;

namespace TestTask.Domain
{
    public partial class Product
    {
        public Guid Id { get; set; }
        public Guid CategoryID { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; } 

        public virtual Category Category { get; set; } = null!;
    }
}
