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
            ProductReview productReview = new ProductReview()
            {
                ProductId = dto.ProductId,
                UserId = dto.UserId,
                Rating = dto.Rating,
                TitleReview = dto.TitleReview,
                ContentReview = dto.ContentReview
            };

            _unitOfWork.ProductReviews.Add(productReview);
            _unitOfWork.Save();
            return Ok(productReview);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var review = _unitOfWork.ProductReviews.GetById(id);
            _unitOfWork.ProductReviews.Delete(review);
            _unitOfWork.Save();
            return Ok(review);
        }
    }
}
