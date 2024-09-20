using Microsoft.EntityFrameworkCore;
using Dto;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
namespace Pharmacy.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ApiBaseController
{  
    public ProductController(IUnitOfWork unitOfWork):base(unitOfWork)
    { }
    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var x =_unitOfWork.Products.GetAll();
        
        return Ok(x);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = _unitOfWork.Products.GetAll()
       .Where(p => p.ProductId == id)
       .Select(p => new ProductDto
       {
          
           ProductName = p.ProductName,
           ImageUrl = p.ImageUrl,
           Description = p.Description,
           Price = p.Price,
           QuantityInStock = p.QuantityInStock,
           CategoryId = p.CategoryId
       }).FirstOrDefault();
        return Ok(product);


    }
    [HttpPost("Add")]
    public IActionResult Post(ProductDto p2)
    {
        Product p = new Product()
        {
            ProductName=p2.ProductName,
            ImageUrl=p2.ImageUrl,
            Description=p2.Description,
            Price=p2.Price,
            CategoryId=p2.CategoryId,
            QuantityInStock=p2.QuantityInStock

        };
        _unitOfWork.Products.Add(p);
        _unitOfWork.Save();
        return Ok("Done");
    }
    [HttpPut("Update")]

    public IActionResult Put(int id, ProductDto p2)
    {
        Product p = _unitOfWork.Products.GetById(id);

        if (p == null)
        {
            return NotFound("Product not found.");
        }

        p.ProductName = p2.ProductName;
        p.ImageUrl = p2.ImageUrl;
        p.Description = p2.Description;
        p.Price = p2.Price;
        p.CategoryId = p2.CategoryId;
        p.QuantityInStock = p2.QuantityInStock;

        _unitOfWork.Products.Update(p);
        _unitOfWork.Save();

        return Ok("Done");
    }
    [HttpDelete("id")]
    public IActionResult Remove(int id)
    {
        Product p = _unitOfWork.Products.GetById(id);

        if (p == null)
        {
            return NotFound("Product not found.");
        }
        _unitOfWork.Products.Delete(p);
        _unitOfWork.Save();
        return Ok("Done");
    }

}
