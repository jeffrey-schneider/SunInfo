using System;

/**
 * {
      "results":            <--- goes into the SunResultModel
      {
        "sunrise":"7:27:02 AM",  <-- all this goes into the SunModel
        "sunset":"5:05:55 PM",
        "solar_noon":"12:16:28 PM",
        "day_length":"9:38:53",
        "civil_twilight_begin":"6:58:14 AM",
        "civil_twilight_end":"5:34:43 PM",
        "nautical_twilight_begin":"6:25:47 AM",
        "nautical_twilight_end":"6:07:10 PM",
        "astronomical_twilight_begin":"5:54:14 AM",
        "astronomical_twilight_end":"6:38:43 PM"
      },
       "status":"OK"
    }
*/
namespace SunInfo
{
    public class SunModel
    {
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
        public DateTime solar_noon { get; set; }
        public DateTime day_length { get; set; }
        public DateTime civil_twilight_begin { get; set; }
        public DateTime civil_twilight_end { get; set; }
        public DateTime nautical_twilight_begin { get; set; }
        public DateTime nautical_twilight_end { get; set; }
        public DateTime astronomical_twilight_begin { get; set; }
        public DateTime astronomical_twilight_end{ get; set; }
    }
}
