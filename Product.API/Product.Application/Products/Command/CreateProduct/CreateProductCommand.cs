using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TestTask.Application.Products.Command.CreateProduct
{
    public class CreateProductCommand:IRequest<Guid>
    {
        public Guid CategoryID { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; } 
        public decimal Price { get; set; }
    }
}
