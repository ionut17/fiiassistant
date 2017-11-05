using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using User.Data.Access;
using User.Data.Model.Entities;
using User.Data.Model.Interfaces;

namespace User.Business.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly UserContext _context;

        public StudentRepository(UserContext context)
        {
            _context = context;
        }

        public IQueryable<Student> GetAll()
        {
            return _context.Set<Student>().AsNoTracking();
        }

        public Student GetById(Guid id)
        {
            return _context.Set<Student>()
                .AsNoTracking()
                .FirstOrDefault(e => e.Id == id);
        }

        public void Add(Student student)
        {
            _context.Add(student);
            _context.SaveChanges();
        }

        public void Update(Student student)
        {
            _context.Set<Student>().Update(student);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var student = GetById(id);
            _context.Set<Student>().Remove(student);
            _context.SaveChanges();
        }
    }
}