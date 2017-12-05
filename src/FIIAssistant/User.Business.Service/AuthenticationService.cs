using System;
using System.Security.Cryptography;
using EnsureThat;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using User.Data.Model.Entities;
using User.Data.Model.Interfaces;
using User.Data.Model.Interfaces.Repositories;
using User.Data.Model.Interfaces.Services;

namespace User.Business.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IStudentRepository _studentRepository;

        public AuthenticationService(IStudentRepository studentRepository,
            IAuthenticationRepository authenticationRepository)
        {
            Ensure.That(studentRepository).IsNotNull();
            Ensure.That(authenticationRepository).IsNotNull();

            _studentRepository = studentRepository;
            _authenticationRepository = authenticationRepository;
        }

        public void RegisterUser(User user, string password)
        {
            byte[] salt = new byte[128/8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256/8));

            var authentication = new Authentication()
            {
                Id = user.Id,
                Email = user.Email,
                Password = hashed,
                Salt = salt,
            };

            _authenticationRepository.Add(authentication);
        }

        public User FindUserByEmail(string email)
        {
            return _studentRepository.GetStudentByEmail(email);
        }

        public bool ValidateUserPassword(User user, string password)
        {
            return _authenticationRepository.ValidateUserPassword(user, password);
        }
    }
}