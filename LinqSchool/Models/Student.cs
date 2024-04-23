using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinqSchool.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }

        public int? ClassId { get; set; }
        public Class Class { get; set; }

        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public ICollection<StudentSubject> StudentSubjects { get; set; } = [];
       

    }
}
