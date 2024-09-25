using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Pharmacy.Api.Dto;

namespace Pharmacy.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ApiBaseController
{
    public CategoryController(IUnitOfWork unitOfWork):base(unitOfWork)
    { }
    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var p = _unitOfWork.Categories.GetAll();
        return Ok(p);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var p=_unitOfWork.Categories.GetById(id);
        return Ok(p);
    }
    [HttpPost]
    public IActionResult Add(CategoryDto p1)
    {
        Category p=new Category(){
            CategoryName=p1.CategoryName
        };
        _unitOfWork.Categories.Add(p);
        _unitOfWork.Save();
        return Ok("Done Add");
    }
    [HttpDelete]
    public IActionResult Remove(int id)
    {
        var p = _unitOfWork.Categories.GetById(id);
        if(p==null)
        {
            return BadRequest("not found");
        }
        _unitOfWork.Categories.Delete(p);
        _unitOfWork.Save();
        return Ok("Done");
    }
    [HttpPut("Update")]
    public IActionResult Update(int id,CategoryDto p)
    {
        Category x= _unitOfWork.Categories.GetById(id);
        x.CategoryName = p.CategoryName;
        _unitOfWork.Categories.Update(x);
        _unitOfWork.Save();
        return Ok("update sucessed");
    }
}
