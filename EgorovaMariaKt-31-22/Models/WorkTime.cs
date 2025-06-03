namespace EgorovaMariaKt_31_22.Models
{
    public class WorkTime
    {
        public int WorkTimeId { get; set; }
        public int WorkTimeHours { get; set; }
        public bool IsDeleted { get; set; } = false;


        // Обратная связь с Lesson
        //public ICollection<Lesson> Lessons { get; set; }
    }
}
