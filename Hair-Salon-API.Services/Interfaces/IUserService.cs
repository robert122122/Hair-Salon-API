using Hair_Salon_API.Services.Models;

namespace Hair_Salon_API.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> Authenticate(AuthenticateRequest model);

        Task<UserModel> AddUserAsync(UserModel userToAdd);

        Task<UserModel> DeleteUserAsync(int userId);

        Task<UserModel> GetUserAsync(int userId);

        Task<IEnumerable<UserModel>> GetUsersAsync();

        Task<UserModel> UpdateUserAsync(int userId, UserModel userToUpdate);
    }
}
