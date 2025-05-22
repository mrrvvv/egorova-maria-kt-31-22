namespace EgorovaMariaKt_31_22.Models
{
    public class Position
    {
        public int PositionId { get; set; }//id должности
        public string PositionName { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
