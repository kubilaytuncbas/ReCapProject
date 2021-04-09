using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            return Ok(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            return Ok(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result1 = _carService.GetById(id);
            return Ok(result1);
        }
        [HttpGet("GetCarDetails")]
        public IActionResult GetCarDetails(CarDetailDto carDetailDto)
        {
            var result2 = _carService.GetCarDetails();
            return Ok(result2);
        }
        [HttpGet]
        public IActionResult GetCarsByColorId(int id)
        {
            var result3 = _carService.GetCarsByColorId(id);
            return Ok(result3);
        }
        [HttpGet]
        public IActionResult GetCarsByBrandId(int id)
        {
            var result4 = _carService.GetCarsByBrandId(id);
            return Ok(result4);
        }
    }
}
