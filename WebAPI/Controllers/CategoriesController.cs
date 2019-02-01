using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Category>>> Get()
        {
            var categories = await _categoryService.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Category>> Get(int id)
        {
            try
            {
                var category = await _categoryService.GetById(id);
                if (category == null)
                {
                    return NotFound("There is no category with id:" + id);
                }
                return Ok(category);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add([FromBody] Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Add(category);
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _categoryService.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Category categoryModel)
        {
            var category = await _categoryService.GetById(id);
            if (category != null)
            {
                await _categoryService.Update(categoryModel);
                return Ok();
            }

            return NotFound();
        }
    }
}
