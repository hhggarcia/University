using Microsoft.EntityFrameworkCore;
using UniversityAPI.DataAccess;
using UniversityAPI.Models.DataModels;

namespace UniversityAPI.Services
{
    public interface IChapterServices
    {
        Task<Chapter> GetChaptersOneCourse(int idCourse);
    }
    public class ChapterServices: IChapterServices
    {
        private readonly UniversityDBContext _context;

        public ChapterServices(UniversityDBContext context) 
        {
            _context = context;
        }

        public async Task<Chapter> GetChaptersOneCourse(int idCourse)
        {
            if (_context.Courses != null)
            {
                var course = await _context.Courses.FindAsync(idCourse);

                if (course != null && _context.Chapters != null)
                {
                    var chapter = await _context.Chapters.Include(c => c.Course).FirstOrDefaultAsync(c => c.Course.Id == course.Id);

                    if (chapter != null)
                    {
                        return chapter;

                    }
                }
            }

            return new Chapter();
            
        }
    }
}
