using CountriesApi.Library.Contracts;
using CountriesApi.Library.Contracts.DTOs;
using CountriesApi.Library.Domain;
using System.Text.Json;
using System.Threading.Tasks;

namespace CountriesApi.Library.Impl
{
    public class CountryService : ICountryService
    {
        private readonly HttpClient _httpClient;

        public CountryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CountryDTO>> GetCountryPopulationDataAsync(char initial, int year)
        {
            var response = await _httpClient.GetStringAsync("https://countriesnow.space/api/v0.1/countries/population");
            var result = JsonSerializer.Deserialize<Rootobject>(response);

            // Mapeo de Datum a CountryDTO
            var filteredCountries = result.data
                .Where(c => c.country.StartsWith(initial.ToString(), StringComparison.OrdinalIgnoreCase))
                .Select(c => new CountryDTO
                {
                    Country = c.country,
                    Population = c.populationCounts.FirstOrDefault(p => p.year == year)?.value ?? 0
                })
                .ToList();

            return filteredCountries ?? new List<CountryDTO>();
        }
    }
}
