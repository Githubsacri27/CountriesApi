using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CountriesApi.Infrastructure.Contracts.Entities
{
    public class PopulationCountEntity
    {
        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("value")]
        public long Value { get; set; }
    }
}
