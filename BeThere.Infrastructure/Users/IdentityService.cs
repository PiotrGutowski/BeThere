using BeThere.DAL.Abstract;
using BeThere.DAL.Users.Repositories;
using BeThere.Infrastructure.Authentication;
using BeThere.Infrastructure.Exceptions;
using BeThere.Infrastructure.Extensions;
using BeThere.Infrastructure.Mappings.Extensions;
using BeThere.Infrastructure.Users.Commands;
using BeThere.Infrastructure.Users.Dto;
using BeThere.Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeThere.Infrastructure.Users
{
    public class IdentityService : IIdentityService
    {
        private readonly IIdentityRepository _identityRepository;

        private readonly IEncrypter _encrypter;

        public IdentityService(IIdentityRepository identityRepository, IEncrypter encrypter)
        {
            _identityRepository = identityRepository;
            _encrypter = encrypter;

        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _identityRepository.GetAsync(email);
            return user.MapToUserDto();

        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _identityRepository.GetAsync(email);
            if (user == null)
            {
                throw new ServiceException(ErrorCodes.InvalidCredentials, "Invalid credentials");
            }

            var hash = _encrypter.GetHash(password, user.Salt);
            if (user.Password == hash)
            {
                return;
            }
            throw new ServiceException(ErrorCodes.InvalidCredentials, "Invalid credentials");

        }

        public async Task RegisterAsync(Guid userId, string email, string username, string password, string role)
        {
            if (password.PasswordValidation())
            {

                var user = await _identityRepository.GetAsync(email);
                if (user != null)
                {
                    throw new ServiceException(ErrorCodes.EmailInUse, $"User with email: '{email}' already exists.");
                }

                var salt = _encrypter.GetSalt(password);
                var hash = _encrypter.GetHash(password, salt);
                user = new User(userId, email, username, hash,"user", salt);
                await _identityRepository.AddAsync(user);
            }
        }


    }
}
