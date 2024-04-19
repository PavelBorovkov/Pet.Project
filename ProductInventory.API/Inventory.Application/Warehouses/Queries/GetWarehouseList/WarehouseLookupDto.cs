using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Inventory.Domain;
using Inventory.Application.Common.Mappings; 

namespace Inventory.Application.Warehouses.Queries.GetWarehouseList
{
    public class WarehouseLookupDto:IMapWith<Warehouse>
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Warehouse, WarehouseLookupDto>()
                .ForMember(warehouseDto => warehouseDto.Name,
                opt => opt.MapFrom(warehouse => warehouse.Name))
                .ForMember(warehouseDto => warehouseDto.Location,
                opt => opt.MapFrom(warehouse => warehouse.Location));
        }
    }
}
