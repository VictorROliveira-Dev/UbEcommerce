using Microsoft.AspNetCore.Mvc;
using UbEcommerce.API.Application.Requests.Category;
using UbEcommerce.API.Domain.Repositories;

namespace UbEcommerce.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoryRepository _repository;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateCategoryRequest request)
        {
            var response = await _repository.Create(request);
            return Ok(response);
        }

        [HttpGet("{categoryid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid categoryid)
        {
            var request = new GetCategoryByIdRequest { CategoryId = categoryid };
            var response = await _repository.GetCategoryById(request);

            return Ok(response);
        }

        [HttpDelete("{categoryid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid categoryid)
        {
            var request = new DeleteCategoryRequest { CategoryId = categoryid };
            var response = await _repository.Delete(request);

            return Ok(response);
        }

        [HttpPut("{categoryid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid categoryid, [FromBody] UpdateCategoryRequest request)
        {
            request.CategoryId = categoryid;
            var response = await _repository.Update(request);

            return Ok(response);
        }
    }
}
