using Microsoft.AspNetCore.Components;
using UserManagement.Models;


namespace UserManagement.Pages
{
    public partial class GetUser
    {
        [Parameter]
        public int Id { get; set; }

        private List<GetEmployeeWithSkillsResult> user = new List<GetEmployeeWithSkillsResult>();
        private GetEmployeeWithSkillsResult newUser = new GetEmployeeWithSkillsResult();
        private List<string> skills = new List<string>();

        protected override async Task OnInitializedAsync()
        {

            user = await userService.GetUserByIdAsync(Id);
            foreach (var item in user)
            {
                newUser = item;
                skills.Add(item.SkillName);
            }
        }
        private void BackToUserList()
        {
            NavigationManager.NavigateTo($"/fetchuser");
        }
    }
}
