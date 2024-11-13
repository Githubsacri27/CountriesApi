using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CountriesApi.Library.Contracts.DTOs
{
    public class CountryRsDTO
    {
        [JsonPropertyName("error")]
        public bool? Error { get; set; }
        [JsonPropertyName("msg")]
        public string? Msg { get; set; }
        [JsonPropertyName("data")]
        public DatumDto[]? Data { get; set; }

    }
}
