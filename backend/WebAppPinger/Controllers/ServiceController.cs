using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace WebAppPinger.Controllers
{
    [Route("api/[controller]")]
    public class ServiceController
    {
        [HttpGet]
        public IEnumerable<SelectorModel> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public SelectorModel Get(int url)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Create()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public IActionResult Update()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IEnumerable<SelectorModel> Delete()
        {
            throw new NotImplementedException();
        }
    }
}