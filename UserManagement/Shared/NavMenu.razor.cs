﻿using Microsoft.AspNetCore.Components;

namespace UserManagement.Shared
{
    public partial class NavMenu
    {
        private bool showList = false;
        private string listDisplay => showList ? "block" : "none";
        private void ToggleDropdown()
        {
            showList = !showList;
        }

        private void GoToUpdateUser()
        {
            NavigationManager.NavigateTo("/updateuser");
        }
        private void GoToDeleteUser()
        {
            NavigationManager.NavigateTo("/deleteuser");
        }
        private void GoToRestoreUser()
        {
            NavigationManager.NavigateTo("/deleteduser");
        }
        private void GoToAllUser()
        {
            NavigationManager.NavigateTo("/");
        }
        private void GoToAddUser()
        {
            NavigationManager.NavigateTo("/adduser");
        }
    }
}
