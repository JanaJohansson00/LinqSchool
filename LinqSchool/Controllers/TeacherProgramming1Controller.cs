using LinqSchool.Data;
using LinqSchool.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LinqSchool.Controllers
{
    public class TeacherProgramming1Controller : Controller
    {
        private readonly LinqSchoolDbContext _dbContext;

        public TeacherProgramming1Controller(LinqSchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IActionResult Index()
        {
            var subjects = _dbContext.Subjects.ToList();
            ViewData["Subjects"] = subjects;
            return View("GetTeacherForSubject");
        }    

        public async Task<IActionResult> GetTeacherForSubject(int subjectId)
        {
            var subjects = _dbContext.Subjects.ToList();
            ViewData["Subjects"] = subjects;

            var subject = await _dbContext.Subjects.FirstOrDefaultAsync(s => s.SubjectId == subjectId);
            if(subject != null)
            {
                ViewBag.SelectedSubjectId = subject.SubjectId;
                ViewBag.SelectedSubjectName = subject.SubjectName;
                var teachers = _dbContext.TeacherSubjects
                .Where(ts => ts.SubjectId == subjectId)
                .Join(_dbContext.Teachers,
                      ts => ts.TeacherId,
                      t => t.TeacherId,
                      (ts, t) => t)
                .Distinct()
                .ToList();

                ViewData["HasTeachers"] = teachers.Any();

                // Returnera lärarlistan till vyn
                return View(teachers);
            }
            else
            {
                ViewData["HasTeachers"] = false;
                return View(new List<Teacher>());
            }
       
        }

    }
}
