using System.Collections.Generic;

namespace ITI.PrimarySchool.DAL
{
    public class ClassDetails
    {
        public int ClassId { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public Teacher Teacher { get; set; }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
    }

    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }
    }
}
