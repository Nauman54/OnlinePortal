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
        public string? FaclPhoneNo { get; set; }
        public string? FaclEmail { get; set; }
        public string? FaclAddress { get; set; }
        public int PosID { get; set; }
        public int ExpID { get; set; }
        public int QualID { get; set; }
		public int DeptID { get; set; }
		public int OrgID { get; set; }

	}
}
