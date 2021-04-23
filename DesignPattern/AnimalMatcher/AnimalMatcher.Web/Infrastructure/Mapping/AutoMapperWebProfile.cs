namespace AnimalMatcher.Web.Infrastructure.Mapping
{
    using AnimalMatcher.Services.Models.Owner;
    using AnimalMatcher.Services.Models.Pet;
    using AnimalMatcher.Web.Models.Owner;
    using AnimalMatcher.Web.Models.Pet;
    using AutoMapper;

    public class AutoMapperWebProfile : Profile
    {
        public AutoMapperWebProfile()
        {
            this.PetRegistrations();
            this.OwnerRegistrations();
        }

        private void PetRegistrations()
        {
            this.CreateMap<PetInputModel, PetRegisterServiceModel>()
                .ForPath(petServiceModel => petServiceModel.Location.Latitude, cfg => cfg.MapFrom(petInputModel => petInputModel.Latitude))
                .ForPath(petServiceModel => petServiceModel.Location.Longitude, cfg => cfg.MapFrom(petInputModel => petInputModel.Longitude));

            this.CreateMap<PetWithOwnerServiceModel, PetDetailedViewModel>();
        }

        private void OwnerRegistrations()
        {
            this.CreateMap<OwnerWithPetsServiceModel, OwnerViewModel>();
        }
    }
}
