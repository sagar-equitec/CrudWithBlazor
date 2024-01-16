using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using System;
using UserManagement.Data;
using UserManagement.Models;

namespace UserManagement.Pages
{
    public partial class UpdateUser
    {
        [Parameter]
        public int Id { get; set; }

        private GetUserByIdResult user = new GetUserByIdResult();

        protected override async Task OnInitializedAsync()
        {
          
            user = await userService.GetUserByIdAsync(Id);
        }
        bool isUserUpdated;
        private async Task HandleValidSubmit()
        {

            isUserUpdated = await userService.UpdateUserAsync(user);




            if (isUserUpdated)
            {
                await JSRuntime.InvokeVoidAsync("alert", "User updated successfully"); 
            }
            else
            {
                Console.WriteLine("Failed to update user.");
            }
        }
    }
}