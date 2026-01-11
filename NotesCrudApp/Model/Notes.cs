using System.ComponentModel.DataAnnotations;

namespace NotesCrudApp.Model
{
    public class Notes
    {
        [Key]
        public int Id { get; set; }
        public required string Title { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
    }
}
