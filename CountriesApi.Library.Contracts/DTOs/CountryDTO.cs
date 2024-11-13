using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CountriesApi.Library.Contracts.DTOs
{
    public class CountryDTO
    {
        public string? Country { get; set; }
        public long Population { get; set; }
    }
}
