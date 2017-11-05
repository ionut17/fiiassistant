using System;
using System.Linq;
using User.Data.Model.Entities;

namespace User.Data.Model.Interfaces
{
    public interface IStudentRepository
    {
        IQueryable<Student> GetAll();
        Student GetById(Guid id);
        void Add(Student student);
        void Update(Student student);
        void Delete(Guid id);
    }
}