using Microsoft.JSInterop;
using UserManagement.Models;

namespace UserManagement.Pages
{
    public partial class AddUser
    {
        private User user = new User();
        private List<GetAllUsersSkillsResult> getskills = new List<GetAllUsersSkillsResult>();
        public List<int> getSelected { get; set; } = new List<int>();
        public string? selectedids;

        protected override async Task OnInitializedAsync()
        {

            getskills = await userService.GetAllSkillAsync();
        }


        public void CheckboxClicked(int skillid, object checkedValue)
        {
            if ((bool)checkedValue)
            {

                getSelected.Add(skillid);

            }

            foreach (var item in getSelected) 
            {
                selectedids = selectedids + "," + item;
            }
        }

        private async void HandleValidSubmit()
        {
            try
            {

                bool isUserAdded = await userService.AddUserAsync(user, selectedids);

                if (isUserAdded)
                {
                   
                    int userId = user.Id;

                   
                    foreach (int skillId in getSelected)
                    {
                        await userService.AddUserSkillAsync(userId, skillId);
                    }

                 
                 
                    user = new User();

                   
                    await JSRuntime.InvokeVoidAsync("alert", "User added successfully");
                }
                else
                {
                    Console.WriteLine("Failed to save user.");
                }
            }
            catch (Exception ex)
            {
                // Handle exception, log, etc.
                Console.WriteLine($"Error handling valid submit: {ex.Message}");
            }
        }
    }
}
