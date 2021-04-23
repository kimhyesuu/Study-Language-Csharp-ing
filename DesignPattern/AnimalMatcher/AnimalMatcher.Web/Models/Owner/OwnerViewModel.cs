namespace AnimalMatcher.Web.Models.Owner
{
    using System.Collections.Generic;
    using AnimalMatcher.Web.Models.Pet;

    public class OwnerViewModel
    {
        public string Name { get; set; }
        
        public string Username { get; set; }
        
        public ICollection<PetShortViewModel> Pets { get; set; }
    }
}
