namespace AnimalMatcher.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using AnimalMatcher.Common.Constants;
    using Microsoft.AspNetCore.Identity;

    public class Owner : IdentityUser
    {
        [Required]
        [MinLength(OwnerConstants.NameMinLength)]
        [MaxLength(OwnerConstants.NameMaxLength)]
        public string Name { get; set; }

        public ICollection<Pet> Pets { get; set; } = new List<Pet>();
    }
}
