namespace AnimalMatcher.Data.Specifications.Pet
{
    using System;
    using AnimalMatcher.Data.Models;
    using AnimalMatcher.Data.Specifications.Interfaces;
    using AnimalMatcher.Specifications;

    public class FindPetsInRadiusSpecification : Specification<Pet>, ISpecification<Pet>
    {
        private const int EarthRadiusInKm = 6371;
        private const double RadiansPerDegree = 0.0174532925;

        public FindPetsInRadiusSpecification(string searcherId, double latitude, double longitude, double radius)
            : base(pet => pet.OwnerId != searcherId && 
                Math.Acos(Math.Sin(latitude * RadiansPerDegree)
                * Math.Sin(pet.Location.Latitude * RadiansPerDegree)
                + Math.Cos(latitude * RadiansPerDegree)
                * Math.Cos(pet.Location.Latitude * RadiansPerDegree)
                * Math.Cos(pet.Location.Longitude * RadiansPerDegree - longitude * RadiansPerDegree))
                * EarthRadiusInKm <= radius)
        {
            this.AddInclude(pet => pet.Location);
            this.AddInclude(pet => pet.Owner);
        }
    }
}
