using Microsoft.AspNetCore.Components;
using UserManagement.Models;

namespace UserManagement.Pages
{
    public partial class ShowUser
    {
        private List<GetAllUsersDetailsResult>? UsersList;
        private List<GetAllUsersSkillsResult>? SkillsList;
     
        private Dictionary<int, string> empSkillsDictionary = new Dictionary<int, string>();

        protected override async Task OnInitializedAsync()
        {
            UsersList = await userService.GetAllUsersAsync();

            SkillsList = await userService.GetAllUsersSkillAsync();



            foreach (var user in UsersList)
            {
                var userSkills = SkillsList
                    .Where(skill => skill.UserId == user.UserId)
                    .Select(skill => skill.SkillName);

                empSkillsDictionary[user.UserId] = string.Join(", ", userSkills);
            }
        }
  
        private async Task DeleteUser(int userId)
        {
            await userService.DeleteUserAsync(userId);
            NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
        }

        private void UpdateUser(int userId)
        {
            NavigationManager.NavigateTo($"/updateuser/{userId}");
        }

        private void GetUser(int id)
        {
            NavigationManager.NavigateTo($"/getuser/{id}");
        }
    }
}
