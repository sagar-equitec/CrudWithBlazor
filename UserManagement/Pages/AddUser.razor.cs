using Microsoft.JSInterop;
using UserManagement.Models;

namespace UserManagement.Pages
{
    public partial class AddUser
    {
        private User user = new User();

        private async void HandleValidSubmit()
        {
            bool isUserAdded = await userService.AddUserAsync(user);
            if (isUserAdded)
            {
                user = new();
                await JSRuntime.InvokeVoidAsync("alert", "User added successfully");


            }
            else
            {

                Console.WriteLine("Failed to save user.");
            }
        }
    }
}
