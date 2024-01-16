using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<GetAllUsersResult>> GetAllUsersAsync()
        {
            return await _userContext.Procedures.GetAllUsersAsync();
        }

        public async Task<bool> AddUserAsync(User user)
        {
            await _userContext.Procedures.CreateUserAsync(user.Name, user.Designation, user.Age , user.City);
            return true;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            await _userContext.Procedures.DeleteUserAsync(id);
            return true;
        }

        public async Task<GetUserByIdResult> GetUserByIdAsync(int id)
        {
           return await _userContext.Procedures.GetUserByIdAsync(id);
        }

        internal async Task<bool> UpdateUserAsync(GetUserByIdResult GetUserByIdResult)
        {
            await _userContext.Procedures.UpdateUserAsync(GetUserByIdResult.Id, GetUserByIdResult.Name, GetUserByIdResult.Designation, GetUserByIdResult.Age, GetUserByIdResult.City);
            return true;
        }
        public async Task<List<DeletedUsersResult>> GetDeletedUsers()
        {
            return await _userContext.Procedures.DeletedUsersAsync();
        }

        public async Task<bool> RestoreUserAsync(int id)
        {
            await _userContext.Procedures.RestoreUserAsync(id);
            return true;
        }
    }
}
