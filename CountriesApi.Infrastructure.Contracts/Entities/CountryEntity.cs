using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApi.Infrastructure.Contracts.Entities
{
    public class CountryEntity
    {
        public string country { get; set; }
        public string code { get; set; }
        public string iso3 { get; set; }
        public List<PopulationCountEntity> populationCounts { get; set; }
    }
}
