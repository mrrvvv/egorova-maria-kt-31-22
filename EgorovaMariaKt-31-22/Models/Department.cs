namespace EgorovaMariaKt_31_22.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentMainTeacher { get; set; } // Старший преподаватель кафедры
        public bool IsDeleted { get; set; } = false;
    }
}
