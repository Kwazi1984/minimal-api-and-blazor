namespace BlazorApp.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string? Index { get; set; }
        public string? Title { get; set; }
        public string? Subject { get; set; }
        public string? Company { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public string? Currency { get; set; }
        public string? Author { get; set; }
    }
}