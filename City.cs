using System;

namespace SunInfo
{
    public class City
    {
        public City()
        {
        }

        public City(string cityName, double latitude, double longitude)
        {
            this.CityName = cityName;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public City(string cityName, string state, double latitude, double longitude)
        {
            this.CityName = cityName;
            this.State = state;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public String CityName { get; set; }     
        public String State { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }


}
