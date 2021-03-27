using Business.Abstract;
using Entities.Concrete;
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
    public class CustomerCardsController : ControllerBase
    {
        ICustomerCardService _customerCardService;

        public CustomerCardsController(ICustomerCardService customerCardService)
        {
            _customerCardService = customerCardService;
        }

        [HttpPost("add")]
        public IActionResult Add(CustomerCard customerCard)
        {
            var result = _customerCardService.Add(customerCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(CustomerCard customerCard)
        {
            var result = _customerCardService.Delete(customerCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(CustomerCard customerCard)
        {
            var result = _customerCardService.Add(customerCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("get")]
        public IActionResult Get(int customerCardId)
        {
            var result = _customerCardService.Get(customerCardId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getall")]
        public IActionResult Getall()
        {
            var result = _customerCardService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var result = _customerCardService.GetByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycustomerid")]
        public IActionResult GetByCardId(int cardId)
        {
            var result = _customerCardService.GetByCustomerId(cardId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
