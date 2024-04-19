using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Inventory.Domain;
using Inventory.Application.Common.Mappings;

namespace Inventory.Application.ProductInventories.Queries.GetProductInventoryList
{
    public class PILookupDto: IMapWith<ProductInventory>
    {
        public int WarehouseId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public void Mapping (Profile profile)
        {
            profile.CreateMap<ProductInventory,PILookupDto> ()
                .ForMember(PIDto => PIDto.WarehouseId,
                opt => opt.MapFrom(PI => PI.WarehouseId))
                .ForMember(PIDto => PIDto.ProductId,
                opt => opt.MapFrom(PI => PI.ProductId))
                .ForMember(PIDto => PIDto.Quantity,
                opt => opt.MapFrom(PI => PI.Quantity));

        }
    }
}
