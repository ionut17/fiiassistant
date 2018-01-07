using Course.Data.Access;
using Course.Data.Model;
using EnsureThat;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Course.Business.Repository
{
    public class CourseRepository
    {
        private readonly CourseContext _context;

        protected CourseRepository(CourseContext context)
        {
            Ensure.That(context).IsNotNull();

            _context = context;
        }

        public IQueryable<CourseDTO> GetAll()
        {
            return _context.Set<CourseDTO>().AsNoTracking();
        }

        public CourseDTO GetCourseById(Guid id)
        {
            return _context.Set<CourseDTO>()
                .AsNoTracking()
                .FirstOrDefault(e => e.Id == id);
        }

        public void AddCourse(CourseDTO course)
        {
            _context.Add(course);
            _context.SaveChanges();
        }

        public void UpdateCourse(CourseDTO course)
        {
            _context.Set<CourseDTO>().Update(course);
            _context.SaveChanges();
        }

        public void DeleteCourse(Guid id)
        {
            var course = _context.Set<CourseDTO>().Single(e => e.Id == id);

            if (course == null)
                return;

            _context.Set<CourseDTO>().Remove(course);
            _context.SaveChanges();
        }

        public void AddStudentCourse(StudentCourseDTO studentCourse)
        {
            _context.Add(studentCourse);
            _context.SaveChanges();
        }

        public IQueryable<StudentCourseDTO> GetAllCoursesForStudent(Guid studentId)
        {
            return _context.Set<StudentCourseDTO>().AsNoTracking()
                .Where(sc => sc.StudentId == studentId);
        }

        public void DeleteStudentCourse(StudentCourseDTO studentCourse)
        {
            _context.Set<StudentCourseDTO>().Remove(studentCourse);
            _context.SaveChanges();
        }
    }
}