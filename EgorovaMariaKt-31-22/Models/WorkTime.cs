namespace EgorovaMariaKt_31_22.Models
{
    public class WorkTime
    {
        public int WorkTimeId { get; set; }
        public int WorkTimeHours { get; set; }
        public bool IsDeleted { get; set; } = false;
       // public int TeacherId { get; set; }              // Преподаватель
        public int LessonId { get; set; }              // Дисциплина
        //public Teacher Teacher { get; set; }            // навиг на преподавателя
        public Lesson Lesson { get; set; }            // навиг на дисциплину
        public ICollection<Lesson> Lessons { get; set; }
    }
}
