using LinqSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace LinqSchool.Data
{
    public class LinqSchoolDbContext : DbContext
    {
        public LinqSchoolDbContext(DbContextOptions<LinqSchoolDbContext> options)
            : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects{get; set;}
        public DbSet<StudentSubject> StudentSubjects { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherSubject>()
                 .HasKey(ts => new { ts.TeacherId, ts.SubjectId });

            modelBuilder.Entity<StudentSubject>()
                 .HasKey(ss => new { ss.StudentId, ss.SubjectId });


            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<Teacher>().HasData(
                 new Teacher { TeacherId = 1, TeacherFirstName = "Reidar", TeacherLastName = "Nielsen" },
                 new Teacher { TeacherId = 2, TeacherFirstName = "Tobias", TeacherLastName = "Landen" },
                 new Teacher { TeacherId = 3, TeacherFirstName = "Aldor", TeacherLastName = "Besher"}
                 );

                modelBuilder.Entity<Subject>().HasData(
                    new Subject { SubjectId = 1, SubjectName = "Programming 1" },
                    new Subject { SubjectId = 2, SubjectName = "Programming 2" },
                    new Subject { SubjectId = 3, SubjectName = "Science" },
                    new Subject { SubjectId = 4, SubjectName = "Math" },
                    new Subject { SubjectId = 5, SubjectName = "Chemistry" }
                    );

                modelBuilder.Entity<TeacherSubject>().HasData(
                    new TeacherSubject { TeacherId = 1, SubjectId = 1 },
                    new TeacherSubject { TeacherId = 2, SubjectId = 2, },
                     new TeacherSubject { TeacherId = 2, SubjectId = 1 },
                    new TeacherSubject { TeacherId = 3, SubjectId = 3 },
                    new TeacherSubject { TeacherId = 1, SubjectId = 4 },
                    new TeacherSubject { TeacherId = 2, SubjectId = 5 }
                    );

            modelBuilder.Entity<StudentSubject>().HasData(
                new StudentSubject { StudentId = 1, SubjectId = 1,},
                new StudentSubject { StudentId = 2, SubjectId = 2 },
                new StudentSubject { StudentId = 3, SubjectId = 3 },
                new StudentSubject { StudentId = 4, SubjectId = 4 },
                new StudentSubject { StudentId = 5, SubjectId = 5 },
                new StudentSubject { StudentId = 6, SubjectId = 1 },
                new StudentSubject { StudentId = 7, SubjectId = 2 },
                new StudentSubject { StudentId = 8, SubjectId = 3 },
                new StudentSubject { StudentId = 9, SubjectId = 1, },
                new StudentSubject { StudentId = 10, SubjectId = 1 },
                new StudentSubject { StudentId = 11, SubjectId = 1 },
                new StudentSubject { StudentId = 12, SubjectId = 1 }
                    );

            modelBuilder.Entity<Class>().HasData(
                   new Class { ClassId = 1, ClassName = "3A" },
                   new Class { ClassId = 2, ClassName = "4A" },
                   new Class { ClassId = 3, ClassName = "5A" },
                   new Class { ClassId = 4, ClassName = "6A" }
                   );

           modelBuilder.Entity<Student>().HasData(
                 new Student { StudentId = 1, StudentFirstName = "Bosse", StudentLastName = "Losse", ClassId = 1, TeacherId = 1 },
                 new Student { StudentId = 2, StudentFirstName = "Tora", StudentLastName = "Svensson", ClassId = 2  },
                 new Student { StudentId = 3, StudentFirstName = "Nils", StudentLastName = "Juel", ClassId = 3  },
                 new Student { StudentId = 4, StudentFirstName = "Lova", StudentLastName = "Andersson", ClassId = 4 },
                 new Student { StudentId = 5, StudentFirstName = "Jessica", StudentLastName = "Tilly", ClassId = 1 },
                 new Student { StudentId = 6, StudentFirstName = "Tomas", StudentLastName = "Nord", ClassId = 2, TeacherId = 1 },
                 new Student { StudentId = 7, StudentFirstName = "Sebastian", StudentLastName = "Andersen", ClassId = 3 },
                 new Student { StudentId = 8, StudentFirstName = "Linus", StudentLastName = "Ingvarsson", ClassId = 4 },
                 new Student { StudentId = 9, StudentFirstName = "Moa", StudentLastName = "Wik", ClassId = 4, TeacherId = 1},
                 new Student { StudentId = 10, StudentFirstName = "Pi", StudentLastName = "Love", ClassId = 2, TeacherId = 1 },
                 new Student { StudentId = 11, StudentFirstName = "Sarah", StudentLastName = "Lee", ClassId = 1, TeacherId = 1 },
                 new Student { StudentId = 12, StudentFirstName = "Moe", StudentLastName = "Beer", ClassId = 3, TeacherId = 1 }
                   );
            
        }
    }

}
