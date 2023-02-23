using System.Drawing;
using System;
using UniversityAPI.Models.DataModels;
using UniversityAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace UniversityAPI.Services
{
    public interface IServices
    {
        Task<ICollection<Course>> CourseEmpty();
        Task<ICollection<Course>> CoursesCategory(Level level, Category category);
        Task<ICollection<Course>> CoursesOnlyOneStudent(Level level);
        Task<ICollection<User>> SearchEmail(string email);
        Task<ICollection<Student>> StudentsOlds();
        Task<ICollection<Student>> StudentsOnlyOneCourse();
    }
    public class Services : IServices
    {
        private readonly UniversityDBContext _context;

        public Services(UniversityDBContext context)
        {
            _context = context;
        }
        // Buscar usuario por Email
        public async Task<ICollection<User>> SearchEmail(string email)
        {
            var user = from u in _context.Users
                       where u.Email == email
                       select u;

            return await user.ToListAsync();
        }
        // Alumnos mayores de edad
        public async Task<ICollection<Student>> StudentsOlds()
        {
            var yearActual = DateTime.Now.Year;

            var studentsOld = from s in _context.Students
                              where (yearActual - s.Dob.Year) > 18
                              select s;

            return await studentsOld.ToListAsync();
        }
        // Buscar alumnos que tengan al menos un curso
        public async Task<ICollection<Student>> StudentsOnlyOneCourse()
        {
            var students = from student in _context.Students
                           where student.Courses.Count() >= 1
                           select student;

            return await students.ToListAsync();
        }
        // Buscar cursos de un nivel determinado que al menos tengan un alumno inscrito
        public async Task<ICollection<Course>> CoursesOnlyOneStudent(Level level)
        {
            var courses = from course in _context.Courses
                          where course.Level == level
                          where course.Students.Count() >= 1
                          select course;

            return await courses.ToListAsync();
        }
        // Buscar cursos de un nivel determinado que sean de una categoría determinada
        public async Task<ICollection<Course>> CoursesCategory(Level level, Category category)
        {
            var courses = from course in _context.Courses
                          where course.Level == level
                          where course.Categories.Contains(category)
                          select course;

            return await courses.ToListAsync();
        }
        // Buscar cursos sin alumnos
        public async Task<ICollection<Course>> CourseEmpty()
        {
            var courses = from course in _context.Courses
                          where !course.Students.Any()
                          select course;

            return await courses.ToListAsync();
        }
    }
}
