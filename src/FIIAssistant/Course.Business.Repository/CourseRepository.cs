using Course.Data.Access;
using Course.Data.Model;
using EnsureThat;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Course.Business.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ICourseContext _context;

        public CourseRepository(ICourseContext context)
        {
            Ensure.That(context).IsNotNull();

            _context = context;
        }

        public IQueryable<Data.Model.Course> GetAll()
        {
            return _context.Set<Data.Model.Course>().AsNoTracking();
        }

        public Data.Model.Course GetCourseById(Guid id)
        {
            return _context.Set<Data.Model.Course>()
                .AsNoTracking()
                .FirstOrDefault(e => e.Id == id);
        }

        public void AddCourse(Data.Model.Course course)
        {
            _context.Set<Data.Model.Course>().Add(course);
            _context.SaveChanges();
        }

        public void UpdateCourse(Data.Model.Course course)
        {
            _context.Set<Data.Model.Course>().Update(course);
            _context.SaveChanges();
        }

        public void DeleteCourse(Guid id)
        {
            var course = _context.Set<Data.Model.Course>().Single(e => e.Id == id);

            if (course == null)
                return;

            _context.Set<Data.Model.Course>().Remove(course);
            _context.SaveChanges();
        }

        public void AddStudentCourse(StudentCourse studentCourse)
        {
            _context.Set<StudentCourse>().Add(studentCourse);
            _context.SaveChanges();
        }

        public IQueryable<StudentCourse> GetAllCoursesForStudent(Guid studentId)
        {
            return _context.Set<StudentCourse>().AsNoTracking()
                .Where(sc => sc.StudentId == studentId);
        }

        public void DeleteStudentCourse(StudentCourse studentCourse)
        {
            _context.Set<StudentCourse>().Remove(studentCourse);
            _context.SaveChanges();
        }
    }
}