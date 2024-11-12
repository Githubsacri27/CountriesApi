using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApi.Library.Contracts.DTOs
{
    public class DatumDto
    {
        public string country { get; set; }
        public string code { get; set; }
        public string iso3 { get; set; }
        public PopulationcountDto[] populationCounts { get; set; }
    }
}
