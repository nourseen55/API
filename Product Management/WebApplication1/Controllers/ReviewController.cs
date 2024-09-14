using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.IReository;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewrepo;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public ReviewController(IReviewRepository revRepository, UserManager<ApplicationUser> userManager, IHttpContextAccessor _contextAccessor)
        {
            _reviewrepo = revRepository;
            this.userManager = userManager;
            this._contextAccessor = _contextAccessor;

        }
        [HttpGet]
        public IActionResult Get()
        {
            var emps = _reviewrepo.GetAll();
            return Ok(emps);

        }
        [HttpGet("review/{id:int}", Name = "GetReviewById")]
        public IActionResult GetById(int id)
        {
            var emp = _reviewrepo.GetById(id);
            return Ok(emp);

        }

        [HttpPost]
        public async Task<IActionResult> Add(ReviewDto Dtoreview)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.GetUserAsync(_contextAccessor.HttpContext.User);

                Review review = new Review();
                review.UserId = user.Id;
                review.Comment = Dtoreview.Comment;
                review.CreatedAt = DateTime.Now;
                review.ProductId = Dtoreview.ProductId;
                review.Rating = Dtoreview.Rating;

                _reviewrepo.Add(review);
                var link = Url.Link("GetReviewById", new { id = review.Id });
                return Created(link, review);
            }
            return BadRequest();

        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id,ReviewDto Dtoreview)
        {
            ApplicationUser user = await userManager.GetUserAsync(_contextAccessor.HttpContext.User);
            var review= _reviewrepo.GetById(id);
            review.Comment = Dtoreview.Comment;
            review.Rating = Dtoreview.Rating;
            review.CreatedAt = DateTime.Now;
            review.UserId = user.Id;
            review.ProductId = Dtoreview.ProductId;
            _reviewrepo.Update(review);
            return StatusCode(402);

        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _reviewrepo.DeleteById(id);
            return StatusCode(204);
        }


    }
}
