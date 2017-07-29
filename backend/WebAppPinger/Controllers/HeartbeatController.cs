using System;
using Microsoft.AspNetCore.Mvc;
using WebAppPinger.Infrastructure.ViewModels;

namespace WebAppPinger.Controllers
{
    [Route("api/[controller]")]
    public class HeartbeatController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var result = new QueryResult {Succsess = true};
            return Ok(result);
        }
    }
}