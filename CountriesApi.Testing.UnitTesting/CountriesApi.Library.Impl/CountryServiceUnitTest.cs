using CountriesApi.Library.Contracts.DTOs;
using CountriesApi.Library.Impl;
using Moq;
using Moq.Protected;
using System.Net;


namespace CountriesApi.Testing.UnitTesting.CountriesApi.Library.Impl
{
    //public class CountryServiceUnitTest
    //{
    //    private readonly CountryService _countryService;
    //    private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler;

    //    public CountryServiceUnitTest()
    //    {
    //        _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
    //        var httpClient = new HttpClient(_mockHttpMessageHandler.Object);
    //        _countryService = new CountryService(httpClient);
    //    }

    //    [Fact]
    //    public async Task GetCountryPopulationDataAsync_ValidInput_ReturnsData()
    //    {
    //        // Arrange
    //        char initial = 'A';
    //        int year = 2000;
    //        var mockResponse = new HttpResponseMessage
    //        {
    //            StatusCode = HttpStatusCode.OK,
    //            Content = new StringContent("[...]") // JSON simulado de respuesta
    //        };

    //        _mockHttpMessageHandler
    //            .Protected()
    //            .Setup<Task<HttpResponseMessage>>(
    //                "SendAsync",
    //                ItExpr.IsAny<HttpRequestMessage>(),
    //                ItExpr.IsAny<CancellationToken>()
    //            )
    //            .ReturnsAsync(mockResponse);

    //        // Act
    //        var result = await _countryService.GetCountryPopulationDataAsync(initial, year);

    //        // Assert
    //        Assert.NotNull(result);
    //        Assert.IsType<List<CountryDTO>>(result);
    //    }
    //}
}
