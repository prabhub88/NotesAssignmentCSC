namespace Domain.DTO
{
    public class NoteDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string Priority { get; set; } // Low, Medium, High
    }
}
