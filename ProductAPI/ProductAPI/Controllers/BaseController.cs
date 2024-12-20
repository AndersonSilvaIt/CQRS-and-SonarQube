using Microsoft.AspNetCore.Mvc;
using ProductAPI.Application.Models;

namespace ProductAPI.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult ResponseFromResult(OperationResult result)
        {
            if (result.Success)
                return Ok(new { message = result.Message, data = result.Data });

            return BadRequest(new { Message = result.Message, errors = result.Errors });
        }
    }
}
