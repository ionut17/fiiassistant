using EnsureThat;
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