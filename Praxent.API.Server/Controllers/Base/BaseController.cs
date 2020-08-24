using Microsoft.AspNetCore.Mvc;

namespace Praxent.API.Server.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
    }
}