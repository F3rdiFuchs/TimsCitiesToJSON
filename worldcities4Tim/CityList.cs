using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worldcities4Tim
{
    class CityList
    {
        public CityList()
        {
            cityList = new List<City>();
        }

        public List<City> cityList { get; set; }

        public void addCity(City city)
        {
            this.cityList.Add(city);
        }
        public void clearList()
        {
            this.cityList.Clear();
        }
    }
}
