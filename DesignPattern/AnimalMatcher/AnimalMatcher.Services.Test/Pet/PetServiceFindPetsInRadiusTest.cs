namespace AnimalMatcher.Services.Test.Pet
{
    using System;
    using System.Linq;
    using AnimalMatcher.Common.Enums.Location;
    using AnimalMatcher.Data;
    using AnimalMatcher.Data.Models;
    using AnimalMatcher.Data.Repository;
    using AnimalMatcher.Data.Repository.Interfaces;
    using AnimalMatcher.Services.Infrastructure.Mapping;
    using AnimalMatcher.Services.Location.Interfaces;
    using AnimalMatcher.Services.Models.Location;
    using AnimalMatcher.Services.Pet;
    using AutoMapper;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    public class PetServiceFindPetsInRadiusTest
    {
        private const int FirstPetId = 1;
        private const int SecondPetId = 2;
        private const int FirstPetLocationId = 1;
        private const int SecondPetLocationId = 2;
        private const string FirstPetOwnerId = "FirstPetOwnerId";
        private const string SecondPetOwnerId = "SecondPetOwnerId";

        private readonly AnimalMatcherDbContext animalMatcherDbContext;
        private readonly IMapper mapper;
        private readonly Mock<ILocationService> locationServiceMock;
        private readonly IGenericRepository<Pet> petRepository;

        private readonly PetService petService;

        public PetServiceFindPetsInRadiusTest()
        {
            this.animalMatcherDbContext = this.PrepareInMemoryDbContext();

            var configuration = new MapperConfiguration(config => config.AddProfile<AutoMapperServicesProfile>());
            this.mapper = new Mapper(configuration);

            this.petRepository = new GenericRepository<Pet>(this.animalMatcherDbContext);

            this.locationServiceMock = new Mock<ILocationService>();

            this.petService = new PetService(this.petRepository, this.locationServiceMock.Object, this.mapper);
        }

        [Fact]
        public void FindOnePetInRadiusFromLocation()
        {
            // Arrange
            const double SearchRadiusInKm = 1;
            const double DistanceToPetInKm = 0.8;

            this.PopulateDatabase();

            var testLocation = new LocationDTO
            {
                Latitude = 42.683074,
                Longitude = 23.293244
            };

            this.locationServiceMock.Setup(locationService => locationService.Distance(testLocation, It.IsAny<LocationDTO>(), It.IsAny<DistanceUnit>())).Returns(DistanceToPetInKm);

            string searcherId = SecondPetOwnerId;

            // Act
            var petCollection = this.petService.FindPetsInRadius(searcherId, testLocation, SearchRadiusInKm);

            // Assert 
            petCollection
                .Should()
                .HaveCount(1);

            var pet = petCollection.FirstOrDefault();
            pet.Id.Should().Be(FirstPetId);
            pet.Distance.Should().Be(DistanceToPetInKm);
            pet.Owner.Id.Should().Be(FirstPetOwnerId);
        }

        [Fact]
        public void FindMultiplePetsInRadiusFromLocation()
        {
            const double SearchRadiusInKm = 2.91;

            this.PopulateDatabase();

            var testLocation = new LocationDTO
            {
                Latitude = 42.683074,
                Longitude = 23.293244
            };

            string searcherId = "searcherId";

            // Act
            var petCollection = this.petService.FindPetsInRadius(searcherId, testLocation, SearchRadiusInKm);

            // Assert 
            petCollection
                .Should()
                .HaveCount(2);

            var firstPet = petCollection.FirstOrDefault();
            firstPet.Id.Should().Be(FirstPetId);
            firstPet.Owner.Id.Should().Be(FirstPetOwnerId);

            var secondPet = petCollection.ElementAt(1);
            secondPet.Id.Should().Be(SecondPetId);
            secondPet.Owner.Id.Should().Be(SecondPetOwnerId);
        }

        [Fact]
        public void SearchersPetsDoNotShowUpInSearch()
        {
            // Arrange
            const double SearchRadiusInKm = 3;

            this.PopulateDatabase();

            var testLocation = new LocationDTO
            {
                Latitude = 42.683074,
                Longitude = 23.293244
            };

            string searcherId = FirstPetOwnerId;

            // Act
            var petCollection = this.petService.FindPetsInRadius(searcherId, testLocation, SearchRadiusInKm);

            // Assert
            petCollection
                .Should()
                .HaveCount(1);

            var pet = petCollection.FirstOrDefault();
            pet.Id.Should().Be(SecondPetId);
            pet.Owner.Id.Should().Be(SecondPetOwnerId);
        }

        [Fact]
        public void CantFindPetsInEmptyDatabase()
        {
            // Arrange
            const double SearchRadiusInKm = 1;

            var testLocation = new LocationDTO
            {
                Latitude = 42.683074,
                Longitude = 23.293244
            };

            string searcherId = SecondPetOwnerId;

            // Act
            var petCollection = this.petService.FindPetsInRadius(searcherId, testLocation, SearchRadiusInKm);

            // Assert
            petCollection
                .Should()
                .BeNullOrEmpty();
        }

        [Fact]
        public void NoPetsInRadius()
        {
            // Arrange
            const double SearchRadiusInKm = 3;

            this.PopulateDatabase();

            var testLocation = new LocationDTO
            {
                Latitude = 42.693420,
                Longitude = 23.425223
            };

            string searcherId = SecondPetOwnerId;

            // Act
            var petCollection = this.petService.FindPetsInRadius(searcherId, testLocation, SearchRadiusInKm);

            // Assert
            petCollection
                .Should()
                .BeNullOrEmpty();
        }

        [Fact]
        public void InvalidRadius()
        {
            // Arrange
            const double InvalidSearchRadiusInKm = -2;

            this.PopulateDatabase();

            var testLocation = new LocationDTO
            {
                Latitude = 42.683074,
                Longitude = 23.293244
            };

            string searcherId = SecondPetOwnerId;

            // Act
            var exception = Record.Exception(() => this.petService.FindPetsInRadius(searcherId, testLocation, InvalidSearchRadiusInKm));

            // Assert
            exception.Should().NotBeNull();
            exception.Should().BeOfType(typeof(ArgumentException));
            exception.Message.Should().Be("Radius should be a positive value");
        }

        private AnimalMatcherDbContext PrepareInMemoryDbContext()
        {
            var dbContextOptions = new DbContextOptionsBuilder<AnimalMatcherDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new AnimalMatcherDbContext(dbContextOptions);
        }

        private void PopulateDatabase()
        {
            var firstPetOwner = new Owner
            {
                Id = FirstPetOwnerId,
                Name = "First Test Owner",
                UserName = "firstTestOwner"
            };

            var secondPetOwner = new Owner
            {
                Id = SecondPetOwnerId,
                Name = "Second Test Owner",
                UserName = "secondTestOwner"
            };

            var firstPetLocation = new Location
            {
                Id = FirstPetLocationId,
                Latitude = 42.681976,
                Longitude = 23.294524,
                PetId = FirstPetId
            };

            var secondPetLocation = new Location
            {
                Id = SecondPetLocationId,
                Latitude = 42.660607,
                Longitude = 23.311436,
                PetId = SecondPetId
            };

            var firstPet = new Pet
            {
                Id = FirstPetId,
                Age = 2,
                Name = "First Test pet",
                OwnerId = FirstPetOwnerId,
                LocationId = FirstPetLocationId
            };

            var secondPet = new Pet
            {
                Id = SecondPetId,
                Age = 12,
                Name = "Second Test pet",
                OwnerId = SecondPetOwnerId,
                LocationId = SecondPetLocationId
            };

            this.animalMatcherDbContext.Add(firstPetOwner);
            this.animalMatcherDbContext.Add(secondPetOwner);
            this.animalMatcherDbContext.Add(firstPetLocation);
            this.animalMatcherDbContext.Add(secondPetLocation);
            this.animalMatcherDbContext.Add(firstPet);
            this.animalMatcherDbContext.Add(secondPet);
            this.animalMatcherDbContext.SaveChanges();
        }
    }
}
