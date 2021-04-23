namespace AnimalMatcher.Services.Owner
{
    using System.Linq;

    using AnimalMatcher.Data.Models;
    using AnimalMatcher.Data.Repository.Interfaces;
    using AnimalMatcher.Services.Models.Owner;
    using AnimalMatcher.Services.Owner.Interfaces;
    using AnimalMatcher.Specifications;
    using AutoMapper;

    public class OwnerService : IOwnerService
    {
        private readonly IGenericRepository<Owner> ownerRepository;
        private readonly IMapper autoMapper;

        public OwnerService(IGenericRepository<Owner> ownerRepository, IMapper autoMapper)
        {
            this.ownerRepository = ownerRepository;
            this.autoMapper = autoMapper;
        }

        public OwnerWithPetsServiceModel GetOwnerWithPetsById(string id)
        {
            var getOwnerWithPetsSpecification = new Specification<Owner>(owner => owner.Id.Equals(id));
            getOwnerWithPetsSpecification.AddInclude(owner => owner.Pets);

            var ownerWithPets = this.ownerRepository
                .List(getOwnerWithPetsSpecification)
                .Select(ownerDataModel => this.autoMapper.Map<OwnerWithPetsServiceModel>(ownerDataModel))
                .FirstOrDefault();

            return ownerWithPets;
        }
    }
}
