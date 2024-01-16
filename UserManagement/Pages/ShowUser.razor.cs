using Microsoft.AspNetCore.Components;
using UserManagement.Models;

namespace UserManagement.Pages
{
    public partial class ShowUser
    {
        private List<GetAllUsersResult>? Users;

        protected override async Task OnInitializedAsync()
        {
            Users = await userService.GetAllUsersAsync();
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
