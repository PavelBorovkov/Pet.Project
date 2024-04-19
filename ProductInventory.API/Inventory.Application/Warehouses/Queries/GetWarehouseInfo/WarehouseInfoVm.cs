using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Inventory.Application.Common.Mappings;
using Inventory.Domain;

namespace Inventory.Application.Warehouses.Queries.GetWarehouseInfo
{
    public class WarehouseInfoVm:IMapWith<Warehouse>
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Warehouse, WarehouseInfoVm>()
                .ForMember(WarehouseVm => WarehouseVm.Name,
                    opt => opt.MapFrom(Warehouse => Warehouse.Name))
                .ForMember(WarehouseVm => WarehouseVm.Location,
                    opt => opt.MapFrom(Warehouse => Warehouse.Location));
        }
    }
}
