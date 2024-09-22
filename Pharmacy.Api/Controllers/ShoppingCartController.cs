using Dto;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Models;
using System.Drawing.Printing;

namespace Pharmacy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ApiBaseController
    {
        public ShoppingCartController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        //Read All
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _unitOfWork.ShoppingCarts.GetAllAsync());
        }

        //Create
        [HttpPost("Add")]
        public IActionResult Add(ShoppingCartDto dto) {
            ShoppingCart cart = new ShoppingCart()
            {
                UserId = dto.UserId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
            };
            _unitOfWork.ShoppingCarts.Add(cart);
            _unitOfWork.Save();
            return Ok("Done");
        }

        //Edit or Update By id
        [HttpPut("UpdateById")]
        public IActionResult Update(int id, ShoppingCartDto dto)
        {
            var cart = _unitOfWork.ShoppingCarts.GetById(id);
            cart.ProductId = dto.ProductId;
            cart.Quantity = dto.Quantity;
            _unitOfWork.ShoppingCarts.Update(cart);
            _unitOfWork.Save();
            return Ok(cart);
        }
        //Delete by id
        [HttpDelete("DeleteById")]
        public IActionResult Delete(int id) {
            var cart = _unitOfWork.ShoppingCarts.GetById(id);
            _unitOfWork.ShoppingCarts.Delete(cart);
            _unitOfWork.Save();
            return Ok("Deleted");
        }
    }
}
