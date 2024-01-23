using Microsoft.JSInterop;
using UserManagement.Models;


namespace UserManagement.Pages
{
    public partial class DeletedUsers
    {
        private List<GetDeletedRecordsResult>? deletedUserList = new();
        private List<GetDeletedRecordsResult>? deletedUserListUpdated;
        private List<GetAllUsersSkillsResult>? skillsList;
        private Dictionary<int, string> empSkillsDictionary = new Dictionary<int, string>();

        protected override async Task OnInitializedAsync()
        {
            deletedUserList = await userService.GetDeletedUsers();
            skillsList = await userService.GetAllUsersSkillAsync();

            deletedUserListUpdated = deletedUserList.GroupBy(user => user.id).Select(group => group.First()).ToList();

            foreach (var user in deletedUserList)
            {
                var userSkills = skillsList
                    .Where(skill => skill.UserId == user.id)
                    .Select(skill => skill.SkillName);

                empSkillsDictionary[user.id] = string.Join(", ", userSkills);
            }
        }
        private  void RestoreUser(int userId)
        {
            NavigationManager.NavigateTo($"/restorebyid/{userId}");
        }


    }
}
