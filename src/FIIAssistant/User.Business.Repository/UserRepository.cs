using System;
using System.Linq;
using EnsureThat;
using User.Data.Access;
using User.Data.Model.Entities;
using User.Data.Model.Interfaces;

namespace User.Business.Repository
{
    public class UserRepository : BaseRepository<Student>, IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context) : base(context)
        {
            Ensure.That(context).IsNotNull();

            _context = context;
        }

        public User GetUserByEmail(string email) {
            return _context.Students.FirstOrDefault(user => user.Email.Equals(email));
        }
    }
}