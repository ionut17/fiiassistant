using System;
using EnsureThat;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using User.Data.Model.Entities;
using User.Data.Model.Interfaces;

namespace User.Business.Repository
{
    public class AuthenticationRepository : BaseRepository<Authentication>, IAuthenticationRepository
    {
        private readonly DbContext _context;

        public AuthenticationRepository(DbContext context) : base(context) {
            Ensure.That(context).IsNotNull();

            _context = context;
        }

        public bool ValidateUserPassword(User user, string password) {

            var authEntity = GetById(user.Id);

            if (authEntity == null) {
                return false;
            }

            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: authEntity.Salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
            ));

            return hashedPassword.Equals(authEntity.Password);
        }
        
    }
}
