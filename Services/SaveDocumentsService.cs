using TaskMasterApi.Data.Response;
using TaskMasterApi.Data.Models;
using TaskMasterApi.Interfaces;
using Microsoft.Extensions.Options;
using System.Net;
using System.Threading.Tasks;

namespace TaskMasterApi.Services
{
    public class SaveDocumentsService : ISaveDocumentsService
    {
        private readonly Settings _settings;

        public SaveDocumentsService(IOptions<Settings> settings)
        {
            _settings = settings.Value;
        }

        public async Task<SaveDocumentsResponse> SaveDocument(IFormFile File)
        {
            if (!Directory.Exists(_settings.SaveDocumentsPath))
            {
                Directory.CreateDirectory(_settings.SaveDocumentsPath);
            }

            string path = Path.Combine(_settings.SaveDocumentsPath, File.FileName);
            using(FileStream newFile = new FileStream(path, FileMode.Create)){
                await File.CopyToAsync(newFile);
                await newFile.FlushAsync();
            }

            return new SaveDocumentsResponse
            {
                SavePath = path
            };
        }
    }
}
