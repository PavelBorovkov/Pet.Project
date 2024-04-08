using Microsoft.AspNetCore.Mvc;
using TestTask.Domain;
using AutoMapper;
using TestTask.Application.Products.Command.CreateProduct;
using TestTask.Application.Products.Command.DeleteProduct;
using TestTask.Application.Products.Command.UpdateProduct;
using TestTask.Application.Products.Queries.GetProductInfo;
using TestTask.Application.Products.Queries.GetProductList;

namespace TestTask.WebApi.Controllers
{
    [Route("products/[controller]/[action]")]
    public class ProductController:BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductLookupDto>>>GetAllProduct(string? name, Guid? categoryId)
        {
            var query = new GetProductListQuery
            {
                Name = name,
                CategoryID = categoryId
            };
            var vm=await Mediator.Send(query);
            List<ProductLookupDto> products = new List<ProductLookupDto>();
            foreach(var product in vm.Products)
            {
                products.Add(product);
            }
            return Ok(products);
        }
        [HttpGet]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            var query = new GetProductInfoQuery
            {
                Id = id
            };
            var result=await Mediator.Send(query);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromForm]CreateProductCommand createProductCommand)
        {
            if(string.IsNullOrEmpty(createProductCommand.Name))
            {
                return BadRequest(createProductCommand.Name);
            }
            else if(createProductCommand.CategoryID.Equals(Guid.Empty))
            {
                return BadRequest(createProductCommand.CategoryID);
            }
            else if(createProductCommand.Price.Equals(decimal.Zero))
            {
                return BadRequest(createProductCommand.Price);
            }
            else
            {
                var product=await Mediator.Send(createProductCommand);
                return Ok(product);
            }
        }
        [HttpPut]
        public async Task<ActionResult<Product>> UpdateProduct([FromBody]UpdateProductCommand updateProductCommand)
        {
            if (string.IsNullOrEmpty(updateProductCommand.Name))
            {
                return BadRequest(updateProductCommand.Name);
            }
            else if (updateProductCommand.CategoryID.Equals(Guid.Empty))
            {
                return BadRequest(updateProductCommand.CategoryID);
            }
            else if (updateProductCommand.Price.Equals(decimal.Zero))
            {
                return BadRequest(updateProductCommand.Price);
            }
            else
            {
                var product =await Mediator.Send(updateProductCommand);
                return Ok(product);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var command = new DeleteProductCommand
            {
                Id = id
            };
            var productId= await Mediator.Send(command);
            return Ok(productId);   
        }

    }
}
