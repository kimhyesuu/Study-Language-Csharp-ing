namespace AnimalMatcher.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using AnimalMatcher.Common.Constants;

    public class Location
    {
        public int Id { get; set; }

        [Required]
        [Range(LocationConstants.LatitudeMinValue, LocationConstants.LatitudeMaxValue)]
        public double Latitude { get; set; }

        [Required]
        [Range(LocationConstants.LongitudeMinValue, LocationConstants.LongitudeMaxValue)]
        public double Longitude { get; set; }

        [Required]
        public int PetId { get; set; }

        public Pet Pet { get; set; }
    }
}
