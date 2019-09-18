using System.Threading.Tasks;
using Hork_Api.Entities;
using Hork_Api.Repositories;
using Hork_Api.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Hork_Api.Services
{
    public class UserProfileService
    {
        private readonly PasswordHasher _passwordHasher;
        private readonly UserProfileRepository _userProfileRepository;
        public UserProfileService(
            PasswordHasher passwordHasher,
            UserProfileRepository userProfileRepository) {
            _passwordHasher = passwordHasher;
            _userProfileRepository = userProfileRepository;
        }

        public async Task Insert(string email, string password) {
            var hashword = _passwordHasher.Hash(password);
            await _userProfileRepository.Insert(new UserProfile {
                Email = email,
                HashedPassword = hashword
            });
        }

        public async Task<bool> ValidatePassword(UserProfileModel userProfileModel) {
            var hashedPassword = await _userProfileRepository.GetAll()
                .Where(x => x.Email == userProfileModel.Email)
                .Select(x => x.HashedPassword)
                .SingleAsync();
            return _passwordHasher.Check(hashedPassword, userProfileModel.Password);
        }
        
    }
}