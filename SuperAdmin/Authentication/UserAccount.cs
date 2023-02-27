namespace SuperAdmin.Authentication
{
	public class UserAccount
	{
		public int UserID { get; set; }
		public string? UserEmail { get; set; }
		public string? UserPassword { get; set; }
		public string? Role { get; set; }
	}
}