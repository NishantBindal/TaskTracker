using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace TaskTracker.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
    }
}