using JWT_Demo.JWTHelper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_Demo.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class JWTController : ControllerBase
    {
      public IActionResult JWT()
        {
            return new ObjectResult(JWTToken.GenerateJWTToken());
        }

    }
}
