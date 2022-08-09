using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskTrackerBaseController : ControllerBase
{
    [NonAction]
    protected ActionResult ReturnStatusCodeWithExceptionMessage(Exception e)
    {
        var statusCode = e.Data.Keys.Cast<int>().Single();

        if (statusCode == 400)
            return BadRequest(e.Message);
        if (statusCode == 404)
            return NotFound(e.Message);

        return StatusCode(500, $"exception message: {e.Message}. Inner message: {(e.InnerException != null ? e.InnerException.Message : "/")}");
    }
}

