namespace AnimalMatcher.Services.Models.Owner
{
    using System.Collections.Generic;
    using AnimalMatcher.Services.Models.Pet;

    public class OwnerWithPetsServiceModel : OwnerServiceModel
    {
        public ICollection<PetWithOwnerServiceModel> Pets { get; set; }
    }
}
