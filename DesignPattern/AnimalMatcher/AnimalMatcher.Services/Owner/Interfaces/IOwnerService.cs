namespace AnimalMatcher.Services.Owner.Interfaces
{
    using AnimalMatcher.Services.Models.Owner;

    public interface IOwnerService
    {
        OwnerWithPetsServiceModel GetOwnerWithPetsById(string id);
    }
}
