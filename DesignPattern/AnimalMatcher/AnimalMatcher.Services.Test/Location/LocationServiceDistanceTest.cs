namespace AnimalMatcher.Services.Test.Location
{
    using System;
    using AnimalMatcher.Common.Enums.Location;
    using AnimalMatcher.Services.Location;
    using AnimalMatcher.Services.Location.Interfaces;
    using AnimalMatcher.Services.Models.Location;
    using FluentAssertions;
    using Xunit;

    using static AnimalMatcher.Common.Constants.LocationConstants;

    public class LocationServiceDistanceTest
    {
        private readonly ILocationService locationService;

        public LocationServiceDistanceTest()
        {
            this.locationService = new LocationService();
        }

        [Fact]
        public void DistanceBetweenNearbyLocations()
        {
            // Arrange
            var firstLocation = new LocationDTO
            {
                Latitude = 42.686120,
                Longitude = 23.307800
            };

            var secondLocation = new LocationDTO
            {
                Latitude = 42.686301,
                Longitude = 23.307639
            };

            // Act
            double resultDistance = this.locationService.Distance(firstLocation, secondLocation);

            // Assert
            const double ExpectedDitanceBetweenLocations = 0.024;

            resultDistance.Should().BeApproximately(ExpectedDitanceBetweenLocations, 3);
        }

        [Fact]
        public void DistanceBetweenMidDistanceLocations()
        {
            // Arrange
            var firstLocation = new LocationDTO
            {
                Latitude = 42.671988,
                Longitude = 23.294731
            };

            var secondLocation = new LocationDTO
            {
                Latitude = 42.694507,
                Longitude = 23.446103
            };

            // Act
            double resultDistance = this.locationService.Distance(firstLocation, secondLocation);

            // Assert
            const double ExpectedDitanceBetweenLocations = 12.623;

            resultDistance.Should().BeApproximately(ExpectedDitanceBetweenLocations, 3);
        }

        [Fact]
        public void DistanceBetweenFarAwayLocations()
        {
            // Arrange
            var sofiaCity = new LocationDTO
            {
                Latitude = 42.697728,
                Longitude = 23.321807
            };

            var sanFranciscoCity = new LocationDTO
            {
                Latitude = 37.771883,
                Longitude = -122.420471
            };

            // Act
            double resultDistance = this.locationService.Distance(sofiaCity, sanFranciscoCity);

            // Assert
            const double ExpectedDitanceBetweenLocations = 10420.082;

            resultDistance.Should().BeApproximately(ExpectedDitanceBetweenLocations, 3);
        }

        [Fact]
        public void DistanceBetweenLocationsShouldAlwaysBeTheSame()
        {
            // Arrange
            var firstLocation = new LocationDTO
            {
                Latitude = 42.671988,
                Longitude = 23.294731
            };

            var secondLocation = new LocationDTO
            {
                Latitude = 42.694507,
                Longitude = 23.446103
            };

            // Act
            double distanceBetweenFistAndSecondLocation = this.locationService.Distance(firstLocation, secondLocation);
            double distanceBetweenSecondAndFirstLocation = this.locationService.Distance(secondLocation, firstLocation);

            // Assert
            distanceBetweenFistAndSecondLocation.Should().Be(distanceBetweenSecondAndFirstLocation);
        }

        [Fact]
        public void DistanceUnits()
        {
            // Arrange
            var firstLocation = new LocationDTO
            {
                Latitude = 42.671988,
                Longitude = 23.294731
            };

            var secondLocation = new LocationDTO
            {
                Latitude = 42.694507,
                Longitude = 23.446103
            };

            // Act
            double resultDistanceInKilometers = this.locationService.Distance(firstLocation, secondLocation, DistanceUnit.Kilometers);
            double resultDistanceInMiles = this.locationService.Distance(firstLocation, secondLocation, DistanceUnit.Miles);

            // Assert
            resultDistanceInKilometers.Should().Be(resultDistanceInMiles * 1.609344);
        }

        [Theory]
        [InlineData(LatitudeMinValue - 1, 23.294731, 42.694507, 23.446103)]
        [InlineData(LatitudeMaxValue + 1, 23.294731, 42.694507, 23.446103)]
        [InlineData(42.671988, LongitudeMinValue - 1, 42.694507, 23.446103)]
        [InlineData(42.671988, LongitudeMaxValue + 1, 42.694507, 23.446103)]
        [InlineData(42.671988, 23.294731, LatitudeMinValue - 1, 23.446103)]
        [InlineData(42.671988, 23.294731, LatitudeMaxValue + 1, 23.446103)]
        [InlineData(42.671988, 23.294731, 42.694507, LongitudeMinValue - 1)]
        [InlineData(42.671988, 23.294731, 42.694507, LongitudeMaxValue + 1)]
        public void InvalidLocations(double firstLocationLatitude, double firstLocationLongitude, double secondLocationLatitude, double secondLocationLongitude)
        {
            // Arrange
            var firstLocation = new LocationDTO
            {
                Latitude = firstLocationLatitude,
                Longitude = firstLocationLongitude
            };

            var secondLocation = new LocationDTO
            {
                Latitude = secondLocationLatitude,
                Longitude = secondLocationLongitude
            };

            // Act
            var exception = Record.Exception(() => this.locationService.Distance(firstLocation, secondLocation));

            // Assert
            exception.Should().NotBeNull();
            exception.Should().BeOfType(typeof(ArgumentException));
        }

        [Fact]
        public void NullLocations()
        {
            // Act
            var exception = Record.Exception(() => this.locationService.Distance(null, null));

            // Assert
            exception.Should().NotBeNull();
            exception.Should().BeOfType(typeof(ArgumentException));
        }
    }
}
