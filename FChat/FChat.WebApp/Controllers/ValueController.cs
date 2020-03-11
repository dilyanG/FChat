using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FChat.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        public ValueController()
        {
        }

        [HttpGet]
        public string Get()
        {
            return "The WebApp is working";
        }
    }
}
