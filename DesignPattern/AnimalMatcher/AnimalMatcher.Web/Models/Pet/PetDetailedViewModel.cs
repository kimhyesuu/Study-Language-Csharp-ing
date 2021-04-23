namespace AnimalMatcher.Web.Models.Pet
{
    using System.ComponentModel.DataAnnotations;

    public class PetDetailedViewModel : PetShortViewModel
    {
        public int Age { get; set; }

        public string Description { get; set; }

        [Display(Name = "Owner username")]
        public string OwnerUsername { get; set; }
    }
}
