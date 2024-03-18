namespace ElasticSearch.API.Services
{
    public interface IElasticSearchServices<T>
    {
        Task<string> CreateDocumentAsync(T document);
        Task<T> GetDocumentAsync(int id);
        Task<IEnumerable<T>> GetAllDocumentsAsync();
        Task<string> UpdateDocumentAsync(T document);
        Task<string> DeleteDocumentAsync(int id);

    }
}
