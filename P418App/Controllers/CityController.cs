using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Cities;
using Service.Services.Interfaces;

namespace P418App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly ILogger<CityController> _logger;

        public CityController(ICityService cityService,
                              ILogger<CityController> logger)
        {
            _cityService = cityService;
            _logger = logger;

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CityCreateDto request)
        {
            await _cityService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), new {response = "Successfully"});
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Get all method is working");
            return Ok(await _cityService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _cityService.GetByIdAsync(id));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id == null)
            {
                _logger.LogWarning("Data is null");
                return BadRequest();
            }

            await _cityService.DeleteAsync((int)id);

            return Ok();
        }
      
    }
}
