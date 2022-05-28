using AutoMapper;
using Hair_Salon_API.DAL.Models;
using Hair_Salon_API.DAL.UnitOfWork;
using Hair_Salon_API.Services.Helpers;
using Hair_Salon_API.Services.Interfaces;
using Hair_Salon_API.Services.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Hair_Salon_API.Common.Interfaces;


namespace Hair_Salon_API.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IEncryptService _encryptService;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IOptions<AppSettings> appSettings, IEncryptService encryptService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _encryptService = encryptService;
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
            newUser.Password = _encryptService.Encrypt(userToAdd.Password);

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
            userToUpdate.Password = existingUser.Password;

            _mapper.Map(userToUpdate, existingUser);

            _unitOfWork.UserRepository.Update(existingUser);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<User, UserModel>(existingUser);
        }

        public async Task<UserModel> Authenticate(AuthenticateRequest model)
        {
            User existingUser = (await _unitOfWork.UserRepository.FindAsync(x => x.Email == model.Email)).FirstOrDefault();
            string encryptedPassword = _encryptService.Encrypt(model.Password);

            if (existingUser == null || existingUser.Password != encryptedPassword)
            {
                return null;
            }

            UserModel mappedExistingUser = _mapper.Map<UserModel>(existingUser);
/*            string token = generateJwtToken(mappedExistingUser);
*/
            return mappedExistingUser;
        }

        public string generateJwtToken(UserModel user)
        {
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
