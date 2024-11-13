using System.Text.Json.Serialization;

namespace CountriesApi.Library.Contracts.DTOs
{
    public class DatumDto
    {
        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("code")]
        public string? Code { get; set; }
        [JsonPropertyName("iso3")]
        public string? Iso3 { get; set; }
        [JsonPropertyName("populationCounts")]
        public PopulationcountDto[]? PopulationCounts { get; set; }
    }
}
