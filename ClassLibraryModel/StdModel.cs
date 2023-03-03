using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
    public class StdModel
    {
        public int StdID { get; set; }
        public string? StdFirstName { get; set; }
        public string? StdLastName { get; set; }
        public int GenderID { get; set; }
        public string? StdCNIC { get; set; }
        public string? StdPhoneNo { get; set; }
        public string? StdEmail { get; set; }
        public int CountryID { get; set; }
        public int CityID { get; set; }
        public string? StdAddress { get; set; }
        public string? StdLastEducation { get; set; }
        public int OrgID { get; set; }
        public int DeptID { get; set; }
        public string? StdImage { get; set; }
        public bool? StdIsActive { get; set; }


        public string? GenderName { get; set; }
        public string? CountryName { get; set; }
        public string? CityName { get; set; }
        public string? OrgName { get; set; }
        public string? DeptName { get; set; }
    }
}