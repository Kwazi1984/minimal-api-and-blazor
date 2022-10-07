using AppDocuments.Blazor.Models;

namespace AppDocuments.Blazor.Services
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