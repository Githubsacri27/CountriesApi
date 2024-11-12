using CountriesApi.Infrastructure.Contracts;
using CountriesApi.Infrastructure.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CountriesApi.Infrastructure.Impl
{
    public class CountryRepository : ICountryRepository
    {
        private readonly HttpClient _httpClient;

        public CountryRepository()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://countriesnow.space/api/v0.1/countries/population/")
            };
        }

        public async Task<List<CountryEntity>> GetCountriesByInitialAndYearAsync(char initial, int year)
        {
            var response = await _httpClient.GetStringAsync($"?initial={initial}&year={year}");
            var apiResponse = JsonSerializer.Deserialize<ApiResponseEntity>(response);

            return apiResponse != null && !apiResponse.error ? apiResponse.data : new List<CountryEntity>();
        }
    }
}
