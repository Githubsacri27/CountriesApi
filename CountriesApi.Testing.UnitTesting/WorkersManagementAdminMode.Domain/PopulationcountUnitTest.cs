using CountriesApi.Library.Domain;


namespace CountriesApi.Testing.UnitTesting.WorkersManagementAdminMode.Domain
{
    public class PopulationcountUnitTest
    {
        [Fact]
        public void Populationcount_CanBeCreated()
        {
            // Arrange
            var population = new Populationcount
            {
                year = 1999,
                value = 987654
            };

            // Act & Assert
            Assert.Equal(1999, population.year);
            Assert.Equal(987654, population.value);
        }
    }
}
