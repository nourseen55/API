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
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _prorepo;
        public ProductController(IProductRepository proRepository)
        {
            _prorepo = proRepository;
            
        }
        [HttpGet]
        public IActionResult Getpro()
        {
            var emps=_prorepo.GetAll();
            return Ok(emps);

        }
        [HttpGet("product/{id:int}", Name = "GetProductById")]
        public IActionResult GetById(int id)
        {
            var emp = _prorepo.GetById(id);
            return Ok(emp);

        }
        [HttpPost]
        [Authorize(Roles = "Admin")]

        public IActionResult Add(ProductDto pro)
        {
            if (ModelState.IsValid)
            {
                _prorepo.Add(pro);
                var link = Url.Link("GetProductById", new { id = pro.Id });
                return Created(link, pro);
            }
            return BadRequest();
            
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]

        public IActionResult Update(int id,ProductDto pro)
        {
            _prorepo.Update(id, pro);
            return StatusCode(402);

        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]

        public IActionResult DeleteById(int id)
        {
            _prorepo.DeleteById(id);
            return StatusCode(204);
        }
        [HttpPost("search")]

        public IActionResult search(SearchDto productDto)
        {
            var pros=_prorepo.GetAll();
            if (!string.IsNullOrEmpty(productDto.keyword))
            {
                pros = pros.Where(x => x.Name.Contains(productDto.keyword, StringComparison.OrdinalIgnoreCase)
                                    || x.Description.Contains(productDto.keyword, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(productDto.category))
            {
                pros = pros.Where(x => x.Category.Name.Equals(productDto.category));

                
            }
            if (productDto.maxprice>0)
            {
                pros = pros.Where(x => x.Price < productDto.maxprice);
                
            }
            if (productDto.minprice > 0)
            {
                pros = pros.Where(x => x.Price > productDto.minprice);

            }
            return Ok(pros);
        }

    }
}
