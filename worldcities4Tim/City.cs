using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worldcities4Tim
{
    class City
    {
        public City(string co, string ci, string acc, float la, float lo)
        {
            this.country = co;
            this.city = ci;
            this.accentCity = acc;
            this.latitude = la;
            this.longitude = lo;
        }
        public City()
        {

        }
        public string country { get; set; }
        public string city { get; set; }
        public string accentCity { get; set; }
        public string region { get; set; }
        public string population { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }

    }
}
