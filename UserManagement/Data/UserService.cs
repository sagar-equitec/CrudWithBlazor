using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using UserManagement.Models;
namespace UserManagement.Data
{
    public class UserService
    {

        private readonly UserContext _userContext;

        public UserService(UserContext userContext)
        {
            _userContext = userContext;
        }

        //GET ALL
        public async Task<List<GetAllUsersDetailsResult>> GetAllUsersAsync()
        {
            return await _userContext.Procedures.GetAllUsersDetailsAsync();
        }
        public async Task<List<GetAllUsersSkillsResult>> GetAllSkillAsync()
        {
            return await _userContext.Procedures.GetAllUsersSkillsAsync();
        }

        //ADD EMP
      /*  public async Task<bool> AddUserAsync(User user)
        {
            await _userContext.Procedures.InsertEmployeeWithSkillsAsync(user.Name, user.Designation , user.City, "1,2,3");
            return true;
        }*/
        public async Task<bool> AddUserAsync(User user, string selectedIds)
        {
            await _userContext.Procedures.InsertEmployeeWithSkillsAsync(user.Name, user.Designation, user.City, selectedIds);
            return true;
        }
        //SOFT DELETE
        public async Task<bool> DeleteUserAsync(int id)
        {
            await _userContext.Procedures.SoftDeleteUserAsync(id);
            return true;
        }

        //get single emp 
        public async Task<List<GetEmployeeWithSkillsResult>> GetUserByIdAsync(int id)
        {
           return await _userContext.Procedures.GetEmployeeWithSkillsAsync(id);
        }

        //update emp
        internal async Task<bool> UpdateUserAsync(GetEmployeeWithSkillsResult GetUserByIdResult)
        {
            await _userContext.Procedures.UpdateUserWithSkillsAsync(GetUserByIdResult.UserId, GetUserByIdResult.UserName, GetUserByIdResult.UserDesignation, GetUserByIdResult.UserCity, "4,5,6");
            return true;
        }

        //SHOW DELETED RECORDS
        public async Task<List<GetDeletedRecordsResult>> GetDeletedUsers()
        {
            return await _userContext.Procedures.GetDeletedRecordsAsync();
        }

        public async  Task AddUserSkillAsync(int userId, int skillId)
        {
             await _userContext.Procedures.AddUserSkillAsync(userId, skillId);
        }

        /* public async Task<bool> RestoreUserAsync(int id)
         {
             await _userContext.Procedures.(id);
             return true;
         }*/
    }
}
