using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstEFDEmo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class AdminController : ControllerBase
    {

        [HttpGet("employees")]
        public IEnumerable<string> Get()
        {
            return new List<string> { "santosh", "Ali", "sita" };
        }

    }
}