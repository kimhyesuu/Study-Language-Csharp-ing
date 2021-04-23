namespace AnimalMatcher.Web.Models.Pet
{
    using System.ComponentModel.DataAnnotations;

    public class PetShortViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string OwnerId { get; set; }

        [Display(Name = "Owner")]
        public string OwnerName { get; set; } 
    }
}
