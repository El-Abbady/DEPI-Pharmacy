using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Pharmacy.Api.Dto;

namespace Pharmacy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ApiBaseController
    {
        public ShippingController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        [HttpPost("Add")]
        public IActionResult Add(ShippingDto shippingDto) {
            Shipping shipping = new Shipping()
            {
                Description = shippingDto.Description,
                BaseCost = shippingDto.BaseCost,
                CostPerUnit = shippingDto.CostPerUnit,
                EstimatedDeliveryTime = shippingDto.EstimatedDeliveryTime,

            };

            _unitOfWork.Shippings.Add(shipping);
            _unitOfWork.Save();
            return Ok(shipping);
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id) {
            return Ok(await _unitOfWork.Shippings.GetByIdAsync(id));
        }

        [HttpDelete("DeleteById")]
        public IActionResult DeleteById(int id) {
            var model = _unitOfWork.Shippings.GetById(id);
            _unitOfWork.Shippings.Delete(model);
            _unitOfWork.Save();
            return Ok("Done");
        }

        [HttpPut("UpdateById")]
        public IActionResult UpdateById(int id, [FromBody] ShippingDto shipping) {
            var model = _unitOfWork.Shippings.GetById(id);
            model.Description = shipping.Description;
            model.BaseCost = shipping.BaseCost;
            model.CostPerUnit = shipping.CostPerUnit;
            model.EstimatedDeliveryTime = shipping.EstimatedDeliveryTime;

            _unitOfWork.Shippings.Update(model);
            _unitOfWork.Save();
            return Ok(model);
        }


    }
}
