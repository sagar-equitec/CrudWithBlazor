﻿using UserManagement.Models;

namespace UserManagement.Pages
{
    public partial class UpdateUserList
    {
        private List<GetAllUsersDetailsResult>? UsersList = new();
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

        private void UpdateUser(int userId)
        {
            NavigationManager.NavigateTo($"/updateuser/{userId}");
        }

   
    }
}
