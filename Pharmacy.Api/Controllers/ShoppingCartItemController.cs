using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Models;
using Pharmacy.Api.Dto;

namespace Pharmacy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartItemController : ApiBaseController
    {
        public ShoppingCartItemController (IUnitOfWork unitOfWork):base(unitOfWork) { }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _unitOfWork.ShoppingCartItems.GetAllAsync());
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _unitOfWork.ShoppingCartItems.GetByIdAsync(id));
        }

        [HttpPost("Add")]
        public IActionResult Add(ShoppingCartItemDto cartitemdto)
        {
            ShoppingCartItem shoppingCart = new ShoppingCartItem()
            {
                CartId = cartitemdto.CartId,
                ProductId = cartitemdto.ProductId,
                Quantity = cartitemdto.Quantity,
                UnitPrice = cartitemdto.UnitPrice,
                LineTotal = cartitemdto.LineTotal,
            };
            _unitOfWork.ShoppingCartItems.Add(shoppingCart);
            _unitOfWork.Save();
            return Ok(shoppingCart);
        }

        [HttpDelete("DeleteById")]
        public IActionResult Delete(int id) { 
            var cart = _unitOfWork.ShoppingCartItems.GetById(id);
            _unitOfWork.ShoppingCartItems.Delete(cart);
            _unitOfWork.Save();
            return Ok(cart);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, [FromBody]ShoppingCartItemDto cartitemdto)
        {
            var model = _unitOfWork.ShoppingCartItems.GetById(id);
            model.Quantity = cartitemdto.Quantity;

            _unitOfWork.ShoppingCartItems.Update(model);
            _unitOfWork.Save();
            return Ok(model);
        }

        

    }
}
