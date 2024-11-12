using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApi.Library.Contracts.DTOs
{
    public class CountryRqDTO
    {
        public char InitialLetter { get; set; }
        public int Year { get; set; }
    }
}
