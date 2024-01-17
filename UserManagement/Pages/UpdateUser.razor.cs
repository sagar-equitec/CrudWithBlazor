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

        private List<GetEmployeeWithSkillsResult> user = new List<GetEmployeeWithSkillsResult>();
        private GetEmployeeWithSkillsResult newUser = new GetEmployeeWithSkillsResult();
        private List<string> skills = new List<string>();

        protected override async Task OnInitializedAsync()
        {
          
            user = await userService.GetUserByIdAsync(Id);
        }
        bool isUserUpdated;
        private async Task HandleValidSubmit()
        {

           

            foreach (var item in user)
            {
                newUser = item;
                skills.Add(item.SkillName);
            }
          /*  isUserUpdated = await userService.UpdateUserAsync();




            if (isUserUpdated)
            {
                await JSRuntime.InvokeVoidAsync("alert", "User updated successfully"); 
            }
            else
            {
                Console.WriteLine("Failed to update user.");
            }*/
        }
    }
}