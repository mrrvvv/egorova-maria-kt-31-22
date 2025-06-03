namespace EgorovaMariaKt_31_22.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public bool IsDeleted { get; set; } = false;

        // Связь с заведующим кафедрой (преподавателем)
        public int HeadTeacherId { get; set; }
        public Teacher HeadTeacher { get; set; }

        // Преподаватели кафедры
        //public ICollection<Teacher> Teachers { get; set; }
    }
}
