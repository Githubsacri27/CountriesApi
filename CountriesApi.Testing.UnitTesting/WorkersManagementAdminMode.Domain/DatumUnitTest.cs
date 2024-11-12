using CountriesApi.Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApi.Testing.UnitTesting.WorkersManagementAdminMode.Domain
{
    public class DatumUnitTest
    {
        [Fact]
        public void Datum_CanBeCreated()
        {
            // Arrange
            var datum = new Datum
            {
                country = "España",
                code = "ES",
                iso3 = "ESP",
                populationCounts = new Populationcount[]
                {
                new Populationcount { year = 2000, value = 123456 }
                }
            };

            // Act & Assert
            Assert.Equal("España", datum.country);
            Assert.Equal("ES", datum.code);
            Assert.Equal("ESP", datum.iso3);
            Assert.NotNull(datum.populationCounts);
            Assert.Single(datum.populationCounts);
            Assert.Equal(2000, datum.populationCounts[0].year);
            Assert.Equal(123456, datum.populationCounts[0].value);
        }
    }
}
