using Repository.User;

namespace Service.User {
    public class UserService {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository) {
            _userRepository = userRepository;
        }
    }
}