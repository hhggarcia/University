using Microsoft.EntityFrameworkCore;
using UniversityAPI.DataAccess;
using UniversityAPI.Models.DataModels;

namespace UniversityAPI.Services
{
    public interface IStudentServices
    {
        Task<IEnumerable<Student>> GetStudentsWithCourses();
        Task<IEnumerable<Student>> GetStudentsWithNoCourses();
        Task<IEnumerable<Student>> GetStudentsForCourse(int idCourse);
        Task<IEnumerable<Course>> GetCoursesOneStudent(int idStudent);

    }
    public class StudentServices : IStudentServices
    {
        private readonly UniversityDBContext _context;

        public StudentServices(UniversityDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Student>> GetStudentsWithCourses()
        {
            if (_context.Students != null)
            {
                var students = from e in _context.Students.Include(c => c.Courses)
                               where e.Courses.Any()
                               select e;

                return await students.ToListAsync();
            }

            return new List<Student>();

        }

        public async Task<IEnumerable<Student>> GetStudentsWithNoCourses()
        {
            if (_context.Students != null)
            {
                var students = from e in _context.Students.Include(c => c.Courses)
                               where !e.Courses.Any()
                               select e;

                return await students.ToListAsync();
            }

            return new List<Student>();
        }

        public async Task<IEnumerable<Student>> GetStudentsForCourse(int idCourse)
        {
            if (_context.Courses != null)
            {
                var course = await _context.Courses.Include(c => c.Students).FirstOrDefaultAsync(c => c.Id == idCourse);

                if (course != null)
                {
                    return course.Students;
                }
            }

            return new List<Student>();
        }

        public async Task<IEnumerable<Course>> GetCoursesOneStudent(int idStudent)
        {
            if (_context.Students != null)
            {
                var student = await _context.Students.Include(c => c.Courses).FirstOrDefaultAsync(c => c.Id == idStudent);

                if (student != null)
                {
                    return student.Courses;
                }
            }

            return new List<Course>();
        }
    }
}
