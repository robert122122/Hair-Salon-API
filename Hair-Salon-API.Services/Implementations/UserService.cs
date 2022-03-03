using AutoMapper;
using Hair_Salon_API.DAL.Models;
using Hair_Salon_API.DAL.UnitOfWork;
using Hair_Salon_API.Services.Interfaces;
using Hair_Salon_API.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair_Salon_API.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserModel> AddUserAsync(UserModel userToAdd)
        {
            User existingUser = (await _unitOfWork.UserRepository.FindAsync(user => user.Email == userToAdd.Email)).FirstOrDefault();
            
            if (existingUser != null)
            {
                throw new Exception("This User already exists!");
            }

            User newUser = _mapper.Map<UserModel, User>(userToAdd);

            newUser.DateAdded = DateTime.Now;
            newUser.DateUpdated = DateTime.Now;

            _unitOfWork.UserRepository.Add(newUser);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<User, UserModel>(newUser);
        }

        public async Task<UserModel> DeleteUserAsync(int userId)
        {
            User existingUser = await _unitOfWork.UserRepository.FindByIdAsync(userId);

            if (existingUser == null)
            {
                throw new Exception("User does not exist");
            }

            _unitOfWork.UserRepository.Remove(existingUser);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<User, UserModel>(existingUser);
        }

        public async Task<UserModel> GetUserAsync(int userId)
        {
            User existingUser = await _unitOfWork.UserRepository.FindByIdAsync(userId);

            if (existingUser == null)
            {
                throw new Exception("User does not exist");
            }

            return _mapper.Map<UserModel>(existingUser);
        }

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            return _mapper.Map<IEnumerable<UserModel>>(await _unitOfWork.UserRepository.FindAllAsync());
        }

        public async Task<UserModel> UpdateUserAsync(int userId, UserModel userToUpdate)
        {
            User existingUser = await _unitOfWork.UserRepository.FindByIdAsync(userId);

            if (existingUser == null)
            {
                throw new Exception("User does not exist");
            }

            userToUpdate.Id = existingUser.Id;
            userToUpdate.DateAdded = existingUser.DateAdded;
            userToUpdate.DateUpdated = DateTime.Now;

            _mapper.Map(userToUpdate, existingUser);

            _unitOfWork.UserRepository.Update(existingUser);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<User, UserModel>(existingUser);
        }
    }
}
