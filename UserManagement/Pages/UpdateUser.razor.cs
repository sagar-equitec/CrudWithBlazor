using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using UserManagement.Models;

namespace UserManagement.Pages
{
    public partial class UpdateUser
    {
        [Parameter]
        public int Id { get; set; }
        private List<GetSingleUserDetailsResult> _user = new List<GetSingleUserDetailsResult>();
        private GetSingleUserDetailsResult _newUser = new GetSingleUserDetailsResult();
        private List<string> _skills = new List<string>();
        private List<GetAllSkillsResult> _getskills = new List<GetAllSkillsResult>();
        private List<int> _selectedSkills = new List<int>();
        private List<Skill> _userSkillsList = new List<Skill>();
        private string? skillids;

        protected override async Task OnInitializedAsync()
        {
            _user = await userService.GetSingleUserByIdAsync(Id);
            _getskills = await userService.GetAllSkillAsync();
            _userSkillsList = await userService.GetUsersSkills(Id);

            foreach (var userSkill in _userSkillsList)
            {
                _selectedSkills.Add(userSkill.Skillid);
            }
            foreach (var item in _user)
            {
                _newUser = item;
                
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
            await userService.DeleteSkillsById(Id);

            foreach (var skill in _selectedSkills)
            { 
                skillids = skill + ","+ skillids;
            }
            skillids = skillids.Substring(0, skillids.Length - 1);
            Console.WriteLine(skillids);

            isUserUpdated = await userService.UpdateUserAsync(_newUser, skillids);

            if (isUserUpdated)
            {
                await JSRuntime.InvokeVoidAsync("alert", "User updated successfully");
                NavigationManager.NavigateTo($"/updateuser");
            }
            else
            {
                Console.WriteLine("Failed to update user.");
            }

        }
        private void OnCancelClicked()
        {
            NavigationManager.NavigateTo($"/updateuser");
        }
    }
}