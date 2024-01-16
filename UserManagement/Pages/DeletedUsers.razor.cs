using Microsoft.JSInterop;
using UserManagement.Models;


namespace UserManagement.Pages
{
    public partial class DeletedUsers
    {
        private List<DeletedUsersResult>? Users;

        protected override async Task OnInitializedAsync()
        {
            Users = await userService.GetDeletedUsers();
        }
        private async Task RestoreUser(int userId)
        {
            bool flag = await userService.RestoreUserAsync(userId);
            NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
        }

      
    }
}
