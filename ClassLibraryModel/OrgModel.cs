using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
	public class OrgModel
	{
		public int OrgID { get; set; }
		public string? OrgName { get; set; }
		public string? OrgPhoneNo { get; set; }
		public string? OrgEmail { get; set; }
		public int CountryID { get; set; }
		public int CityID { get; set; }
		public string? OrgAddress { get; set; }
		public string? OrgLogo { get; set; }
		public bool? OrgIsActive { get; set; }

		public string? CountryName { get; set; }
		public string? CityName { get; set; }
	}
}
