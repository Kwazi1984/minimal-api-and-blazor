using BlazorApp.Models;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace BlazorApp.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly HttpClient _http;

        public DocumentService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Document>?> GetDocuments()
        {
            // List<Document>? documents = new();

            // try
            // {
            //     documents = await _http.GetFromJsonAsync<List<Document>>("documents");
            // }
            // catch (AccessTokenNotAvailableException exception)
            // {
            //     exception.Redirect();
            // }

            // return documents;

            return await _http.GetFromJsonAsync<List<Document>>("documents");
        }

        public async Task<Document?> GetDocument(int? id)
        {
            return await _http.GetFromJsonAsync<Document>($"/documents/{id}");
        }

        public async Task AddDocument(Document document)
        {
            await _http.PostAsJsonAsync("/documents", document);
        }

        public async Task UpdateDocument(Document document)
        {
            await _http.PutAsJsonAsync($"/documents/{document.Id}", document);
        }

        public async Task DeleteDocument(int id)
        {
            await _http.DeleteAsync($"/documents/{id}");
        }
    }
}