using User.Data.Model.Entities;

namespace User.Data.Model.Interfaces.Repositories
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        User GetStudentByEmail(string email);
    }
}