using User.Data.Access;
using User.Data.Model.Entities;
using User.Data.Model.Interfaces;

namespace User.Business.Repository
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        private readonly UserContext _context;

        public StudentRepository(UserContext context) : base(context)
        {
            _context = context;
        }
    }
}