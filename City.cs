using System;

namespace SunInfo
{
    public class City
    {
        public City()
        {
        }

        public City(string city, double latitude, double longitude)
        {
            this.city = city;
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public City(string city, string state, double latitude, double longitude)
        {
            this.city = city;
            this.state = state;
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public String city { get; set; }     
        public String state { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }

    }


}
