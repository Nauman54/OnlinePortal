using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
	public class UserModel
	{
		public int UserID { get; set; }
		public string? UserEmail { get; set; }
		public string? UserPassword { get; set; }
		public int RoleID { get; set; }
		public bool? UserIsActive { get; set; }

		public string? RoleName { get; set;}
	}
}
