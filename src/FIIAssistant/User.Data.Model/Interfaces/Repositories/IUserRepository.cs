using User.Data.Model.Common;
using User.Data.Model.Entities;

namespace User.Data.Model.Interfaces
{
    public interface IUserRepository : IBaseRepository<Student> {
        User GetUserByEmail(string email);
    }
}