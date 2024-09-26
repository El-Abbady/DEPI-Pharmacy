using Dto;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Pharmacy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ApiBaseController
    {
        public ShoppingCartController(IUnitOfWork unitOfWork): base(unitOfWork) { }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id )
        {
            return Ok(await _unitOfWork.ShoppingCarts.GetByIdAsync(id));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(ShoppingCartDto cartDto)
        {
            ShoppingCart shoppingCart = new ShoppingCart()
            {
                UserId = cartDto.UserId,
            };
            _unitOfWork.ShoppingCarts.Add(shoppingCart);
            _unitOfWork.Save();
            return Ok(shoppingCart);
        }

        [HttpDelete("DeleteById")]
        public IActionResult Delete(int id) { 
            var cart = _unitOfWork.ShoppingCarts.GetById(id);
            _unitOfWork.ShoppingCarts.Delete(cart);
            _unitOfWork.Save();
            return Ok(cart);
        }
    }
}
