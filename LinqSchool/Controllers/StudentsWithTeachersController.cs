using LinqSchool.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinqSchool.Controllers
{
    public class StudentsWithTeachersController : Controller
    {
        private readonly LinqSchoolDbContext _dbContext;

        public StudentsWithTeachersController(LinqSchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetStudentsWithTeacher()
        {
            // Hämta alla elever med deras lärare
            var studentsWithTeacher = _dbContext.Students
          .Include(s => s.StudentSubjects)
          .ThenInclude(ss => ss.Subject)
              .ThenInclude(sub => sub.TeacherSubjects)
                  .ThenInclude(ts => ts.Teacher)
          .ToList();

            // Returnera en vy med eleverna och deras lärare
            return View(studentsWithTeacher);
        }
        
    }
}
