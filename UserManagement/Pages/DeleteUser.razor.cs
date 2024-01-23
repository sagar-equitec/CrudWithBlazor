using UserManagement.Models;

namespace UserManagement.Pages
{
    public partial class DeleteUser
    {
        private List<GetAllUsersDetailsResult>? UserList = new();
        private List<GetAllUsersSkillsResult>? SkillsList;

        private Dictionary<int, string> empSkillsDictionary = new Dictionary<int, string>();

        protected override async Task OnInitializedAsync()
        {
            UserList = await userService.GetAllUsersAsync();
            SkillsList = await userService.GetAllUsersSkillAsync();
            foreach (var user in UserList)
            {
                var userSkills = SkillsList
                    .Where(skill => skill.UserId == user.UserId)
                    .Select(skill => skill.SkillName);

                empSkillsDictionary[user.UserId] = string.Join(", ", userSkills);
            }
        }
        private  void DeleteUserById(int userId)
        {
            /* bool flag = await userService.DeleteUserAsync(userId);*/
            NavigationManager.NavigateTo($"/deleteuserbyid/{userId}");
        }


    }
}
