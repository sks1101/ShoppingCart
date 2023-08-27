using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckLoggerController : ControllerBase
    {
        private readonly ILogger<CheckLoggerController> _logger;

        public CheckLoggerController(ILogger<CheckLoggerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get(int id)
        {
            if (id > 0)
            {
                _logger.LogInformation("Successfully Entered");
                return "Successfully Entered ";
            }
            else
            {
                _logger.LogError("Not Entered");
                return "Not Entered";
            }
        }
    }
}
