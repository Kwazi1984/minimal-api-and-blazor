using System.ComponentModel.DataAnnotations;

namespace AppDocuments.Blazor.Models
{
    public class Document
    {
        public int Id { get; set; }
        [Required]
        public string? Index { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Subject { get; set; }
        [Required]
        public string? Company { get; set; }
        [Required]
        public DateTime? Date { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public string? Currency { get; set; }
        public string? Author { get; set; }
    }
}