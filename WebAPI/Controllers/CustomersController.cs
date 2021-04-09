using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            var result = _customerService.Add(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            var result = _customerService.Delete(customer);
                return Ok(result);
        }
        [HttpPost]
        
        public IActionResult Update(Customer customer)
        {
            var result = _customerService.Update(customer);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return GetAll();
        }
    }
}
