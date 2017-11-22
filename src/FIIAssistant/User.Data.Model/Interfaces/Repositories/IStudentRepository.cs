using User.Data.Model.Entities;

namespace User.Data.Model.Interfaces
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        User GetStudentByEmail(string email);
    }
}