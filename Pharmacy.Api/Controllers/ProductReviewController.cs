using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Pharmacy.Api.Dto;

namespace Pharmacy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductReviewController : ApiBaseController
    {
        public ProductReviewController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWork.ProductReviews.GetAllAsync());
        }

        [HttpPost("Add")]
        public IActionResult Add(ProductReviewDto dto)
        {
            try
            {
                var user = _unitOfWork.Users
                           .GetAll()
                           .FirstOrDefault(z => z.Email == dto.email);

                if (user == null)
                {
                    return NotFound($"User with email {dto.email} not found.");
                }

                ProductReview productReview = new ProductReview()
                {
                    ProductId = dto.ProductId,
                    UserId = user.UserId,
                    UserName = user.FirstName,
                    ContentReview = dto.ContentReview,
                };

                _unitOfWork.ProductReviews.Add(productReview);
                _unitOfWork.Save();

                return Ok("done");
            }
            catch (Exception ex)
            {
               
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the review. Please try again later.");
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var review = await _unitOfWork.ProductReviews.GetByIdAsync(id);
            if (review == null)
            {
                return NotFound($"Review with ID {id} not found.");
            }

            _unitOfWork.ProductReviews.Delete(review);
            _unitOfWork.Save();

            return Ok("Review deleted successfully.");
        }
    }
}
