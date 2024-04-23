namespace LinqSchool.Models
{
    //Kopplingstabell
    public class TeacherSubject
    {
        //Sammansatt primärnyckel av TeacherId och CourseId

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        //Mavigationsegenskaper
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
             
    }
}
