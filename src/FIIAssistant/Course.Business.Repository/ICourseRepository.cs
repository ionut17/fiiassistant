using System;
using System.Linq;
using Course.Data.Model;

namespace Course.Business.Repository
{
    public interface ICourseRepository
    {
        IQueryable<Data.Model.Course> GetAll();
        Data.Model.Course GetCourseById(Guid id);
        void AddCourse(Data.Model.Course course);
        void UpdateCourse(Data.Model.Course course);
        void DeleteCourse(Guid id);
        void AddStudentCourse(StudentCourse studentCourse);
        IQueryable<StudentCourse> GetAllCoursesForStudent(Guid studentId);
        void DeleteStudentCourse(StudentCourse studentCourse);
    }
}