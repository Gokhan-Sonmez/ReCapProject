using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindeksCheckController : ControllerBase
    {
        IFindeksCheckService _findeksCheckService;

        public FindeksCheckController(IFindeksCheckService findeksCheckService)
        {
            _findeksCheckService = findeksCheckService;
        }
        [HttpGet("findekscheck")]
        public IActionResult CheckIfFindeksEnough(int customerId, int carId)
        {
            var result = _findeksCheckService.CheckIfFindeksEnough(customerId, carId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
