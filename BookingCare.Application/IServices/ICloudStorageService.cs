using Microsoft.AspNetCore.Http;

namespace BookingCare.Application.Services
{
    public interface ICloudStorageService
    {
        Task<string> UploadFileAsync(IFormFile file, string folderPath);
    }
}