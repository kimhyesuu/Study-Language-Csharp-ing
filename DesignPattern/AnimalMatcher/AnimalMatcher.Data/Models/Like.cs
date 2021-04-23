namespace AnimalMatcher.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Like
    {
        public int Id { get; set; }

        [Required]
        public int LikedByPetId { get; set; }

        public Pet LikedByPet { get; set; }

        [Required]
        public int LikedPetId { get; set; }

        public Pet LikedPet { get; set; }
    }
}
