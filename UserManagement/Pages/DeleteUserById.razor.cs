using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using UserManagement.Models;

namespace UserManagement.Pages
{
    public partial class DeleteUserById
    {
        [Parameter]
        public int Id { get; set; }
        private List<GetEmployeeWithSkillsResult> userWithSkillList = new List<GetEmployeeWithSkillsResult>();
        private GetEmployeeWithSkillsResult userWithSkill = new GetEmployeeWithSkillsResult();
        private List<Skill> skillsList = new List<Skill>();
        private string? skillname;

        protected override async Task OnInitializedAsync()
        {
            userWithSkillList = await userService.GetUserByIdAsync(Id);
            skillsList = await userService.GetUsersSkills(Id);
            foreach (var skill in skillsList)
            {
                skillname = skill.Skill1 + ", " + skillname;
            }
            skillname = skillname.Substring(0, skillname.Length - 2);
            foreach (var item in userWithSkillList)
            {
                userWithSkill = item;
            }
        }

        private async Task DeletedUsersById(int userId)
        {
           bool isUserDeleted =  await userService.DeleteUserAsync(userId);
            if (isUserDeleted)
            {
                await JSRuntime.InvokeVoidAsync("alert", "User deletd successfully");
            }
            else
            {
                Console.WriteLine("Failed to update user.");
            }
            NavigationManager.NavigateTo($"/deleteuser");
        }

        private void HandleCancel()
        {
            NavigationManager.NavigateTo($"/deleteuser");
        }
    }
}
