using System.Runtime.CompilerServices;
using ClassLibraryModel;
using ClassLibraryDAL;

namespace FacultyPanel.Authentication
{
    public class UserAccountService
    {
        private List<UserModel> usrData { get; set; } = new List<UserModel>();
        private List<UserAccount> users = new List<UserAccount>();

        private void LoadUser()
        {
            usrData = UserDAL.GetUser();
        }

        public UserAccountService()
        {
            LoadUser();
            foreach (var item in usrData)
            {
                var newUser = new UserAccount { UserEmail = item.UserEmail, UserPassword = item.UserPassword, Role = item.RoleName };
                users.Add(newUser);
            }
        }

        public UserAccount? GetByUserEmail(string UserEmail)
        {
            return users.FirstOrDefault(x => x.UserEmail == UserEmail);
        }
    }
}
