using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using UserManagement.Models;

namespace UserManagement.Pages
{
    public partial class UpdateUser
    {
        [Parameter]
        public int Id { get; set; }

        private List<GetEmployeeWithSkillsResult> _user = new List<GetEmployeeWithSkillsResult>();
        private GetEmployeeWithSkillsResult _newUser = new GetEmployeeWithSkillsResult();
        private List<string> _skills = new List<string>();
        private List<GetAllSkillsResult> _getskills = new List<GetAllSkillsResult>();
        private List<int> _selectedSkills = new List<int>();
        private List<Skill> _userSkills = new List<Skill>();

        protected override async Task OnInitializedAsync()
        {

            _user = await userService.GetUserByIdAsync(Id);
            _getskills = await userService.GetAllSkillAsync();
            _userSkills = await userService.GetUsersSkills(Id);

            foreach (var userSkill in _userSkills)
            {
                _selectedSkills.Add(userSkill.Skillid);
            }
        }
        bool isUserUpdated;

        private void ToggleSkilll(int skillId)
        {
            if (_selectedSkills.Contains(skillId))
            {
                _selectedSkills.Remove(skillId);
            }
            else
            {
                _selectedSkills.Add(skillId);
            }
            StateHasChanged();
        }
        private async Task HandleValidSubmit()
        {
            foreach (var item in _user)
            {
                _newUser = item;
                _skills.Add(item.SkillName);
            }

            isUserUpdated = await userService.UpdateUserAsync(_newUser);

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