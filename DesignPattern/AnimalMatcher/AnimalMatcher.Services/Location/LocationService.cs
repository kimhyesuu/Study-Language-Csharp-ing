namespace AnimalMatcher.Services.Location
{
    using System;
    using AnimalMatcher.Common.Enums.Location;
    using AnimalMatcher.Services.Location.Interfaces;
    using AnimalMatcher.Services.Models.Location;

    public class LocationService : ILocationService
    {
        public double Distance(LocationDTO locationFrom, LocationDTO locationTo, DistanceUnit unit = DistanceUnit.Kilometers)
        {
            if (!this.IsValidLocation(locationFrom))
            {
                throw new ArgumentException("Invalid locationFrom");
            }

            if (!this.IsValidLocation(locationTo))
            {
                throw new ArgumentException("Invalid locationTo");
            }

            double rlat1 = Math.PI * locationFrom.Latitude / 180;
            double rlat2 = Math.PI * locationTo.Latitude / 180;
            double theta = locationFrom.Longitude - locationTo.Longitude;
            double rtheta = Math.PI * theta / 180;

            double distance =
                (Math.Sin(rlat1) * Math.Sin(rlat2)) + (Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta));

            distance = Math.Acos(distance);
            distance = distance * 180 / Math.PI;
            double distanceInMiles = distance * 60 * 1.1515;

            switch (unit)
            {
                case DistanceUnit.Kilometers:
                    return distanceInMiles * 1.609344;
                case DistanceUnit.Miles:
                    return distanceInMiles;
            }

            return distanceInMiles;
        }

        private bool IsValidLocation(LocationDTO location)
        {
            return location != null
                && location.Latitude <= 90 && location.Latitude >= -90
                && location.Longitude <= 180 && location.Longitude >= -180;
        }
    }
}
