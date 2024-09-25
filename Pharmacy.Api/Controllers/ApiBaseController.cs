using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pharmacy.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApiBaseController : ControllerBase
{
    protected IUnitOfWork _unitOfWork;

    public ApiBaseController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}
