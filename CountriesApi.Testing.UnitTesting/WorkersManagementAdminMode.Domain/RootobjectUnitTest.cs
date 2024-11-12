using CountriesApi.Library.Domain;
using Xunit;

namespace CountriesApi.Testing.UnitTesting.WorkersManagementAdminMode.Domain
{
    public class RootobjectUnitTest
    {
        [Fact]
        public void Rootobject_CanBeCreated()
        {
            // Arrange
            var root = new Rootobject
            {
                error = false,
                msg = "Success",
                data = new Datum[]
                {
                new Datum { country = "España", code = "ES", iso3 = "ESP" }
                }
            };

            // Act & Assert
            Assert.False(root.error);
            Assert.Equal("Success", root.msg);
            Assert.NotNull(root.data);
            Assert.Single(root.data);
            Assert.Equal("España", root.data[0].country);
        }
    }
}
