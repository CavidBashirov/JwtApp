using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Countries;
using Service.Services.Interfaces;

namespace P418App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CountryCreateDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _countryService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), new { response = "Success" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _countryService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _countryService.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWithCities()
        {
            return Ok(await _countryService.GetAllWithCitiesAsync());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id is null) return BadRequest();

            await _countryService.DeleteAsync((int)id);

            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] CountryEditDto request)
        {
            await _countryService.EditAsync(id, request);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetByNameWithCities([FromQuery] string name)
        {
            var response = await _countryService.GetCountryByNameWithCities(name);

            if (response is null) return NotFound();

            return Ok(response);
        }
    }
}
