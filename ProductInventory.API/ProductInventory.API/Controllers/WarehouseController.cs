using Microsoft.AspNetCore.Mvc;
using Inventory.Domain;
using AutoMapper;
using Inventory.Application.Warehouses.Command.CreateWarehouse;
using Inventory.Application.Warehouses.Command.DeleteWarehouse;
using Inventory.Application.Warehouses.Command.UpdateWarehouse;
using Inventory.Application.Warehouses.Queries.GetWarehouseInfo;
using Inventory.Application.Warehouses.Queries.GetWarehouseList;
using System.Xml.Linq;


namespace ProductInventory.API.Controllers
{

    [Route("warehouses/[controller]/[action]")]
    public class WarehouseController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarehouseLookupDto>>> GetAllWarehouse(string? name, string? location)
        {
            var query = new GetWarehouseListQuery
            {
                Name = name,
                Location = location
            };
            var vm = await Mediator.Send(query);
            List<WarehouseLookupDto> warehouses = new List<WarehouseLookupDto>();
            foreach (var warehouse in vm.Warehouses)
            {
                warehouses.Add(warehouse);
            }
            return Ok(warehouses);
        }

        [HttpGet]
        public async Task<ActionResult<Warehouse>> GetWarehouse(int id)
        {
            var query = new GetWarehouseInfoQuery
            {
                Id = id
            };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Warehouse>> CreateWarehouse([FromForm] CreateWarehouseCommand createWarehouseCommand)
        {
            if (!string.IsNullOrEmpty(createWarehouseCommand.Name)&& !string.IsNullOrEmpty(createWarehouseCommand.Location))
            {
                var warehouse = await Mediator.Send(createWarehouseCommand);
                return Ok(warehouse);
            }
            return BadRequest();

        }

        [HttpPut]
        public async Task<ActionResult<Warehouse>> UpdateWarehouse([FromBody] UpdateWarehouseCommand updateWarehouseCommand)
        {
            if (!string.IsNullOrEmpty(updateWarehouseCommand.Name)&& !string.IsNullOrEmpty(updateWarehouseCommand.Location))
            {
                var warehouse = await Mediator.Send(updateWarehouseCommand);
                return Ok(warehouse);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWarehouse(int id)
        {
            var command = new DeleteWarehouseCommand
            {
                Id = id
            };
            var WarehouseId = await Mediator.Send(command);
            return Ok(WarehouseId);
        }
    }
}
