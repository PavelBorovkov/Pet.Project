using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Inventory.Application.Common.Mappings;
using Inventory.Domain;

namespace Inventory.Application.ProductInventories.Queries.GetProductInventoryInfo
{
    public class PIInfoVm:IMapWith<ProductInventory>
    {
        public int WarehouseId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public void Mapping (Profile profile)
        {
            profile.CreateMap<ProductInventory, PIInfoVm>()
                .ForMember(PIVm => PIVm.WarehouseId,
                opt => opt.MapFrom(PI => PI.WarehouseId))
                .ForMember(PIVm => PIVm.ProductId,
                opt => opt.MapFrom(PI => PI.ProductId))
                .ForMember(PIVm => PIVm.Quantity,
                opt => opt.MapFrom(PI => PI.Quantity));
        }
    }
}
