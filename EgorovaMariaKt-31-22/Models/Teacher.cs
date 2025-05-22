namespace EgorovaMariaKt_31_22.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }                     // Первичный ключ
        public string TeacherFirstName { get; set; }            // ФИО преподавателя
        public string TeacherLastName { get; set; }
        public string TeacherMiddleName { get; set; }
        public string TeacherPosition { get; set; }

        public bool IsDeleted { get; set; } = false;
        public ICollection<Lesson> Lessons { get; set; }
    }
}
