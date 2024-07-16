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

        public CategoriaController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _repository.Create(request);

            if (response == null)
            {
                return StatusCode(500, "Não foi possível realizar a requisição.");
            }

            return CreatedAtAction(nameof(GetById), response);
        }

        [HttpGet("{categoryid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid categoryid)
        {
            var request = new GetCategoryByIdRequest { CategoryId = categoryid };
            var response = await _repository.GetCategoryById(request);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpDelete("{categoryid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid categoryid)
        {
            var request = new DeleteCategoryRequest { CategoryId = categoryid };
            var response = await _repository.Delete(request);

            if (response == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("{categoryid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid categoryid, [FromBody] UpdateCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            request.CategoryId = categoryid;
            var response = await _repository.Update(request);

            if (response == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
