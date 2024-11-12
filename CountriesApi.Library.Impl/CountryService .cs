using CountriesApi.Library.Contracts;
using CountriesApi.Library.Contracts.DTOs;
using CountriesApi.XCutting.Enums;
using System.Text.Json;


namespace CountriesApi.Library.Impl
{
    public class CountryService : ICountryService
    {
        private readonly HttpClient _httpClient;

        public CountryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //public async Task<List<CountryDTO>> GetCountryPopulationDataAsync(char initial, int year)
        //{
        //    // Llamada
        //    var response = await _httpClient.GetStringAsync("https://countriesnow.space/api/v0.1/countries/population");

        //    // Deserializar la respuesta del JSON en el CountryRsDTO
        //    var result = JsonSerializer.Deserialize<CountryRsDTO>(response);

        //    // Filtra y mapear los datos de la respuesta al CountryDTO con los DTOs
        //    var filteredCountries = result.data
        //        .Where(c => c.country.StartsWith(initial.ToString(), StringComparison.OrdinalIgnoreCase))
        //        .Select(c => new CountryDTO
        //        {
        //            Country = c.country,
        //            Population = c.populationCounts.FirstOrDefault(p => p.year == year)?.value ?? 0
        //        })
        //        .ToList();

        //    return filteredCountries ?? new List<CountryDTO>();
        //}

        public async Task<object> GetCountryPopulationDataAsync(char initial, int year)
        {
            try
            {
                var response = await _httpClient.GetStringAsync("https://countriesnow.space/api/v0.1/countries/population");
                var result = JsonSerializer.Deserialize<CountryRsDTO>(response);

                // Si no hay o faltan datos, devuelve 404
                if (result?.data == null || !result.data.Any())
                {
                    return new ResponseErrorsDTO(
                        RegisterErrorCodesEnum.NotFound,
                        "No data found for the specified parameters."
                    );
                }
                // filtra y mapea
                var filteredCountries = result.data
                    .Where(c => c.country.StartsWith(initial.ToString(), StringComparison.OrdinalIgnoreCase))
                    .Select(c => new CountryDTO
                    {
                        Country = c.country,
                        Population = c.populationCounts.FirstOrDefault(p => p.year == year)?.value ?? 0
                    })
                    .ToList();

                if (!filteredCountries.Any())
                {
                    // 404 sino hay las letras indicadas 
                    return new ResponseErrorsDTO(
                        RegisterErrorCodesEnum.NotFound,
                        "No countries found with the specified initial and year."
                    );
                }
                // Si todo va bien devuelve la lista
                return filteredCountries;
            }
            catch (Exception ex)
            {
                // Retorna 500 genérico
                return new ResponseErrorsDTO(
                    RegisterErrorCodesEnum.InternalServerError,
                    "An unexpected error occurred while processing the request.",
                    ex.Message
                );
            }
        }
    }
}
