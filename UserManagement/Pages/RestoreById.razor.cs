using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using UserManagement.Data;
using UserManagement.Models;

namespace UserManagement.Pages
{
    public partial class RestoreById
    {
        [Parameter]
        public int userid { get; set; }
        private List<GetEmployeeWithSkillsResult> userWithSkillList = new List<GetEmployeeWithSkillsResult>();
        private GetEmployeeWithSkillsResult userWithSkill = new GetEmployeeWithSkillsResult();
        private List<Skill> skillsList = new List<Skill>();
        private string? skillname;

        protected override async Task OnInitializedAsync()
        {
            userWithSkillList = await userService.GetUserByIdAsync(userid);
            skillsList = await userService.GetUsersSkills(userid);
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
            NavigationManager.NavigateTo($"/deleteduser");
        }
        private void HandleCancel()
        {
            NavigationManager.NavigateTo($"/deleteduser");
        }
    }
}
