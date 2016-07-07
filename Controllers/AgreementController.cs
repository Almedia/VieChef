using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace viechef.Controllers
{
     [Route("api/[controller]")]
     public class AggrementController:Controller
     {
         [HttpGet("{id}")]
          public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
     }
}