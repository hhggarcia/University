using Microsoft.EntityFrameworkCore;
using UniversityAPI.DataAccess;
using UniversityAPI.Models.DataModels;

namespace UniversityAPI.Services
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Course>> GetCoursesToCategory(int idCategory);

    }
    public class CategoryServices: ICategoryServices
    {
        private readonly UniversityDBContext _context;

        public CategoryServices(UniversityDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetCoursesToCategory(int idCategory)
        {
            if (_context.Categories != null)
            {
                var category = await _context.Categories.Include(c => c.Courses).FirstOrDefaultAsync(c => c.Id == idCategory);

                if (category != null)
                {
                    return category.Courses;
                }
            }

            return new List<Course>();
        }
    }
}
