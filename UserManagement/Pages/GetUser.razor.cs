using Microsoft.AspNetCore.Components;
using UserManagement.Models;


namespace UserManagement.Pages
{
    public partial class GetUser
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
            if (skillname != null)
                skillname = skillname.Substring(0, skillname.Length - 2);
            else
                skillname = "no skills";
            foreach (var item in userWithSkillList)
            {
                userWithSkill = item; 
            } 
        }
        private void BackToUserList()
        {
            NavigationManager.NavigateTo($"/");
        }
    }
}
