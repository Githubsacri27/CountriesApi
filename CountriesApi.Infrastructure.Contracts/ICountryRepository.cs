using CountriesApi.Infrastructure.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApi.Infrastructure.Contracts
{
    public interface ICountryRepository
    {
        Task<List<CountryEntity>> GetCountriesByInitialAndYearAsync(string initial, int year);
    }
}
