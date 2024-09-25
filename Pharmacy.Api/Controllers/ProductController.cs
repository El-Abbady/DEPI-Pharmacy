using Dto;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Pharmacy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ApiBaseController
    {
        public ProductController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var products = _unitOfWork.Products.GetAll()
                .Select(p => new ProductDto
                {
                    ProductName = p.ProductName,
                    Description = p.ProductDescription,
                    Price = (int)p.Price,
                    QuantityInStock = (int)p.QuantityInStock,
                    CategoryId = p.CategoryId,
                    ImageUrl = p.ProductImage
                })
                .ToList();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _unitOfWork.Products.GetAll()
                .Where(p => p.ProductId == id)
                .Select(p => new ProductDto
                {
                    ProductName = p.ProductName,
                    Description = p.ProductDescription,
                    Price = (int)p.Price,
                    QuantityInStock = (int)p.QuantityInStock,
                    CategoryId = p.CategoryId,
                    ImageUrl = p.ProductImage
                })
                .FirstOrDefault();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost("Insert")]
        public IActionResult Add([FromBody] ProductDto p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newProduct = new Product()
            {
                ProductName = p.ProductName,
                ProductImage = p.ImageUrl,
                ProductDescription = p.Description,
                Price = p.Price,
                QuantityInStock = p.QuantityInStock,
                CategoryId = p.CategoryId
            };
            _unitOfWork.Products.Add(newProduct);
            _unitOfWork.Save();


            return Ok("Done");
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] ProductDto p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingProduct = _unitOfWork.Products.GetAll().FirstOrDefault(prod => prod.ProductId == id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.ProductName = p.ProductName;
            existingProduct.ProductImage = p.ImageUrl;
            existingProduct.ProductDescription = p.Description;
            existingProduct.Price = p.Price;
            existingProduct.QuantityInStock = p.QuantityInStock;
            existingProduct.CategoryId = p.CategoryId;

            _unitOfWork.Products.Update(existingProduct);
            _unitOfWork.Save();


            return Ok("Done");
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var product = _unitOfWork.Products.GetAll().FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            _unitOfWork.Products.Delete(product);
            _unitOfWork.Save();

            return  Ok ("Done"); 
        }
    }
}
