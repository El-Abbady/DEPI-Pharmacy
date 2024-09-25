using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Models;
using Interfaces;
using Dto;

namespace Pharmacy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ApiBaseController
    {
        public OrdersController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _unitOfWork.Orders.GetAllAsync());
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _unitOfWork.Orders.GetByIdAsync(id));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(OrderDto orderdto)
        {
            Order order = new Order()
            {
                UserId = orderdto.UserId,
                OrderDate = orderdto.OrderDate,
                OrderStatus = orderdto.OrderStatus,
                
            };
            _unitOfWork.Orders.Add(order);
            _unitOfWork.Save();
            return Ok(order);
        }

        [HttpDelete("DeleteById")]
        public IActionResult DeleteById(int Id)
        {
            var order = _unitOfWork.Orders.GetById(Id);
            _unitOfWork.Orders.Delete(order);
            _unitOfWork.Save();
            return Ok(order);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, [FromBody]OrderDto order)
        {
            var o = _unitOfWork.Orders.GetById(id);
            o.UserId = order.UserId;
            o.OrderDate = order.OrderDate;
            o.OrderStatus = order.OrderStatus;
            
            

            _unitOfWork.Orders.Update(o);
            _unitOfWork.Save();
            return Ok(order);
        }
    }
}
