using TaskMasterApi.Data.Models;
using TaskMasterApi.Data.Response;

namespace TaskMasterApi.Interfaces
{
    public interface ISaveDocumentsService
    {
        Task<SaveDocumentsResponse> SaveDocument(IFormFile Fiel);
    }
}
