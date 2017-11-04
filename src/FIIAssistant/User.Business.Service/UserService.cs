using User.Business.Repository;

namespace User.Business.Service {
    public class UserService {
        private readonly StudentRepository _studentRepository;

        public UserService(StudentRepository studentRepository) {
            _studentRepository = studentRepository;
        }
    }
}