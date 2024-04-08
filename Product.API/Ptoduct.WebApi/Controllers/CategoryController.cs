using Microsoft.AspNetCore.Mvc;
using TestTask.Application.Categories.Queries.GetCategoryList;
using TestTask.Application.Categories.Queries.GetCategoryInfo;
using TestTask.Domain;
using TestTask.Application.Categories.Command.CreateCategory;
using TestTask.Application.Categories.Command.UpdateCategory;
using TestTask.Application.Categories.Command.DeleteCategory;
using AutoMapper;

namespace TestTask.WebApi.Controllers
{
    [Route("categories/[controller]/[action]")]
    public class CategoryController:BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryLookupDto>>> GetAllCategory(string? name)
        {
            var query = new GetCategoryListQuery
            {
                Name = name
            };
            var vm = await Mediator.Send(query);
            List<CategoryLookupDto> categories = new List<CategoryLookupDto>();
            foreach (var category in vm.Categories)
            {
                categories.Add(category);
            }
            return Ok(categories);
        }

        [HttpGet]
        public async Task<ActionResult<Category>> GetCategory(Guid id)
        {
            var query = new GetCategoryInfoQuery
            {
                Id = id
            };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory([FromForm] CreateCategoryCommand createCategoryCommand)
        {
            if (!string.IsNullOrEmpty(createCategoryCommand.Name))
            {
                var category = await Mediator.Send(createCategoryCommand);
                return Ok(category);
            }
            return BadRequest();

        }

        [HttpPut]
        public async Task<ActionResult<Category>> UpdateCategory([FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            if (!string.IsNullOrEmpty(updateCategoryCommand.Name))
            {
                var category = await Mediator.Send(updateCategoryCommand);
                return Ok(category);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var command = new DeleteCategoryCommand
            {
                Id = id
            };
            var categoryId = await Mediator.Send(command);
            return Ok(categoryId);
        }
    }
}
