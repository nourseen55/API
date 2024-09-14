using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.IReository;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _catrepo;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _catrepo = categoryRepository;
        }


        [HttpGet]
        public IActionResult Getcat()
        {
            var emps = _catrepo.GetAll();
            return Ok(emps);

        }
        [HttpGet("category/{id:int}", Name = "GetCategoryById")]
        public IActionResult GetById(int id)
        {
            var emp = _catrepo.GetById(id);
            return Ok(emp);

        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public IActionResult Add(Category cat)
        {
            if (ModelState.IsValid)
            {
                _catrepo.Add(cat);
                var link = Url.Link("GetCategoryById", new { id = cat.Id });
                return Created(link, cat);
            }
            return BadRequest();

        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id:int}")]
        public IActionResult Update(int id,CategoryDto cat)
        {
            _catrepo.Update(id, cat);
            return StatusCode(402);

        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]

        public IActionResult DeleteById(int id)
        {
            _catrepo.DeleteById(id);
            return StatusCode(204);
        }
     

    }
}
