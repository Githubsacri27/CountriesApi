using CountriesApi.Library.Contracts;
using CountriesApi.Library.Contracts.DTOs;
using CountriesApi.XCutting.Enums;
using CountriesApi.Infrastructure.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesApi.Library.Impl
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        // Inyectamos ICountryRepository en lugar de HttpClient
        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<object> GetCountryPopulationDataAsync(string initial, int year)
        {
            // Validación para asegurar que `initial` sea un solo carácter
            if (string.IsNullOrEmpty(initial) || initial.Length != 1)
            {
                return new ResponseErrorsDTO(
                    RegisterErrorCodesEnum.InvalidInitialLength,
                    "The 'initial' parameter must be a single character."
                );
            }
            try
            {
                // Llamada al repositorio para obtener los datos desde la API
                var countryEntities = await _countryRepository.GetCountriesByInitialAndYearAsync(initial, year);

                // Si no hay datos, devolver un error 404
                if (countryEntities == null || !countryEntities.Any())
                {
                    return new ResponseErrorsDTO(
                        RegisterErrorCodesEnum.NotFound,
                        "No countries found with the specified initial and year."
                    );
                }

                // Mapear los datos obtenidos a CountryDTO
                var filteredCountries = countryEntities.Select(entity => new CountryDTO
                {
                    Country = entity.country,
                    Population = entity.populationCounts.FirstOrDefault(p => p.Year == year)?.Value ?? 0
                }).ToList();

                // Si no se encuentra ninguna población para el año especificado, devolver 404
                if (!filteredCountries.Any(c => c.Population > 0))
                {
                    return new ResponseErrorsDTO(
                        RegisterErrorCodesEnum.NotFound,
                        "No population data found for the specified year."
                    );
                }

                // Devolver la lista de países si todo es correcto
                return filteredCountries;
            }
            catch (Exception ex)
            {
                // En caso de excepción, devolver un error 500
                return new ResponseErrorsDTO(
                    RegisterErrorCodesEnum.InternalServerError,
                    "An unexpected error occurred while processing the request.",
                    ex.Message
                );
            }
        }
    }
}
