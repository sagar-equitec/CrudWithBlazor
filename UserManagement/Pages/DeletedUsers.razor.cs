using Microsoft.JSInterop;
using UserManagement.Models;


namespace UserManagement.Pages
{
    public partial class DeletedUsers
    {
        private List<GetDeletedRecordsResult>? DeletedUserList;
        private List<GetDeletedRecordsResult>? DeletedUserListUpdated;
        private List<GetAllUsersSkillsResult>? SkillsList;
        private Dictionary<int, string> empSkillsDictionary = new Dictionary<int, string>();

        protected override async Task OnInitializedAsync()
        {
            DeletedUserList = await userService.GetDeletedUsers();
            SkillsList = await userService.GetAllUsersSkillAsync();

            DeletedUserListUpdated = DeletedUserList.GroupBy(user => user.id).Select(group => group.First()).ToList();

            foreach (var user in DeletedUserList)
            {
                var userSkills = SkillsList
                    .Where(skill => skill.UserId == user.id)
                    .Select(skill => skill.SkillName);

                empSkillsDictionary[user.id] = string.Join(", ", userSkills);
            }
        }
        private async Task RestoreUser(int userId)
        {
            bool isUserRestored = await userService.RestoreUserAsync(userId);
           
            if (isUserRestored)
            {
                await JSRuntime.InvokeVoidAsync("alert", "User restored successfully");
            }
            else
            {
                Console.WriteLine("Failed to update user.");
            }
            NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
        }


    }
}
