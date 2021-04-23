namespace AnimalMatcher.Services.Models.Pet
{
    using AnimalMatcher.Services.Models.Owner;

    public class PetWithOwnerServiceModel : PetServiceModel
    {
        public OwnerServiceModel Owner { get; set; }
    }
}
