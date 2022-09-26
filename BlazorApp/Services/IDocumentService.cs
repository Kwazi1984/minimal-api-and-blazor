using BlazorApp.Models;

namespace BlazorApp.Services
{
    public interface IDocumentService
    {
        Task<List<Document>?> GetDocuments();
        Task<Document?> GetDocument(int? id);
        Task AddDocument(Document document);
        Task UpdateDocument(Document document);
        Task DeleteDocument(int id);
    }
}