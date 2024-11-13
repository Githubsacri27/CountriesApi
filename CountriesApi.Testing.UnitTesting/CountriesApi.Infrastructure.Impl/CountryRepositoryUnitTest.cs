using CountriesApi.Infrastructure.Contracts.Entities;
using Moq.Protected;
using Moq;
using System.Net;
using CountriesApi.Infrastructure.Impl;
using System.Text.Json;
using System.Net.Http;
using CountriesApi.Infrastructure.Impl.Configuration;
using Microsoft.Extensions.Options;


namespace CountriesApi.Testing.UnitTesting.CountriesApi.Infrastructure.Impl
{
    public class CountryRepositoryUnitTest
    {
        [Fact]
        public async Task GetCountriesByInitialAndYearAsync_WhenApiResponseErrorIsTrue_ReturnsEmptyList()
        {
            // Arrange
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();

            var apiResponse = new ApiResponseEntity
            {
                error = true,
                msg = "An error occurred",
                data = new List<CountryEntity>()
            };
            var jsonResponse = JsonSerializer.Serialize(apiResponse);
            var responseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(jsonResponse)
            };

            mockHttpMessageHandler
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                   "SendAsync",
                   ItExpr.IsAny<HttpRequestMessage>(),
                   ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(responseMessage);

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);

            // Configurar CountryApiSettings para el test
            var settings = new CountryApiSettings
            {
                BaseUrl = "https://countriesnow.space/api/v0.1/countries/population/"
            };
            var options = Options.Create(settings);

            // Instanciar el repositorio con el HttpClient y los settings
            var repository = new CountryRepository(httpClient, options);

            // Act
            var result = await repository.GetCountriesByInitialAndYearAsync('A', 2000);

            // Assert
            Assert.NotNull(result); 
            Assert.Empty(result);   
        }

    }
}
