using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Cities;
using Service.Services.Interface;

namespace App.Controllers.Admin
{
    public class CityController : BaseController
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _cityService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var city = await _cityService.GetByIdAsync(id);
                if (city == null)
                {
                    return NotFound();
                }
                return Ok(city);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var city = await _cityService.GetByNameAsync(name);
                if (city == null)
                {
                    return NotFound();
                }
                return Ok(city);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CityCreateDto request)
        {
            if (request == null)
            {
                return BadRequest(new { message = "Request cannot be null" });
            }

            try
            {
                await _cityService.CreateAsync(request);
                return CreatedAtAction(nameof(Create), new { response = "Data successfully created" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] CityEditDto request)
        {
            if (request == null)
            {
                return BadRequest(new { message = "Request cannot be null" });
            }
            try
            {
                var existingCity = await _cityService.GetByIdAsync(id);
                if (existingCity == null)
                {
                    return NotFound();
                }

                await _cityService.EditAsync(id, request);
                return Ok(new { response = "Data successfully updated" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existingCity = await _cityService.GetByIdAsync(id);
                if (existingCity == null)
                {
                    return NotFound();
                }

                await _cityService.DeleteAsync(id);
                return Ok(new { response = "Data successfully deleted" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
