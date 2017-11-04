using Repository.User;

namespace Service.User {
    public class UserService {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }
    }
}