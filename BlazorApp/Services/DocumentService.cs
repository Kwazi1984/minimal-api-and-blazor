using BlazorApp.Models;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly HttpClient _http;
        private readonly string _baseUrl = "https://localhost:5001";

        public DocumentService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Document>?> GetDocuments()
        {
            return await _http.GetFromJsonAsync<List<Document>>(_baseUrl + "/documents");
        }

        public async Task<Document?> GetDocument(int? id)
        {
            return await _http.GetFromJsonAsync<Document>(_baseUrl + $"/documents/{id}");
        }

        public async Task AddDocument(Document document)
        {
            await _http.PostAsJsonAsync(_baseUrl + "/documents", document);
        }

        public async Task UpdateDocument(Document document)
        {
            await _http.PutAsJsonAsync(_baseUrl + $"/documents/{document.Id}", document);
        }

        public async Task DeleteDocument(int id)
        {
            await _http.DeleteAsync(_baseUrl + $"/documents/{id}");
        }
    }
}