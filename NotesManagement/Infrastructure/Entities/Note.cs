using System.ComponentModel.DataAnnotations;


namespace Infrastructure.Entities
{
    public class Note
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Priority { get; set; }
    }
}
