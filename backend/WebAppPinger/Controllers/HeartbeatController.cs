using Microsoft.AspNetCore.Mvc;
using WebAppPinger.Infrastructure.Interface;

namespace WebAppPinger.Controllers
{
    [Route("api/[controller]")]
    public class HeartbeatController : Controller
    {
        private readonly IJobManager manager;

        public HeartbeatController(IJobManager manager)
        {
            this.manager = manager;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(manager.Start());
        }
    }
}