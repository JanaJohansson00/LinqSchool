using LinqSchool.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinqSchool.Controllers
{
    public class EditStudentTeacherP1Controller : Controller
    {
        private readonly LinqSchoolDbContext _dbContext;

        public EditStudentTeacherP1Controller(LinqSchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult EditStudentTeacher()
        {
            var programming1Subject = _dbContext.Subjects.FirstOrDefault(s => s.SubjectName == "Programming 1");
            if(programming1Subject == null)
            {
                return NotFound("Programming 1 not found");
            }

            var students = _dbContext.Students
                .Where(s => s.StudentSubjects.Any(ss => ss.SubjectId == programming1Subject.SubjectId))
                .ToList();

            var teachers = _dbContext.Teachers
                .Where(t => t.TeacherSubjects.Any(ts => ts.SubjectId == programming1Subject.SubjectId))
                .ToList();

            ViewBag.Students = students;
            ViewBag.Teachers = teachers;

            return View();
        }
        [HttpPost]

        public IActionResult UpdateTeacher (int studentId, int teacherId)
        {
            var student = _dbContext.Students.FirstOrDefault(s => s.StudentId == studentId);
            if (student != null)
            {
                // Spara studentens ID och lärarens ID i TempData för att använda dem igen i vyn
                TempData["SelectedStudentId"] = studentId;
                TempData["SelectedTeacherId"] = teacherId;

                // Check if the selected teacher is different from the current one
                if (student.TeacherId != teacherId)
                {
                    student.TeacherId = teacherId;
                    _dbContext.SaveChanges();
                    TempData["SuccessMessage"] = "Teacher was updated successfully!";
                }
                else
                {
                    TempData["SuccessMessage"] = "Teacher remains the same. No update was needed.";
                }
            }
            return RedirectToAction("EditStudentTeacher");
        }
    }
}
