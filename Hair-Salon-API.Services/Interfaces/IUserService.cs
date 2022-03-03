using Hair_Salon_API.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair_Salon_API.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> AddUserAsync(UserModel userToAdd);

        Task<UserModel> DeleteUserAsync(int userId);

        Task<UserModel> GetUserAsync(int userId);

        Task<IEnumerable<UserModel>> GetUsersAsync();

        Task<UserModel> UpdateUserAsync(int userId, UserModel userToUpdate);
    }
}
