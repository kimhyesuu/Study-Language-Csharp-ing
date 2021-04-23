namespace AnimalMatcher.Services.Models.Pet
{
    using AnimalMatcher.Services.Models.Location;

    public class PetRegisterServiceModel
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string OwnerId { get; set; }

        public LocationDTO Location { get; set; }
    }
}
