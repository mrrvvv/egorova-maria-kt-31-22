namespace EgorovaMariaKt_31_22.Models
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public bool IsDeleted { get; set; } = false;

 
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int WorkTimeId { get; set; }
        public WorkTime WorkTime { get; set; }

    }
}
