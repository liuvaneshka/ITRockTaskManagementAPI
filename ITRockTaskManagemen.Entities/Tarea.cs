namespace ITRockTaskManagemen.Entities
{
    public class Tarea
    {
        public int Id { get; set; } 
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } 
        public bool IsCompleted { get; set; } = false; 
        public DateTime? DueDate { get; set; } 
    }
}
