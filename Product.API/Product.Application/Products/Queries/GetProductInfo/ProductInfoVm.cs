using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Common.Mappings;
using TestTask.Domain;

namespace TestTask.Application.Products.Queries.GetProductInfo
{
    public class ProductInfoVm:IMapWith<Product>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductInfoVm>()
                .ForMember(ProductVm => ProductVm.Name,
                    opt => opt.MapFrom(Product => Product.Name))
                .ForMember(ProductVm => ProductVm.Description,
                    opt => opt.MapFrom(Product => Product.Description))
                .ForMember(ProductVm => ProductVm.Price,
                    opt => opt.MapFrom(Product => Product.Price));

        }

    }
}
