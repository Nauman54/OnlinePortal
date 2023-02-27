using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
    public class FaclModel
    {
        public int FaclID { get; set; }
        public string? FaclFirstName { get; set; }
        public string? FaclLastName { get; set; }
        public int GenderID { get; set; }
        public string? FaclCNIC { get; set; }
		public string? FaclPhoneNo { get; set; }
        public string? FaclEmail { get; set; }
		public int CountryID { get; set; }
		public int CityID { get; set; }
		public string? FaclAddress { get; set; }
		public string? FaclLastJob { get; set; }
		public string? FaclExperience { get; set; }
        public int PosID { get; set; }
        public int QualID { get; set; }
		public int OrgID { get; set; }
		public int DeptID { get; set; }
		public string? FaclImage { get; set; }
		public bool? FaclIsActive { get; set; }


		public string? GenderName { get; set; }
		public string? CountryName { get; set; }
		public string? CityName { get; set; }
		public string? PosTitle { get; set; }
		public string? QualTitle { get; set; }
		public string? OrgName { get; set; }
		public string? DeptName { get; set; }
	}
}
