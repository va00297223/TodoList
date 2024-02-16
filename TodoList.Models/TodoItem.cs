namespace TodoList.Models
{
        public class TodoItem

        {
            public int Id { get; set; }
            public DateTime DueDate { get; set; }
            public DateTime? CompletedDate { get; set; } // Nullable DateTime for completion date
            public string? Description { get; set; }
        }
    
}
