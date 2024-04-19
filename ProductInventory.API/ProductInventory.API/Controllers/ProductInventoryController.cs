using Microsoft.AspNetCore.Mvc;
using Inventory.Domain;
using AutoMapper;
using Inventory.Application.ProductInventories.Command.CreateProductInventory;
using Inventory.Application.ProductInventories.Command.DeleteProductInventory;
using Inventory.Application.ProductInventories.Command.UpdateProductInventory;
using Inventory.Application.ProductInventories.Queries.GetProductInventoryInfo;
using Inventory.Application.ProductInventories.Queries.GetProductInventoryList;
using System.Xml.Linq;

namespace ProductInventory.API.Controllers
{
    [Route("productInventories/[controller]/[action]")]
    public class ProductInventoryController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PILookupDto>>> GetAllCategory(Guid? warehouseId, Guid? productId)
        {
            var query = new GetPIListQuery
            {
                WarehouseId = warehouseId,
                ProductId = productId
            };
            var vm = await Mediator.Send(query);
            List<PILookupDto> productInventories = new List<PILookupDto>();
            foreach (var productInventory in vm.ProductInventories)
            {
                productInventories.Add(productInventory);
            }
            return Ok(productInventories);
        }

        //[HttpGet]
        //public async Task<ActionResult<Category>> GetCategory(Guid id)
        //{
        //    var query = new GetCategoryInfoQuery
        //    {
        //        Id = id
        //    };
        //    var result = await Mediator.Send(query);
        //    return Ok(result);
        //}

        [HttpPost]
        public async Task<ActionResult<Inventory.Domain.ProductInventory>> CreatePI([FromForm] CreatePICommand createPICommand)
        {
            if (!createPICommand.WarehouseId.Equals(null)&&!createPICommand.ProductId.Equals(null)&&!createPICommand.Quantity.Equals(null))
            {
                var productInventory = await Mediator.Send(createPICommand);
                return Ok(productInventory);
            }
            return BadRequest();

        }

        [HttpPut]
        public async Task<ActionResult<Inventory.Domain.ProductInventory>> UpdatePI([FromBody] UpdatePICommand updatePICommand)
        {
            if (!updatePICommand.WarehouseId.Equals(null) && !updatePICommand.ProductId.Equals(null) && !updatePICommand.Quantity.Equals(null))
            {
                var productInventory = await Mediator.Send(updatePICommand);
                return Ok(productInventory);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductInventory(Guid id)
        {
            var command = new DeletePICommand
            {
                Id = id
            };
            var PIId = await Mediator.Send(command);
            return Ok(PIId);
        }
    }
}
