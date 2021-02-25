using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace WebAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
 

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;

        }




       

        [HttpPost("get")]

        public IActionResult Get(int carId)
        {
            var result = _carImageService.Get(carId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
