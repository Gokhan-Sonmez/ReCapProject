using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpPost("add")]
        public IActionResult Add(IFormFile file, [FromForm] CarImage carImage)
        {

            var result = _carImageService.Add(file, carImage);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpPost("update")]
        public IActionResult Update(IFormFile file, [FromForm(Name = ("Id"))] int Id)
        {
            var carImage = _carImageService.Get(Id).Data;
            var result = _carImageService.Update(file, carImage);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {

            var result = _carImageService.Delete(carImage);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycarid")]

        public IActionResult GetCarImageByCarId(int id)
        {
            var result = _carImageService.GetCarImageByCarId(id);
            
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
