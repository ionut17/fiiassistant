using EnsureThat;
using User.Data.Model.Interfaces;
using User.Data.Model.Interfaces.Services;

namespace User.Business.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository,
            IAuthenticationRepository authenticationRepository)
        {
            Ensure.That(userRepository).IsNotNull();
            Ensure.That(authenticationRepository).IsNotNull();

            _userRepository = userRepository;
            _authenticationRepository = authenticationRepository;
        }

        public User FindUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public bool ValidateUserPassword(User user, string password)
        {
            return _authenticationRepository.ValidateUserPassword(user, password);
        }
    }
}