using Business.Abstract;
using Entities.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        IVehicleService _vehicleService;

        public CarsController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        [HttpGet("getall")]
        //[Authorize(Roles ="Car.List")]
        public IActionResult GetAll()
        {
            Thread.Sleep(1000);
            var result = _vehicleService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _vehicleService.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getcardetailbyid")]
        public IActionResult GetCarDetailById(int id)
        {
            var result = _vehicleService.GetCarDetailsById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _vehicleService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcarsbybrandid")]
        public IActionResult GetCarsByBrandId(int brandId)
        {
            var result = _vehicleService.GetCarsByBrandId(brandId);
            if (result.Success) { 
                return Ok(result); 
            }
                
            return BadRequest(result);
        }

        [HttpGet("getcarsbycolorid")]
        public IActionResult GetCarsByColorId(int colorId)
        {
            var result = _vehicleService.GetCarsByColorId(colorId);
            if (result.Success) { 
                return Ok(result); 
            }
                
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Vehicle car)
        {
            var result = _vehicleService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("update")]
        public IActionResult Update(Vehicle car)
        {
            var result = _vehicleService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Vehicle car)
        {
            var result = _vehicleService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
