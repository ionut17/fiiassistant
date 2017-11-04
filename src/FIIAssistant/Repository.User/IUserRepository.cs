using Commons;

namespace Repository.User {
    public class IUserRepository : BaseRepository<Model.User.Common.User> {
        private readonly UserContext _context;

        public IUserRepository(UserContext context) : base(context) {
            _context = context;
        }
    }
}