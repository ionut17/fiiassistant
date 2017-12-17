using System.Linq;
using EnsureThat;
using User.Data.Access;
using User.Data.Model.Entities;
using User.Data.Model.Interfaces.Repositories;

namespace User.Business.Repository
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        private readonly IStudentContext _context;

        public StudentRepository(StudentContext context) : base(context)
        {
            Ensure.That(context).IsNotNull();

            _context = context;
        }

        public User GetStudentByEmail(string email)
        {
            return _context.Students.FirstOrDefault(student => student.Email.Equals(email));
        }
    }
}