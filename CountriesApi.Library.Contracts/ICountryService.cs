using CountriesApi.Library.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApi.Library.Contracts
{
    public interface ICountryService
    {
        //Task<List<CountryDTO>> GetCountryPopulationDataAsync(char initial, int year);
        Task<object> GetCountryPopulationDataAsync(char initial, int year);
    }
}
