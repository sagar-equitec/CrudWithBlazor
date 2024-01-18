using UserManagement.Models;


namespace UserManagement.Pages
{
    public partial class DeletedUsers
    {
        private List<GetDeletedRecordsResult>? DeletedUserList;

        protected override async Task OnInitializedAsync()
        {
            DeletedUserList = await userService.GetDeletedUsers();
        }
        private async Task RestoreUser(int userId)
        {
            bool flag = await userService.RestoreUserAsync(userId);
            NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
        }


    }
}
