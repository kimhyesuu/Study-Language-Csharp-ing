namespace AnimalMatcher.Services.Pet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AnimalMatcher.Data.Models;
    using AnimalMatcher.Data.Repository.Interfaces;
    using AnimalMatcher.Data.Specifications.Pet;
    using AnimalMatcher.Services.Location.Interfaces;
    using AnimalMatcher.Services.Models.Location;
    using AnimalMatcher.Services.Models.Pet;
    using AnimalMatcher.Services.Pet.Interfaces;
    using AnimalMatcher.Specifications;

    using AutoMapper;

    public class PetService : IPetService
    {
        private readonly IGenericRepository<Pet> petRepository;
        private readonly ILocationService locationService;
        private readonly IMapper mapper;

        public PetService(IGenericRepository<Pet> petRepository, ILocationService locationService, IMapper mapper)
        {
            this.petRepository = petRepository;
            this.locationService = locationService;
            this.mapper = mapper;
        }

        public void Register(PetRegisterServiceModel pet)
        {
            var petDataModel = this.mapper.Map<Pet>(pet);

            this.petRepository.Add(petDataModel);
            this.petRepository.Save();
        }

        public PetWithOwnerServiceModel GetById(int petId)
        {
            var getWithOwnerByIdSpecification = new Specification<Pet>(pet => pet.Id == petId);
            getWithOwnerByIdSpecification.AddInclude(pet => pet.Owner);

            var petWithOwnerServiceModel = this.petRepository
                .List(getWithOwnerByIdSpecification)
                .Select(petDataModel => this.mapper.Map<PetWithOwnerServiceModel>(petDataModel))
                .FirstOrDefault();

            return petWithOwnerServiceModel;
        }

        public IEnumerable<PetWithOwnerServiceModel> GetOwnersPets(string ownerId)
        {
            var getAnimalByOwnerSpecification = new Specification<Pet>(pet => pet.OwnerId.Equals(ownerId));
            getAnimalByOwnerSpecification.AddInclude(pet => pet.Owner);

            var petsForOwner = this.petRepository
                .List(getAnimalByOwnerSpecification)
                .Select(petDataModel => this.mapper.Map<PetWithOwnerServiceModel>(petDataModel))
                .ToList();

            return petsForOwner;
        }

        public IEnumerable<PetWithDistanceServiceModel> FindPetsInRadius(string searcherId, LocationDTO location, double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Radius should be a positive value");
            }

            var findPetsInRadiusSpecification = new FindPetsInRadiusSpecification(searcherId, location.Latitude, location.Longitude, radius);

            var petsInRadius = this.petRepository
                .List(findPetsInRadiusSpecification)
                .Select(petDataModel =>
                {
                    var currentPetLocation = new LocationDTO { Latitude = petDataModel.Location.Latitude, Longitude = petDataModel.Location.Longitude };
                    var petServiceModel = this.mapper.Map<PetWithDistanceServiceModel>(petDataModel);
                    petServiceModel.Distance = this.locationService.Distance(location, currentPetLocation);
                    return petServiceModel;
                })
                .ToList();

            return petsInRadius;
        }
    }
}
