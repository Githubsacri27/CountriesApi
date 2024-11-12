using CountriesApi.Library.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CountriesApi.DistributedService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("countries-by-initial")]
        public async Task<IActionResult> GetCountriesByInitial(char letter, int year)
        {
            var countries = await _countryService.GetCountryPopulationDataAsync(letter, year);
            return Ok(countries);
        }
    }
}
