using Microsoft.AspNetCore.Components;
using UserManagement.Models;


namespace UserManagement.Pages
{
    public partial class GetUser
    {
        [Parameter]
        public int Id { get; set; }

        private GetUserByIdResult user = new GetUserByIdResult();

        protected override async Task OnInitializedAsync()
        {

            user = await userService.GetUserByIdAsync(Id);
        }
        private void BackToUserList()
        {
            NavigationManager.NavigateTo($"/fetchuser");
        }
    }
}
