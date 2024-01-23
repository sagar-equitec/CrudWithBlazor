using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using UserManagement.Models;
using System.ComponentModel.DataAnnotations;


namespace UserManagement.Pages
{
    public partial class AddUser
    {
        private User _user = new User();
        private List<GetAllSkillsResult> skillList = new List<GetAllSkillsResult>();
        private string status;
        
        private List<int> _selectedSkillsList = new List<int>();

        private void ToggleSkill(int skillId)
        {
            if (_selectedSkillsList.Contains(skillId))
            {
                _selectedSkillsList.Remove(skillId);

            }
            else
            {
                _selectedSkillsList.Add(skillId);
                
            }
            if(_selectedSkillsList.Count > 0)
            {
                _user.Error = "added";
                status = "none";
            }
            else
            {
                _user.Error = null;
                status = "block";
              
            }
            StateHasChanged();
        }
        protected override async Task OnInitializedAsync()
        {
            skillList = await userService.GetAllSkillAsync();
        }

        private async void HandleValidSubmit()
        {
            try
            {
                bool isUserAdded = await userService.AddUserAsync(_user);

                if (isUserAdded)
                {
                    int? userId = await userService.GetEmployeeByNameAsync(_user.Name, _user.Designation, _user.City);

                    foreach (int skillId in _selectedSkillsList)
                    {
                        await userService.AddUserSkillAsync(userId, skillId);
                    }

                    _user = new User();
                    await JSRuntime.InvokeVoidAsync("alert", "User added successfully");
                }
                else
                {
                    Console.WriteLine("Failed to save user.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error handling valid submit: {ex.Message}");
            }
        }
        private void OnCancelClicked()
        {
            NavigationManager.NavigateTo($"/");
        }
        private void OnResetClicked()
        {
            _user = new User();
        }

    }
}
