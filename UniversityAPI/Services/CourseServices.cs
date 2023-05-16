using Microsoft.EntityFrameworkCore;
using UniversityAPI.DataAccess;
using UniversityAPI.Models.DataModels;

namespace UniversityAPI.Services
{
    public interface ICourseServices
    {
        Task<IEnumerable<Course>> GetCourseNoChapter();
    }
    public class CourseServices: ICourseServices
    {
        private readonly UniversityDBContext _context;

        public CourseServices(UniversityDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetCourseNoChapter()
        {
            if (_context.Courses != null && _context.Chapters != null)
            {
                var courses = from course in _context.Courses
                              join chapter in _context.Chapters
                              on course.Id equals chapter.CourseId
                              select course;

                return await courses.ToListAsync();
            }

            return new List<Course>();
        }
    }
}
