namespace User.Data.Model.Interfaces.Services
{
    public interface IAuthenticationService {
        User FindUserByEmail(string email);
        bool ValidateUserPassword(User user, string password);
    }
}
