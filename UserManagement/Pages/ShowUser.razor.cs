using Microsoft.AspNetCore.Components;
using UserManagement.Models;

namespace UserManagement.Pages
{
    public partial class ShowUser
    {
        private List<GetAllUsersDetailsResult>? Users;
        private List<GetAllUsersSkillsResult>? Skills;
        public Dictionary<int, string> empSkillsDictionary = new Dictionary<int, string>();



        protected override async Task OnInitializedAsync()
        {
            Users = await userService.GetAllUsersAsync();

            Skills = await userService.GetAllSkillAsync();



            foreach (var user in Users)
            {
                var userSkills = Skills
                    .Where(skill => skill.UserId == user.UserId)
                    .Select(skill => skill.SkillName);

                empSkillsDictionary[user.UserId] = string.Join(", ", userSkills);
            }


        }

        public void ConcatSkills()
        {
           
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
