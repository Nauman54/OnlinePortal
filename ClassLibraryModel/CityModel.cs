using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
    public class CityModel
    {
        public int CityID { get; set; }
        public string? CityName { get; set; }
        public int CountryID { get; set; }
        public string? CountryName { get; set; }
    }
}
