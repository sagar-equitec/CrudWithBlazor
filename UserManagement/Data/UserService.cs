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

        //GET ALL
        public async Task<List<GetAllUsersDetailsResult>> GetAllUsersAsync()
        {
            return await _userContext.Procedures.GetAllUsersDetailsAsync();
        }

        public async Task<List<GetAllSkillsResult>> GetAllSkillAsync()
        {
            return await _userContext.Procedures.GetAllSkillsAsync();
        }

        //GET USERS SKILLS
        public async Task<List<Skill>> GetUsersSkills(int userId)
        {
            List<Skill> userSkills = await _userContext.Skills
                .Where(skill => skill.Users.Any(user => user.Id == userId))
                .ToListAsync();

            return userSkills;
        }

        public async Task<List<GetAllUsersSkillsResult>> GetAllUsersSkillAsync()
        {
            return await _userContext.Procedures.GetAllUsersSkillsAsync();
        }

        public async Task<int?> GetEmployeeByNameAsync(string? employeeName, string? designation, string? city)
        {
            int? userId = await _userContext.Users
     .Where(e => e.Name == employeeName && e.Designation == designation && e.City == city)
     .Select(e => (int?)e.Id)
     .FirstOrDefaultAsync();
            return userId;
        }

        public async Task<bool> AddUserAsync(User user)
        {
            await _userContext.Procedures.AddUserDetailsAsync(user.Name, user.Designation, user.City);
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
        public async Task<bool> UpdateUserAsync(GetEmployeeWithSkillsResult GetUserByIdResult)
        {
            await _userContext.Procedures.UpdateUserWithSkillsAsync(GetUserByIdResult.UserId, GetUserByIdResult.UserName, GetUserByIdResult.UserDesignation, GetUserByIdResult.UserCity, "4,5,6");
            return true;
        }

        //SHOW DELETED RECORDS
        public async Task<List<GetDeletedRecordsResult>> GetDeletedUsers()
        {
            return await _userContext.Procedures.GetDeletedRecordsAsync();
        }

        public async Task AddUserSkillAsync(int? userId, int skillId)
        {
            await _userContext.Procedures.AddUserSkillAsync(userId, skillId);
        }

        public async Task<bool> RestoreUserAsync(int id)
        {
            await _userContext.Procedures.RestoreEmployeeAsync(id);
            return true;
        }
    }
}
