namespace AnimalMatcher.Services.Infrastructure.Mapping
{
    using AnimalMatcher.Data.Models;
    using AnimalMatcher.Services.Models.Location;
    using AnimalMatcher.Services.Models.Owner;
    using AnimalMatcher.Services.Models.Pet;
    using AutoMapper;

    public class AutoMapperServicesProfile : Profile
    {
        public AutoMapperServicesProfile()
        {
            this.PetRegistrations();
            this.OwnerRegistrations();
            this.LocationRegistrations();
        }

        private void PetRegistrations()
        {
            this.CreateMap<PetRegisterServiceModel, Pet>();

            this.CreateMap<Pet, PetWithOwnerServiceModel>();

            this.CreateMap<Pet, PetServiceModel>();

            this.CreateMap<Pet, PetWithDistanceServiceModel>();
        }

        private void OwnerRegistrations()
        {
            this.CreateMap<Owner, OwnerServiceModel>()
                .ForMember(ownerServiceModel => ownerServiceModel.Username, cfg => cfg.MapFrom(ownerDataModel => ownerDataModel.UserName));

            this.CreateMap<Owner, OwnerWithPetsServiceModel>();
        }

        private void LocationRegistrations()
        {
            this.CreateMap<LocationDTO, Location>();
        }
    }
}
