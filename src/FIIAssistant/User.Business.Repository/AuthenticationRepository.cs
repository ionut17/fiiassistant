using System;
using EnsureThat;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using User.Data.Access;
using User.Data.Model.Entities;
using User.Data.Model.Interfaces;
using User.Data.Model.Interfaces.Repositories;

namespace User.Business.Repository
{
    public class AuthenticationRepository : BaseRepository<Authentication>, IAuthenticationRepository
    {
        private readonly IStudentContext _context;

        public AuthenticationRepository(StudentContext context) : base(context)
        {
            Ensure.That(context).IsNotNull();

            _context = context;
        }

        public bool ValidateUserPassword(User user, string password)
        {
            var authEntity = GetById(user.Id);

            if (authEntity == null)
            {
                return false;
            }

            var hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password,
                authEntity.Salt,
                KeyDerivationPrf.HMACSHA1,
                10000,
                256 / 8
            ));

            return hashedPassword.Equals(authEntity.Password);
        }
    }
}