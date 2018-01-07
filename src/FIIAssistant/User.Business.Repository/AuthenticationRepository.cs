using EnsureThat;
using User.Data.Access;
using User.Data.Model.Entities;
using User.Data.Model.Interfaces.Repositories;

namespace User.Business.Repository
{
    public class AuthenticationRepository : BaseRepository<Authentication>, IAuthenticationRepository
    {
        private readonly IStudentContext _context;

        public AuthenticationRepository(IStudentContext context) : base(context)
        {
            Ensure.That(context).IsNotNull();

            _context = context;
        }
    }
}