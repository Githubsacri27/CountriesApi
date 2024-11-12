using CountriesApi.Library.Contracts;
using CountriesApi.Library.Contracts.DTOs;
using CountriesApi.XCutting.Enums;
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

        //[HttpGet("countries-by-initial")]
        //public async Task<IActionResult> GetCountriesByInitial(char letter, int year)
        //{
        //    var countries = await _countryService.GetCountryPopulationDataAsync(letter, year);
        //    return Ok(countries);
        //}


        [HttpGet("countries-by-initial")]
        public async Task<IActionResult> GetCountriesByInitial(char letter, int year)
        {
            // Obtenemos la respuesta del servicio
            var response = await _countryService.GetCountryPopulationDataAsync(letter, year);

            // Comprobamos el tipo de respuesta
            return response switch
            {
                ResponseErrorsDTO errorResponse => errorResponse.ErrorCode switch
                {
                    RegisterErrorCodesEnum.BadRequest => BadRequest(errorResponse.Message),
                    RegisterErrorCodesEnum.NotFound => NotFound(errorResponse.Message),
                    RegisterErrorCodesEnum.InternalServerError => StatusCode(StatusCodes.Status500InternalServerError, errorResponse.Message),
                    _ => StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.")
                },
                List<CountryDTO> countries => Ok(countries),
                _ => StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.")
            };
        }



    }
}
