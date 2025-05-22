namespace EgorovaMariaKt_31_22.Models
{
    public class AcademicDegree
    {
        public int AcademicDegreeId {  get; set; }//идент ученой степени
        public string AcademicDegreeName { get; set; }//название ученой степени
        public bool IsDeleted { get; set; } = false; // Добавляем soft-delete
    }
}
