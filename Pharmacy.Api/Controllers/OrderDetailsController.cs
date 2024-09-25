using Dto;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;

namespace Pharmacy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ApiBaseController
    {
        public OrderDetailsController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var od = _unitOfWork.OrderDetails.GetByIdAsync(id);
            return Ok(await od);
        }

        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(OrderDetailsDto orderdetailsdto)
        {
            OrderDetail orderdetail = new OrderDetail()
            {
                OrderId = orderdetailsdto.OrderId,
                ProductId = orderdetailsdto.ProductId,
                Quantity = orderdetailsdto.Quantity,
                UnitPrice = orderdetailsdto.UnitPrice,
            };
            _unitOfWork.OrderDetails.Add(orderdetail);
            _unitOfWork.Save();
            return Ok(orderdetail);
        }
    }
    
}
