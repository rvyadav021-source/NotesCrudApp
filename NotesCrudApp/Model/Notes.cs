namespace NotesCrudApp.Model
{
    public class Notes
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string priority { get; set; } = string.Empty;
    }
}
