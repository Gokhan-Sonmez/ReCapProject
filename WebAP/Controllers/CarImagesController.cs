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
        public IActionResult Add(IFormFile image, [FromForm] CarImage carImage)
        {

            var result = _carImageService.Add(image, carImage);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpPost("update")]
        public IActionResult Update(IFormFile image, [FromForm(Name = ("imageId"))] int imageId)
        {
            var carImage = _carImageService.Get(imageId).Data;
            var result = _carImageService.Update(image, carImage);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpDelete("delete")]
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

        public IActionResult GetCarImageByCarId(int carId)
        {
            var result = _carImageService.GetCarImageByCarId(carId);
            
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
