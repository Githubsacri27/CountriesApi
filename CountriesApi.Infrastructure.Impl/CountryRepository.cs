using CountriesApi.Infrastructure.Contracts;
using CountriesApi.Infrastructure.Contracts.Entities;
using CountriesApi.Infrastructure.Impl.Configuration;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace CountriesApi.Infrastructure.Impl
{
    public class CountryRepository : ICountryRepository
    {
        private readonly HttpClient _httpClient;

        public CountryRepository(HttpClient httpClient, IOptions<CountryApiSettings> settings)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            if (_httpClient.BaseAddress == null)
            {
                //_httpClient.BaseAddress = new Uri("https://countriesnow.space/api/v0.1/countries/population/");
                _httpClient.BaseAddress = new Uri(settings.Value.BaseUrl);
            }
        }

        public async Task<List<CountryEntity>> GetCountriesByInitialAndYearAsync(string initial, int year)
        {
            var response = await _httpClient.GetStringAsync($"?initial={initial}&year={year}");
            var apiResponse = JsonSerializer.Deserialize<ApiResponseEntity>(response);
            // controlar que no falle el programa si el valor de de error es true
            if ( apiResponse == null || apiResponse.error == true)
            {
                return new List<CountryEntity>();
            }

            return apiResponse != null && !apiResponse.error ? apiResponse.data : new List<CountryEntity>();
        }
    }
}
